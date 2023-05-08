namespace AdressBook.Services;

internal class FileService
{
    public void Save(string filePath, string content)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(content);
    }

    public string Read1(string filepath, Models.Contact? contact)
    {
        try
        {
            using var sr = new StreamReader(filepath);
            return sr.ReadToEnd();
        }
        catch { return null!; }
    }
}
