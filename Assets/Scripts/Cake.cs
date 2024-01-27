using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cake {

    public string Name;

    public Cake(List<Ingredient> ingredients) {
        Ingredients = ingredients;
    }

    public int NumberOfIngredients {
        get {
            return Ingredients.Count;
        }
    }
    public List<Ingredient> Ingredients = new List<Ingredient>();

    public void AddIngredient(Ingredient ingredient) {
        Ingredients.Add(ingredient);
    }

    public int Compare(Cake cake) {
        int returnValue = 0;

        foreach (Ingredient ingredient in cake.Ingredients) {
            if (!Ingredients.Contains(ingredient)) {
                returnValue++;
            }
        }
        return returnValue;
    }

}
