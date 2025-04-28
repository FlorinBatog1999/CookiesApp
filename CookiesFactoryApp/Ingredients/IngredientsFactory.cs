class IngredientsFactory
{
    public static List<Ingredient> GetIngredients(){
        var listOfIngredients=new List<Ingredient>(){
            new Flour("Wheat flour"),
            new Flour("Coconut flour"),
            new Butter("Butter"),
            new Chocolate("Chocolate"),
            new Sugar("Sugar"),
            new Spice("Cardamom"),
            new Spice("Cinnamon"),
            new Powder("Cocoa powder"),
        };
        return listOfIngredients;
    }

    public static Ingredient GetIngredientByID(int ingredientID){
        var listOfIngredients=GetIngredients();
        Ingredient ingredient=null;
        foreach (var ingredientItem in listOfIngredients)
        {
            // System.Console.WriteLine("ID of current ingredient from collection: "+ingredientItem.ID);
            // System.Console.WriteLine("ID given as parameter: "+ingredientID);
            if (ingredientItem.ID==ingredientID)
            {
                ingredient=ingredientItem;
                break;                
            }
        }
        return ingredient;

    }

    public static void PrintIngredients(){
        foreach(var ingredientFromFile in GetIngredients()){
            ingredientFromFile.Describe();
        }
    }

}

