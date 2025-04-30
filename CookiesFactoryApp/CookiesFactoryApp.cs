
class CookiesFactoryApp
{
    Recipe recipe=new Recipe();
    public void Run()
    {
        UserOptionsRepository.ShowUserOption();

        var listOfFiles=UserOptionsRepository.GeFiles();

        string filePath=UserOptionsRepository.USERFILEOPTION==0 ? new FilesRepositoryText().GetFilePath() : new FilesRepositoryJSON().GetFilePath();

        FilesRepository.CheckFileExistance(listOfFiles,filePath);

        var userInput=UserOptionsRepository.GetTypedUserContent();

        if (!int.TryParse(userInput,out int defaultValue))
        {
            System.Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
        }
        else{
            System.Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

            IngredientsFactory.PrintIngredients();

            System.Console.WriteLine("Get the ingredients from the database...");
            var listOfIngredients=IngredientsFactory.GetIngredients();
            
            System.Console.WriteLine("Get recipes...");
            var listOfRecipes=recipe.GetRecipes();
            
            System.Console.WriteLine("Start to print the recipes...");
            recipe.PrintRecipes(listOfRecipes);
            
            System.Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
            recipe.AddRecipe(userInput,listOfRecipes,listOfIngredients);
            
            System.Console.WriteLine("Print the list after inserting the new recipe");
            recipe.PrintRecipes(listOfRecipes);
            recipe.WriteRecipes(listOfRecipes);
            
        }
        UserOptionsRepository.Exit();
    }


}