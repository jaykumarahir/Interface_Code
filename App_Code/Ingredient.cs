using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ingredient
/// </summary>
public class Ingredient
{
    // Properties >>
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string UnitMeasure { get; set; }

    // Constructors >>
    public Ingredient(string name, int quantity, string unitMeasure)
    {
        Name = name;
        Quantity = quantity;
        UnitMeasure = unitMeasure;
    }

    public Ingredient()
    {
        // Default Constructor
    }
}