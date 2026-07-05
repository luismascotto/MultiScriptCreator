using System.Xml;
using System.Xml.Serialization;

namespace MultiScriptHelper.Model;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
public partial class databaseListsFile
{


    /// <remarks/>
    public databaseListsFileDatabaseLists databaseLists { get; set; } = new databaseListsFileDatabaseLists();

    /// <remarks/>
    [XmlAttribute()]
    public string version { get; set; } = "1";
   

    /// <remarks/>
    [XmlAttribute()]
    public string type { get; set; } = "databaseListsFile";
}

/// <remarks/>
[XmlType(AnonymousType = true)]
public partial class databaseListsFileDatabaseLists
{


    /// <remarks/>
    public databaseListsFileDatabaseListsValue value { get; set; } = new databaseListsFileDatabaseListsValue();

    /// <remarks/>
    [XmlAttribute()]
    public string type { get; set; } = "List_databaseList";
   

    /// <remarks/>
    [XmlAttribute()]
    public string version { get; set; } = "1";
}

/// <remarks/>
[XmlType(AnonymousType = true)]
public partial class databaseListsFileDatabaseListsValue
{
    
    /// <remarks/>
    public string name { get; set; }

    /// <remarks/>
    public databaseListsFileDatabaseListsValueDatabases databases { get; set; } = new databaseListsFileDatabaseListsValueDatabases();


    /// <remarks/>
    public string guid { get; set; } = Guid.NewGuid().ToString();

    /// <remarks/>
    [XmlAttribute()]
    public string version { get; set; } = "2";

    /// <remarks/>
    [XmlAttribute()]
    public string type { get; set; } = "databaseList";
}

/// <remarks/>
[XmlType(AnonymousType = true)]
public partial class databaseListsFileDatabaseListsValueDatabases
{

    /// <remarks/>
    [XmlElement("value")]
    public List<databaseListsFileDatabaseListsValueDatabasesValue> value { get; set; } = new List<databaseListsFileDatabaseListsValueDatabasesValue>();

    /// <remarks/>
    [XmlAttribute()]
    public string type { get; set; } = "BindingList_database";

    /// <remarks/>
    [XmlAttribute()]
    public string version { get; set; } = "1";
}

/// <remarks/>
[XmlType(AnonymousType = true)]
public partial class databaseListsFileDatabaseListsValueDatabasesValue
{

    /// <remarks/>
    public string name { get; set; }

    /// <remarks/>
    public string server { get; set; }

    /// <remarks/>
    public string integratedSecurity { get; set; } = "False";

    /// <remarks/>
    public string username { get; set; }

    /// <remarks/>
    public string savePassword { get; set; } = "True";

    /// <remarks/>
    public databaseListsFileDatabaseListsValueDatabasesValuePassword password { get; set; }

    /// <remarks/>
    public string connectionTimeout { get; set; } = "15";

    /// <remarks/>
    public string protocol { get; set; } = "-1";

    /// <remarks/>
    public string packetSize { get; set; } = "4096";

    /// <remarks/>
    public string encrypted { get; set; } = "False";

    /// <remarks/>
    public string selected { get; set; } = "True";

    /// <remarks/>
    public string cserver { get; set; } = "srv";

    /// <remarks/>
    public string @readonly { get; set; } = "False";

    /// <remarks/>
    [XmlAttribute()]
    public string version { get; set; } = "6";

    /// <remarks/>
    [XmlAttribute()]
    public string type { get; set; } = "database";
}

/// <remarks/>
[XmlType(AnonymousType = true)]
public partial class databaseListsFileDatabaseListsValueDatabasesValuePassword
{

    /// <remarks/>
    [XmlAttribute()]
    public string encrypted { get; set; } = "1";

    /// <remarks/>
    [XmlText()]
    public string Value { get; set; }
}

