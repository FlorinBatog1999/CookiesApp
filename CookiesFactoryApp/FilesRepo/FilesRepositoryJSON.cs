using System.Text.Json;

class FilesRepositoryJSON
{
    
    public static List<string> ReadJSONFile(string inputPath){
        System.Console.WriteLine($"Read the file from the path {inputPath}...");
        var content=System.IO.File.ReadAllText(inputPath);
        if(content.Length==0){
            return new List<string>();
        }
        else return JsonSerializer.Deserialize<List<string>>(content);
    }

    public static void WriteJSONFile(string inputPath, IEnumerable<string> inputContent){
        System.Console.WriteLine($"Write the file at the path {inputPath}...");
        var contentToString=JsonSerializer.Serialize(inputContent);
        System.IO.File.WriteAllText(inputPath,contentToString);
    }


}