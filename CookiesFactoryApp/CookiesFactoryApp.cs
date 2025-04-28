
class CookiesFactoryApp
{
    public void Run()
    {
        UserOptionsRepository.ShowUserOption();

        var listOfFiles=UserOptionsRepository.GeFiles();

        string filePath=FilesRepository.GetFilePath();

        FilesRepository.CheckFileExistance(listOfFiles,filePath);

        //FilesRepository.ReadFile(UserOptionsRepository.USERFILEOPTION);

        var userInput=GetTypedUserContent();

        if (!int.TryParse(userInput,out int defaultValue))
        {
            System.Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
        }
        else{
            System.Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

            // System.Console.WriteLine("Start to print the available ingredients...");
            IngredientsFactory.PrintIngredients();

            System.Console.WriteLine("Get the ingredients from the database...");
            var listOfIngredients=IngredientsFactory.GetIngredients();
            
            System.Console.WriteLine("Get recipes...");
            var listOfRecipes=Recipe.GetRecipes();
            
            System.Console.WriteLine("Start to print the recipes...");
            Recipe.PrintRecipes(listOfRecipes);
            
            System.Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
            Recipe.AddRecipe(userInput,listOfRecipes,listOfIngredients);
            
            System.Console.WriteLine("Print the list after inserting the new recipe");
            Recipe.PrintRecipes(listOfRecipes);
            Recipe.WriteRecipes(listOfRecipes);
            
        }
        Exit();
    }

    public void Exit(){
        System.Console.WriteLine("The cookies factory app finished. Press any key to exit.");
        Console.ReadKey();
    }

    public string GetTypedUserContent(){
        System.Console.WriteLine("Type the ingredient ID.");
        return Console.ReadLine();
    }
}