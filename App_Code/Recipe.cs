using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Recipe
/// </summary>
public class Recipe
{
    // Instance Variables >>
    private Ingredient[] ingredients = new Ingredient[15];
    // Properties >>
    public string Name { get; set; }
    public string SubmittedBy { get; set; }
    public string Category { get; set; }
    public int CookingTime { get; set; }
    public int NumServings { get; set; }
    public string Description { get; set; }

    // Constructors >>
    public Recipe(string name, string submittedBy, string category,
        int cookingTime, int numServings, string description)
    {
        Name = name;
        SubmittedBy = submittedBy;
        Category = category;
        CookingTime = cookingTime;
        NumServings = numServings;
        Description = description;
    }

    public Recipe()
    {
        // Default Constructor
    }

    // Instance Methods >>
    public void addIngredient(Ingredient myIngredient)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i] == null)
            {
                ingredients[i] = myIngredient;
                break;
            }
        }
    }

    public Ingredient getIngredient(int index)
    {
        return ingredients[index];
    }

    public Ingredient[] allIngredients()
    {
        return ingredients;
    }
}