
public class CookiesFactoryApp
{
    IFilesRepository filesRepository;
    Recipe recipe;

    public CookiesFactoryApp(IFilesRepository filesRepository, Recipe recipe)
    {
        this.filesRepository=filesRepository;
        this.recipe=recipe;
    }
    public void Run()
    {
        UserOptionsRepository.PrintMessage($"User file option: {UserOptionsRepository.USERFILEOPTION}");

        var listOfFiles=UserOptionsRepository.GeFiles();

        string filePath=filesRepository.GetFilePath();

        filesRepository.CheckFileExistance(listOfFiles,filePath);

        UserOptionsRepository.PrintMessage("Type the ingredient ID.");

        var userInput=UserOptionsRepository.GetTypedUserContent();

        if (!int.TryParse(userInput,out int defaultValue))
        {
            UserOptionsRepository.PrintMessage("No ingredients have been selected. Recipe will not be saved.");
        }
        else{
            UserOptionsRepository.PrintMessage("Create a new cookie recipe! Available ingredients are:"); 
            IngredientsFactory.PrintIngredients();
            var listOfIngredients=IngredientsFactory.GetIngredients();
            var listOfRecipes=recipe.GetRecipes(filePath);
            recipe.PrintRecipes(listOfRecipes);
            recipe.AddRecipe(userInput,listOfRecipes,listOfIngredients);
            recipe.PrintRecipes(listOfRecipes);
            recipe.WriteRecipes(listOfRecipes, filePath);
        }
        UserOptionsRepository.Exit();
    }


}