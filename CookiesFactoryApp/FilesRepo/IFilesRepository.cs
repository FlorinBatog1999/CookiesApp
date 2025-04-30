interface IFilesRepository
{
    public List<string> ReadFile(string inputPath);
    public void WriteFile(string inputPath, IEnumerable<string> inputContent);
    public string GetFilePath();

    public static void CreateFile(string inputPath){
        System.Console.WriteLine($"Create the file on the path {inputPath}...");
        System.IO.File.Create(inputPath);
    }

        
    public static void CheckFileExistance(string[] listOfFiles, string filePath){
        System.Console.WriteLine($"Check the file existance...");
        if (listOfFiles.Length==0)
        {
            System.Console.WriteLine("The list of files is empty");
            CreateFile(filePath);
        }
        bool IsFileFound=false;
        foreach (var currentFile in listOfFiles)
        {
            if (currentFile.Trim().Equals(filePath))
            {
                IsFileFound=true;
                break;
            }
        }
        if(IsFileFound==true) 
        {
            System.Console.WriteLine("The file with recipes exists");
        }
        else 
        {
            System.Console.WriteLine("The file with recipes does not exist. Start to create it.");
            CreateFile(filePath);
        }    
    }


}