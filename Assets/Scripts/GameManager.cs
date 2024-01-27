using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public Card[] Cards;

    Dictionary<string, Card> cardDictionary;



    private void Awake() {
        if (Instance==null) {
            Instance = this;
        } else {
            Destroy(this);
        }
        cardDictionary = new Dictionary<string, Card>();
        foreach (Card card in Cards) {
            cardDictionary.Add(card.Type.Name, card);
        }
    }


    public Card GetCard(Ingredient ingredient) {
        return cardDictionary[ingredient.Name];
    }


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
        Ingredient newIngredient = ingredient.Copy();
        Ingredients.Add(newIngredient);
    }

    public void DeselectIngredient(Ingredient selected) {
        foreach (Ingredient ingredient in Ingredients) {
            if (ingredient.IsEqual(selected)) {
                Ingredients.Remove(ingredient);
            }
        }
    }

    #endregion

    #region Create List

    public void StartListCreation() {
        workingCake = null;
        Ingredients.Clear();
        //Show UI
    }

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

    public void StartCakeCreation() {
        PrepareCake();
        Ingredients.Clear();
        //UI?
    }

    public void PrepareCake() {
        int rnd = Random.Range(0, Cakes.Count);
        SetActiveCake(Cakes[rnd]);
    }

    public void SetActiveCake(Cake cake) {
        ActiveCake = cake;
    }

    public void CompareCake() {
        Cake currentCake = new Cake(Ingredients);
        int errors = currentCake.Compare(ActiveCake);

        if (errors==0) {
            // WIN
        } else {
            //  X errors
        }
    }

    #endregion


}
