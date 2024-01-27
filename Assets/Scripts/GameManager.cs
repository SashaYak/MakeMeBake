using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    #region Selection
    public List<Ingredient> Ingredients = new List<Ingredient>();

    public void Prepare() {
        Ingredients.Clear();
    }

    public void SelectIngredient(Ingredient ingredient) {
        Ingredients.Add(ingredient);
    }

    public void DeselectIngredient(Ingredient ingredient) {
        Ingredients.Remove(ingredient);
    }

    #endregion

    #region Create List

    public List<Cake> Cakes = new List<Cake>();
    Cake workingCake;

    public void StoreCake() {
        workingCake = new Cake(Ingredients);
    }

    public void NameCake(string name) {
        workingCake.Name = name;
        Cakes.Add(workingCake);
    }

    #endregion


    #region Create Cake

    public Cake ActiveCake;

    public void PrepareCake() {
        int rnd = Random.Range(0, Cakes.Count);
        SetActiveCake(Cakes[rnd]);
    }

    public void SetActiveCake(Cake cake) {
        ActiveCake = cake;
    }

    public void CompareCake() {
        Cake currentCake = new Cake(Ingredients);
        int errors = ActiveCake.Compare(currentCake);

        if (errors==0) {
            // WIN
        } else {
            //  X errors
        }
    }

    #endregion


}
