interface IRecipe
{
    public List<string> GetRecipes(string filePath);

    public void PrintRecipes(List<string> listOfRecipes);

    public List<string> AddRecipe(string userInput,List<string> recipesList, List<Ingredient> listOfIngredients);

    public int GetMaxID(List<Ingredient> ingredients);
    
    public void WriteRecipes(List<string> listOfRecipes, string filePath);

}