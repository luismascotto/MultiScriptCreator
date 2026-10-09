# MultiScriptCreator

When you need to run the same SQL script in several databases on the same server.

## ScriptCreator

A tool that generates a multi-database SQL script from a list of database names.

### Usage

```bash
ScriptCreator [-d databases.txt] [-s script.sql] [-o output.sql]
```

- `-d`: Path to file containing database names (one per line). Default: `databases.txt`
- `-s`: Path to SQL script to execute. Default: `script.sql`
- `-o`: Output file path. Default: `output.sql`

The tool reads database names from the databases file and generates a combined SQL script that executes the input script against each database using `USE <database>` statements.

## License

MIT License - see [LICENSE](LICENSE) file for details.