using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml.Schema;

using SemeionModulesDesigner.XmlSchemaParser.XsdModel;
using SemeionModulesDesigner.XmlSchemaParser.XsdModel.Enums;
using SemeionModulesDesigner.XmlSchemaParser.XsdModel.Interfaces;
using XContainer = SemeionModulesDesigner.XmlSchemaParser.XsdModel.XContainer;
using XElement = SemeionModulesDesigner.XmlSchemaParser.XsdModel.XElement;

namespace SemeionModulesDesigner.XmlSchemaParser
{
    /// <summary>
    /// Used for Xsd file parsing.
    /// </summary>
    [Guid( "3E7CA7B6-E4D1-4346-80BE-10845633399F" )]
    public class XsdParser : IXsdParser
    {
        private XContainer _xFormRoot;
        private XContainer _lastContainer;
        private string _schemasBasePath;


        /// <summary>
        /// Get XForm from given Xsd file.
        /// </summary>
        /// <param name="fileName">Path to Xsd file.</param>
        /// <returns></returns>
        public XForm ParseXsdFile( string fileName )
        {

            _xFormRoot = null;
            _lastContainer = null;

            var xmlSchema = LoadXmlSchema( fileName );

            foreach ( XmlSchemaElement element in xmlSchema.Elements.Values )
            {
                BuildXForm( element, null );
            }

            var xForm = new XForm
            {
                Root = _xFormRoot
            };


            return xForm;

        }

        /// <summary>
        /// Loads given Xsd file into XmlSchema.
        /// </summary>
        /// <param name="fileName">Path to Xsd file.</param>
        /// <returns>XmlSchema from given file.</returns>
        private XmlSchema LoadXmlSchema( string fileName )
        {
            if ( string.IsNullOrEmpty( _schemasBasePath ) )
                _schemasBasePath = new FileInfo( fileName ).DirectoryName;

            var xsdDocument = XDocument.Load( fileName );
            var xmlNamespace = xsdDocument.Root.FirstAttribute.Value;

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.ValidationEventHandler += SchemaValidationHandler;
            schemaSet.Add( xmlNamespace, $@"{_schemasBasePath}\Common.xsd" );
            schemaSet.Add( xmlNamespace, fileName );
            schemaSet.Compile();

            return schemaSet.Schemas().Cast<XmlSchema>().LastOrDefault();
        }

        /// <summary>
        /// Build new XForm from XmlSchema.
        /// </summary>
        /// <param name="xmlSchemaElement">Current XmlSchemaElement.</param>
        /// <param name="parent">Parent XContainer to keep parent reference.</param>
        private void BuildXForm( XmlSchemaElement xmlSchemaElement, XContainer parent )
        {
            var container = new XContainer
            {
                MaxOccurs = xmlSchemaElement.MaxOccurs,
                MinOccurs = xmlSchemaElement.MinOccurs
            };

            if ( xmlSchemaElement.Parent is XmlSchemaGroupBase xmlSchemaGroupBase )
            {
                if ( !string.IsNullOrEmpty( xmlSchemaGroupBase.MaxOccursString ) )
                {
                    container.MaxOccurs = ( (XmlSchemaGroupBase)xmlSchemaElement.Parent ).MaxOccurs;
                    container.MinOccurs = ( (XmlSchemaGroupBase)xmlSchemaElement.Parent ).MinOccurs;
                }
            }

            container.ParentContainer = parent;
            container.Name = xmlSchemaElement.Name;

            container.Id = 1;

            if ( _lastContainer == null )
            {
                _lastContainer = new XContainer();
            }

            if ( xmlSchemaElement.ElementSchemaType is XmlSchemaSimpleType )
            {
                var element = new XElement
                {
                    Name = xmlSchemaElement.Name
                };
                _lastContainer.Elements.Add( element );

                //TODO IMPLEMENT ANOTHER RESTRICTION FACETS LIKE enumeration, maxExclusive, pattern, etc.
            }

            if ( xmlSchemaElement.ElementSchemaType is XmlSchemaComplexType complexType )
            {
                // If the complex type has any attributes, get an enumerator 
                // and write each attribute name to the container.
                if ( complexType.AttributeUses.Count > 0 )
                {
                    IDictionaryEnumerator enumerator = complexType.AttributeUses.GetEnumerator();

                    while ( enumerator.MoveNext() )
                    {
                        var attribute = (XmlSchemaAttribute)enumerator.Value;
                        var xAttribute = GetXAttribute( attribute );

                        container.Attributes.Add( xAttribute );
                    }
                }

                if ( _xFormRoot == null )
                {
                    _xFormRoot = container;
                }
                else
                {
                    _lastContainer.Containers.Add( container );
                }

                //xs:all, xs:choice, xs:sequence
                if ( complexType.ContentTypeParticle is XmlSchemaGroupBase )
                {

                    var baseParticle = complexType.ContentTypeParticle as XmlSchemaGroupBase;
                    foreach ( XmlSchemaElement subParticle in baseParticle.Items.Cast<XmlSchemaElement>() )
                    {
                        _lastContainer = container;
                        BuildXForm( subParticle, container );
                    }
                }
                else
                {
                    //TODO IMPLEMENT ANOTHER XmlSchemaContentType 

                    if ( complexType.ContentType == XmlSchemaContentType.TextOnly )
                    {
                        container.Value = string.Empty;
                    }
                }
            }

            _lastContainer = null;
        }

