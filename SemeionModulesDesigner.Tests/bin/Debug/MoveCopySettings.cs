﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5456
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class MoveCopySettings {
    
    private MoveCopySettingsSetting[] settingField;
    
    private bool enabledField;
    
    private string commentField;
    
    private MoveCopySettingsSettingFileCollisionAction collisionActionField;
    
    private MoveCopySettingsSettingFileAction actionField;
    
    private string filterFormatsField;
    
    private string outputDirectoryField;
    
    private System.DateTime creationDateField;
    
    private System.DateTime lastUpdateField;
    
    private bool lastUpdateFieldSpecified;
    
    private string authorEmailField;
    
    private string versionField;
    
    private string documentCountField;
    
    private string sourceField;
    
    private MoveCopySettingsUnmatchedFileAction unmatchedFileActionField;
    
    public MoveCopySettings() {
        this.enabledField = true;
        this.collisionActionField = MoveCopySettingsSettingFileCollisionAction.Undefined;
        this.actionField = MoveCopySettingsSettingFileAction.Undefined;
        this.unmatchedFileActionField = MoveCopySettingsUnmatchedFileAction.Skip;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Setting", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public MoveCopySettingsSetting[] Setting {
        get {
            return this.settingField;
        }
        set {
            this.settingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(true)]
    public bool enabled {
        get {
            return this.enabledField;
        }
        set {
            this.enabledField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string comment {
        get {
            return this.commentField;
        }
        set {
            this.commentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(MoveCopySettingsSettingFileCollisionAction.Undefined)]
    public MoveCopySettingsSettingFileCollisionAction collisionAction {
        get {
            return this.collisionActionField;
        }
        set {
            this.collisionActionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(MoveCopySettingsSettingFileAction.Undefined)]
    public MoveCopySettingsSettingFileAction action {
        get {
            return this.actionField;
        }
        set {
            this.actionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string filterFormats {
        get {
            return this.filterFormatsField;
        }
        set {
            this.filterFormatsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string outputDirectory {
        get {
            return this.outputDirectoryField;
        }
        set {
            this.outputDirectoryField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
    public System.DateTime creationDate {
        get {
            return this.creationDateField;
        }
        set {
            this.creationDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
    public System.DateTime lastUpdate {
        get {
            return this.lastUpdateField;
        }
        set {
            this.lastUpdateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool lastUpdateSpecified {
        get {
            return this.lastUpdateFieldSpecified;
        }
        set {
            this.lastUpdateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authorEmail {
        get {
            return this.authorEmailField;
        }
        set {
            this.authorEmailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string version {
        get {
            return this.versionField;
        }
        set {
            this.versionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
    public string documentCount {
        get {
            return this.documentCountField;
        }
        set {
            this.documentCountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string source {
        get {
            return this.sourceField;
        }
        set {
            this.sourceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(MoveCopySettingsUnmatchedFileAction.Skip)]
    public MoveCopySettingsUnmatchedFileAction unmatchedFileAction {
        get {
            return this.unmatchedFileActionField;
        }
        set {
            this.unmatchedFileActionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class MoveCopySettingsSetting {
    
    private MoveCopySettingsSettingFile[] fileField;
    
    private bool enabledField;
    
    private string commentField;
    
    private MoveCopySettingsSettingFileCollisionAction collisionActionField;
    
    private MoveCopySettingsSettingFileAction actionField;
    
    private string filterFormatsField;
    
    private string outputDirectoryField;
    
    public MoveCopySettingsSetting() {
        this.enabledField = true;
        this.collisionActionField = MoveCopySettingsSettingFileCollisionAction.Undefined;
        this.actionField = MoveCopySettingsSettingFileAction.Undefined;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("File", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public MoveCopySettingsSettingFile[] File {
        get {
            return this.fileField;
        }
        set {
            this.fileField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(true)]
    public bool enabled {
        get {
            return this.enabledField;
        }
        set {
            this.enabledField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string comment {
        get {
            return this.commentField;
        }
        set {
            this.commentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(MoveCopySettingsSettingFileCollisionAction.Undefined)]
    public MoveCopySettingsSettingFileCollisionAction collisionAction {
        get {
            return this.collisionActionField;
        }
        set {
            this.collisionActionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(MoveCopySettingsSettingFileAction.Undefined)]
    public MoveCopySettingsSettingFileAction action {
        get {
            return this.actionField;
        }
        set {
            this.actionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string filterFormats {
        get {
            return this.filterFormatsField;
        }
        set {
            this.filterFormatsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string outputDirectory {
        get {
            return this.outputDirectoryField;
        }
        set {
            this.outputDirectoryField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class MoveCopySettingsSettingFile {
    
    private bool enabledField;
    
    private string commentField;
    
    private MoveCopySettingsSettingFileCollisionAction collisionActionField;
    
    private MoveCopySettingsSettingFileAction actionField;
    
    private string filterFormatsField;
    
    private string outputDirectoryField;
    
    private string nameFilterRegExpField;
    
    public MoveCopySettingsSettingFile() {
        this.enabledField = true;
        this.collisionActionField = MoveCopySettingsSettingFileCollisionAction.Undefined;
        this.actionField = MoveCopySettingsSettingFileAction.Undefined;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(true)]
    public bool enabled {
        get {
            return this.enabledField;
        }
        set {
            this.enabledField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string comment {
        get {
            return this.commentField;
        }
        set {
            this.commentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(MoveCopySettingsSettingFileCollisionAction.Undefined)]
    public MoveCopySettingsSettingFileCollisionAction collisionAction {
        get {
            return this.collisionActionField;
        }
        set {
            this.collisionActionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(MoveCopySettingsSettingFileAction.Undefined)]
    public MoveCopySettingsSettingFileAction action {
        get {
            return this.actionField;
        }
        set {
            this.actionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string filterFormats {
        get {
            return this.filterFormatsField;
        }
        set {
            this.filterFormatsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string outputDirectory {
        get {
            return this.outputDirectoryField;
        }
        set {
            this.outputDirectoryField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string nameFilterRegExp {
        get {
            return this.nameFilterRegExpField;
        }
        set {
            this.nameFilterRegExpField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum MoveCopySettingsSettingFileCollisionAction {
    
    /// <remarks/>
    Overwrite,
    
    /// <remarks/>
    Skip,
    
    /// <remarks/>
    Error,
    
    /// <remarks/>
    Undefined,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum MoveCopySettingsSettingFileAction {
    
    /// <remarks/>
    Copy,
    
    /// <remarks/>
    Move,
    
    /// <remarks/>
    Undefined,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum MoveCopySettingsUnmatchedFileAction {
    
    /// <remarks/>
    Skip,
    
    /// <remarks/>
    MoveToOutput,
    
    /// <remarks/>
    Delete,
}