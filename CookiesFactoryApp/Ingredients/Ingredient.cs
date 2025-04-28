class Ingredient
{
   public int ID;
   public string name;
   public string preparationInstructions="Make what you want.";

    public Ingredient(string nameParam)
    {
        name=nameParam;
    }

    public virtual void Describe() => System.Console.WriteLine($"{this.name}. {this.preparationInstructions}"); 
}