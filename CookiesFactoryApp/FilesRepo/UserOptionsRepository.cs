class UserOptionsRepository
{
    public const FileType USERFILEOPTION=FileType.JSON;
    public const string FOLDERPATH="C:\\Users\\User\\Desktop\\Cookies Factory app(old version)\\CookiesFactoryApp\\CookiesFactoryApp\\Recipes";

    public const string FILEPATHTEXT=$"{FOLDERPATH}\\recipes.txt";
    public const string FILEPATHJSON=$"{FOLDERPATH}\\recipes.json";

    public static string[] GeFiles(){
        return System.IO.Directory.GetFiles(UserOptionsRepository.FOLDERPATH);
    }

    public static void PrintMessage(string message) => System.Console.WriteLine(message);

    public static void Exit(){
        System.Console.WriteLine("The cookies factory app finished. Press any key to exit.");
        Console.ReadKey();
    }

    public static string GetTypedUserContent(){
        return Console.ReadLine();
    }

}