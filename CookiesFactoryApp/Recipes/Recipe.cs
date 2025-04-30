class Recipe: IRecipe
{

    FilesRepositoryText filesRepositoryText;
    FilesRepositoryJSON filesRepositoryJSON;


    public List<string> GetRecipes()
    {
        var recipesList=new List<string>();
        if(UserOptionsRepository.USERFILEOPTION==0)
        {
            recipesList=filesRepositoryText.ReadFile(UserOptionsRepository.FILEPATHTEXT);
            recipesList=recipesList.Where(x=>String.IsNullOrEmpty(x) is false).ToList();
        }
        else{
            recipesList=filesRepositoryJSON.ReadFile(UserOptionsRepository.FILEPATHJSON);
        }

        return recipesList;
    }

    public void PrintRecipes(List<string> listOfRecipes){
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
    
    public void WriteRecipes(List<string> listOfRecipes)
    {
        if(UserOptionsRepository.USERFILEOPTION==0){
            filesRepositoryText.WriteFile(UserOptionsRepository.FILEPATHTEXT,listOfRecipes);
        } 
        else
        {
            filesRepositoryJSON.WriteFile(UserOptionsRepository.FILEPATHJSON,listOfRecipes);
        }
    }

}