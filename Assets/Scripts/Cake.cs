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

        for (int i = 0; i < Ingredients.Count; i++) {
            int add = 1;
            for (int j = 0; j < cake.Ingredients.Count; j++) {
                if (cake.Ingredients[j].Name== Ingredients[i].Name) {
                    add = 0;
                    Ingredients[i].isCorrect = true;
                }
            }
            returnValue += add;
        }
        return returnValue;
    }

}