        /// <summary>
        /// Handler for errors during XmlSchema validation.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="args">Event data.</param>
        private void SchemaValidationHandler( object sender, ValidationEventArgs args )
        {
            throw new XmlSchemaValidationException( args.Message, args.Exception );
        }

        /// <summary>
        /// Provides correct IXAttribute depending on XmlTypeCode.
        /// </summary>
        /// <param name="attribute">Given XmlSchemaAttribute to process.</param>
        /// <returns>Coresponding IXAttribute.</returns>
        private IXAttribute GetXAttribute( XmlSchemaAttribute attribute )
        {
            IXAttribute xAttribute;
            var xmlTypeCode = attribute.AttributeSchemaType.TypeCode;


            //resolve restrictions for simple type (enumeration)
            if ( attribute.AttributeSchemaType.Content is XmlSchemaSimpleTypeRestriction restriction && restriction.Facets.Count > 0 )
            {
                var xStringRestrictionAttribute = new XEnumerationAttribute<string>( attribute.DefaultValue );
                foreach ( var enumerationFacet in restriction.Facets.OfType<XmlSchemaEnumerationFacet>() )
                {
                    xStringRestrictionAttribute.Enumeration.Add( enumerationFacet.Value );
                }

                //IS ENUMERATION
                if ( xStringRestrictionAttribute.Enumeration.Any() )
                {
                    xStringRestrictionAttribute.Name = attribute.Name;
                    xStringRestrictionAttribute.Use = (XAttributeUse)attribute.Use;
                    xStringRestrictionAttribute.Value = attribute.DefaultValue;
                    if ( xStringRestrictionAttribute.Use == XAttributeUse.None )
                    {
                        xStringRestrictionAttribute.Use = XAttributeUse.Optional;//set default value defined here http://www.w3schools.com/schema/el_attribute.asp
                    }
                    return xStringRestrictionAttribute;
                }
            }


            switch ( xmlTypeCode )
            {
                case XmlTypeCode.String:
                    xAttribute = new XAttribute<string>( attribute.DefaultValue );
                    ( (XAttribute<string>)xAttribute ).Value = attribute.DefaultValue;
                    break;
                case XmlTypeCode.Boolean:
                    if ( !string.IsNullOrEmpty( attribute.DefaultValue ) )
                    {
                        xAttribute = new XAttribute<bool>( bool.Parse( attribute.DefaultValue ) );
                        ( (XAttribute<bool>)xAttribute ).Value = bool.Parse( attribute.DefaultValue );
                    }
                    else
                    {
                        xAttribute = new XAttribute<bool>( false );
                        ( (XAttribute<bool>)xAttribute ).Value = false;
                    }
                    break;
                case XmlTypeCode.Date:

                    var defaultValue = new DateTime();
                    if ( !string.IsNullOrEmpty( attribute.DefaultValue ) )
                    {
                        defaultValue = DateTime.Parse( attribute.DefaultValue );
                    }

                    xAttribute = new XAttribute<DateTime>( defaultValue );
                    ( (XAttribute<DateTime>)xAttribute ).Value = defaultValue;
                    break;
                case XmlTypeCode.Integer:
                case XmlTypeCode.UnsignedInt:
                case XmlTypeCode.Int:

                    var defaultValueInteger = 0;
                    if ( !string.IsNullOrEmpty( attribute.FixedValue ) )
                    {
                        defaultValueInteger = int.Parse( attribute.FixedValue );
                    }
                    else if ( !string.IsNullOrEmpty( attribute.DefaultValue ) )
                    {
                        defaultValueInteger = int.Parse( attribute.DefaultValue );
                    }

                    xAttribute = new XAttribute<int>( defaultValueInteger );
                    ( (XAttribute<int>)xAttribute ).Value = defaultValueInteger;
                    break;
                default:
                    throw new ArgumentOutOfRangeException( $"Unknown XmlTypeCode. [{xmlTypeCode}]" );
            }

            xAttribute.Name = attribute.Name;
            xAttribute.Use = (XAttributeUse)attribute.Use;
            if ( xAttribute.Use == XAttributeUse.None )
            {
                //set default value defined here http://www.w3schools.com/schema/el_attribute.asp
                xAttribute.Use = XAttributeUse.Optional;
            }

            return xAttribute;
        }
    }
}
