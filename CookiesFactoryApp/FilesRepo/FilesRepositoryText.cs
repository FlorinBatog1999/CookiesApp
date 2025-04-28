class FilesRepositoryText
{
     public static string ReadTextFile(string inputPath){
        System.Console.WriteLine($"Read the file from the path {inputPath}...");
        return System.IO.File.ReadAllText(inputPath);
    }

    public static void WriteTextFile(string inputPath, IEnumerable<string> inputContent){
        System.Console.WriteLine($"Write the file at the path {inputPath}...");
        var contentToString=String.Join(Environment.NewLine,inputContent);
        System.IO.File.WriteAllText(inputPath,contentToString);
    }
}