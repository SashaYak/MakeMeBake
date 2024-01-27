using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient {
    public string Name;
    public bool isCorrect = false;


    public Ingredient Copy() {
        Ingredient ingredient = new Ingredient();
        ingredient.Name = this.Name;
        ingredient.isCorrect = false;

        return ingredient;
    }

    public bool IsEqual(Ingredient ingredient) {
        return this.Name == ingredient.Name;
    }
}
