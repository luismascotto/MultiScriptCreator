using Microsoft.Extensions.Configuration;

// ScriptCreator [ script | list ]
var argsConfig = new ConfigurationBuilder()
                            .AddCommandLine(args[1..], new Dictionary<string, string>()
                            {
                                { "-d", "d" },
                                { "-s", "s" },
                                { "-o", "o" },
                            })
                            .Build();



string databasesFilePath = argsConfig["d"]?.Trim() ?? "databases.txt";
string scriptFilePath = argsConfig["s"]?.Trim() ?? "script.sql";
string outputFilePath = argsConfig["o"]?.Trim() ?? "output.sql";

if (File.Exists(databasesFilePath))
{
    Console.WriteLine("Databases file not found.");
    return;
}
if (File.Exists(scriptFilePath))
{
    Console.WriteLine("Script file not found.");
    return;
}
if (Path.GetDirectoryName(outputFilePath) is string outputDir && !Directory.Exists(outputDir))
{
    Console.WriteLine("Output directory not found.");
    return;
}

try
{
    ReadOnlySpan<char> databasesSpan = File.ReadAllText(databasesFilePath).AsSpan();
    string scriptContent = File.ReadAllText(scriptFilePath);

    var outputFile = new StreamWriter(outputFilePath, false);
    int iCount = 1;
    while (!databasesSpan.IsEmpty)
    {
        int newlineIndex = databasesSpan.IndexOf('\n');
        if (newlineIndex == -1)
        {
            newlineIndex = databasesSpan.Length;
        }

        ReadOnlySpan<char> database = databasesSpan[..newlineIndex].Trim();
        if (!database.IsEmpty)
        {
            outputFile.Write("-- START(");
            outputFile.Write(iCount);
            outputFile.WriteLine(")------------------------------------------------------------");
            outputFile.Write("USE ");
            outputFile.WriteLine(database);
            outputFile.WriteLine("GO");
            outputFile.WriteLine();
            outputFile.WriteLine(scriptContent);
            outputFile.WriteLine("GO");
            outputFile.Write("--   END(");
            outputFile.Write(iCount);
            outputFile.WriteLine(")------------------------------------------------------------");
            outputFile.WriteLine();
        }
        databasesSpan = databasesSpan[(newlineIndex + 1)..];
        iCount++;
    }

    Console.Write(outputFilePath);
    Console.WriteLine(" file created successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}