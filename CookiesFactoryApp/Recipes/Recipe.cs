static class Recipe
{
    public static List<string> GetRecipes()
    {
        var recipesList=new List<string>();
        if(UserOptionsRepository.USERFILEOPTION==0)
        {
            recipesList=FilesRepositoryText.ReadTextFile(UserOptionsRepository.FILEPATHTEXT).Split(Environment.NewLine).ToList();
            recipesList=recipesList.Where(x=>String.IsNullOrEmpty(x) is false).ToList();
        }
        else{
            recipesList=FilesRepositoryJSON.ReadJSONFile(UserOptionsRepository.FILEPATHJSON);
        }

        return recipesList;
    }

    public static void PrintRecipes(List<string> listOfRecipes){
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

    public static List<string> AddRecipe(string userInput,List<string> recipesList, List<Ingredient> listOfIngredients){
        var maxID=GetMaxID(listOfIngredients);
        List<string> newRecipe=new List<string>();

        while(int.TryParse(userInput,out int defaultValue)){
            System.Console.WriteLine($"user input: {userInput}");
            if (Convert.ToInt32(userInput)<0 || Convert.ToInt32(userInput)>maxID)
            {
                Console.WriteLine("Try again!");
                userInput=Console.ReadLine();
                continue;
            }
            userInput=userInput.Replace(Environment.NewLine,String.Empty).Trim();
            newRecipe.Add(userInput);
            userInput=Console.ReadLine();
        }
        System.Console.WriteLine($"Recipe added:{String.Join(",",newRecipe)}");
        recipesList.Add(String.Join(",",newRecipe));
        return recipesList;
    }

    public static int GetMaxID(List<Ingredient> ingredients){
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
    
    public static void WriteRecipes(List<string> listOfRecipes)
    {
        if(UserOptionsRepository.USERFILEOPTION==0){
            FilesRepositoryText.WriteTextFile(UserOptionsRepository.FILEPATHTEXT,listOfRecipes);
        } 
        else
        {
            FilesRepositoryJSON.WriteJSONFile(UserOptionsRepository.FILEPATHJSON,listOfRecipes);
        }
    }

}