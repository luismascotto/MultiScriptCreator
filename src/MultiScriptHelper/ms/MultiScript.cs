using System.Xml;
using System.Xml.Serialization;
using MultiScriptHelper.Model;

namespace MultiScriptHelper.Ms;

public class MultiScript
{
    private const int _XML_NODE_SIZE = 256;
    private const string _XML_COMMENT = "\nSQL Multi Script\nSQL Multi Script\nVersion:1.4.12.1269"
    //public List<Database> Databases { get; set; }
    //public StringBuilder strL { get; set; }

    private databaseListsFile _DatabaseListsFile;
    private databaseListsFileDatabaseListsValueDatabasesValuePassword _Password;
    private readonly XmlWriterSettings _XmlWriterSettings;
    private readonly XmlSerializerNamespaces _XmlSerializerNamespaces;
    private StringBuilder _StringBuilder;

    public MultiScript(List<Database> databases, string listName)
    {
        ArgumentNullException.ThrowIfNull(databases);

        _DatabaseListsFile = new();
        _Password = new();

        _XmlWriterSettings = new { Indent = true };
        _XmlSerializerNamespaces = new();
        _XmlSerializerNamespaces.Add(string.Empty, string.Empty);


        _StringBuilder = new(_LINE_SIZE * databases.Count);


        _DatabaseListsFile.databaseLists.value.name = listName;
        foreach (var database in databases)
        {
            _DatabaseListsFile.databaseLists.value.Databases.value.Add(new databaseListsFileDatabaseListsValueDatabasesValue
            {
                name = database.vchDatabase,
                server = database.vchServer,
                password = _Password
            });
        }
    }

    private void prepareUserData(User user)
    {
        _Password.Value = user.vchEncryptedPassword;
        databaseListsFile.databaseLists.value.Databases.value.ForEach(db => db.username = user.vchUser);
        _StringBuilder.Clear();
    }

    public string GetUserFileContent(User user)
    {
        prepareUserData(user);

        using var sw = new StringWriter(_StringBuilder);
        using var xw = XmlWriter.Create(sw, _XmlWriterSettings);
        xw.WriteStartDocument(true); // that bool parameter is called "standalone"
        xw.WriteComment(_XML_COMMENT);

        var xmlSerializer = new XmlSerializer(_DatabaseListsFile.GetType());
        xmlSerializer.Serialize(xw, _DatabaseListsFile, _XmlSerializerNamespaces);

        return sw.ToString();
    }

    public void ProcessaArquivosUsuarios(string fileName)
    {
        string strConteudo = "";
        foreach (var user in Users)
        {
            File.WriteAllText(Path.Combine(user.vchDesktopUserPath, $"{fileName}.smsdl"), GetUserFileContent(user));
        }
    }

}
