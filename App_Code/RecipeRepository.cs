using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RecipeRepository
/// </summary>
public class RecipeRepository
{
    public RecipeRepository()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public List<Recipe> getRecipes()
    {
        HttpApplication webApp = HttpContext.Current.ApplicationInstance;
        return (List<Recipe>)webApp.Application["recipes"];
    }
}