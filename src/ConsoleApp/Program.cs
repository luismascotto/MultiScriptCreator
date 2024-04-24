using Microsoft.Extensions.Configuration;

var ConfigCommandLine = new ConfigurationBuilder()
                            .AddCommandLine(args, new Dictionary<string, string>()
                            {
                                { "-d", "d" },
                                { "-s", "s" },
                                { "-o", "o" },
                            })
                            .Build();



string databasesFilePath = "databases.txt";
string scriptFilePath = "script.sql";
string outputFilePath = "output.sql";

if (!string.IsNullOrWhiteSpace(ConfigCommandLine["d"]))
{
    databasesFilePath = ConfigCommandLine["d"]!;
}
if (!string.IsNullOrWhiteSpace(ConfigCommandLine["s"]))
{
    scriptFilePath = ConfigCommandLine["s"]!;
}
if (!string.IsNullOrWhiteSpace(ConfigCommandLine["o"]))
{
    outputFilePath = ConfigCommandLine["o"]!;
}

try
{
    ReadOnlySpan<char> databasesSpan = File.ReadAllText(databasesFilePath).AsSpan();
    string scriptContent = File.ReadAllText(scriptFilePath);

    using (var outputFile = new StreamWriter(outputFilePath))
    {
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
                outputFile.WriteLine($"-- START({iCount})------------------------------------------------------------");
                outputFile.WriteLine($"USE {database}");
                outputFile.WriteLine("GO");
                outputFile.WriteLine();
                outputFile.WriteLine(scriptContent);
                outputFile.WriteLine("GO");
                outputFile.WriteLine($"--   END({iCount})------------------------------------------------------------");
                outputFile.WriteLine();
            }
            databasesSpan = databasesSpan[(newlineIndex + 1)..];
            iCount++;
        }
    }

    Console.WriteLine($"{outputFilePath} file created successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}