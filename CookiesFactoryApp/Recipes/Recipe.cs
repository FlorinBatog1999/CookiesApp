public class Recipe: IRecipe
{
    IFilesRepository filesRepository;
    
    public Recipe(IFilesRepository filesRepositoryParam)
    {
        this.filesRepository=filesRepositoryParam;
    }


    public List<string> GetRecipes(string filePath)
    {
        UserOptionsRepository.PrintMessage("Get recipes...");
        var recipesList=new List<string>();
        
        // if(UserOptionsRepository.USERFILEOPTION==0)
        // {
        //     recipesList=filesRepository.ReadFile(UserOptionsRepository.FILEPATHTEXT);
        // }
        // else{
        //     recipesList=filesRepository.ReadFile(UserOptionsRepository.FILEPATHJSON);
        // }

        recipesList=filesRepository.ReadFile(filePath);

        return recipesList;
    }

    public void PrintRecipes(List<string> listOfRecipes){
        UserOptionsRepository.PrintMessage("Start to print the recipes...");
        int recipeCounter=1;
        foreach (var recipe in listOfRecipes)
        {
            System.Console.WriteLine($"***{recipeCounter}***");
            var listOfIngredientsIDs=recipe.Split(",").ToList();
            foreach (var ingredientID in listOfIngredientsIDs)
            {
                var currentIngredient=IngredientsFactory.GetIngredientByID(Convert.ToInt32(ingredientID));
                currentIngredient.Describe();
            }
            recipeCounter++;   
        }
    }

    public List<string> AddRecipe(string userInput,List<string> recipesList, List<Ingredient> listOfIngredients){
        UserOptionsRepository.PrintMessage("Add an ingredient by its ID or type anything else if finished.");
        
        var maxID=GetMaxID(listOfIngredients);
        List<string> newRecipe=new List<string>();

        while(int.TryParse(userInput,out int defaultValue)){
            System.Console.WriteLine($"user input: {userInput}");
            if (Convert.ToInt32(userInput)<0 || Convert.ToInt32(userInput)>maxID)
            {
                Console.WriteLine("Try again!");
                userInput=UserOptionsRepository.GetTypedUserContent();
                continue;
            }
            userInput=userInput.Replace(Environment.NewLine,String.Empty).Trim();
            newRecipe.Add(userInput);
            userInput=UserOptionsRepository.GetTypedUserContent();
        }
        System.Console.WriteLine($"Recipe added:{String.Join(",",newRecipe)}");
        recipesList.Add(String.Join(",",newRecipe));
        return recipesList;
    }

    public int GetMaxID(List<Ingredient> ingredients){
        System.Console.WriteLine("Get the mximum ID from the ingredients database...");
        int MaxValue=0;
        foreach (var ingredient in ingredients)
        {
            if (Convert.ToInt32(ingredient.ID)>MaxValue)
            {
                MaxValue=Convert.ToInt32(ingredient.ID);
            }
        }
        System.Console.WriteLine($"The maximum ID value is {MaxValue}");
        return MaxValue;
    }
    
    public void WriteRecipes(List<string> listOfRecipes, string filePath)
    {
        // if(UserOptionsRepository.USERFILEOPTION==0){
        //     filesRepository.WriteFile(UserOptionsRepository.FILEPATHTEXT,listOfRecipes);
        // } 
        // else
        // {
        //     filesRepository.WriteFile(UserOptionsRepository.FILEPATHJSON,listOfRecipes);
        // }
        filesRepository.WriteFile(filePath,listOfRecipes);
    }

}