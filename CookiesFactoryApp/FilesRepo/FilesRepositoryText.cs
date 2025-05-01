
public class FilesRepositoryText : IFilesRepository
{

    public string GetFilePath()
    {
        return UserOptionsRepository.FILEPATHTEXT;
    }

    public List<string> ReadFile(string inputPath){
        System.Console.WriteLine($"Read the file from the path {inputPath}...");
        var content=System.IO.File.ReadAllText(inputPath).Split(Environment.NewLine).ToList();
        content=content.Where(x=>String.IsNullOrEmpty(x) is false).ToList();
        return content;
    }

    public void WriteFile(string inputPath, IEnumerable<string> inputContent){
        System.Console.WriteLine($"Write the file at the path {inputPath}...");
        var contentToString=String.Join(Environment.NewLine,inputContent);
        System.IO.File.WriteAllText(inputPath,contentToString);
    }


}