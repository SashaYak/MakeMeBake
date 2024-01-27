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

        Cakes = new List<Cake>();
    }


    public Card GetCard(Ingredient ingredient) {
        return cardDictionary[ingredient.Name];
    }


    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.AllowNext(false);
        PrepareMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region  Main Menu

    public void PrepareMainMenu() {
        if (Cakes.Count>0) {
            UIManager.Instance.AllowNext(true);
        }
    }


    #endregion




    #region Selection




    List<Ingredient> Ingredients = new List<Ingredient>();




    public void SelectIngredient(Ingredient ingredient) {
        Ingredient newIngredient = ingredient.Copy();
        Ingredients.Add(newIngredient);

        if (Ingredients.Count == ingredCount) {
            UIManager.Instance.AllowNext(true);
        } else {
            UIManager.Instance.AllowNext(false);
        }
    }

    public void DeselectIngredient(Ingredient selected) {
        List<Ingredient> ingredientsToRemove = new List<Ingredient>();
        for (int i = 0; i < Ingredients.Count; i++) {
            if (Ingredients[i].IsEqual(selected)) {
                ingredientsToRemove.Add(Ingredients[i]);
            }
        }

        for (int i = 0; i < ingredientsToRemove.Count; i++) {
            Ingredients.Remove(ingredientsToRemove[i]);
        }

        foreach (Ingredient ingredient in Ingredients) {
            if (ingredient.IsEqual(selected)) {
                Ingredients.Remove(ingredient);
            }
        }
        if (Ingredients.Count == ingredCount) {
            UIManager.Instance.AllowNext(true);
        } else {
            UIManager.Instance.AllowNext(false);
        }
    }


    #endregion

    #region Create List

    int ingredCount = 3;



    public void PrepareSettingCake() {
        UIManager.Instance.ClearTextInput();
        Ingredients.Clear();
        UIManager.Instance.AllowNext(false);
        startListCreation(3);
    }

    void startListCreation(int ingredients=3) {
        workingCake = null;
        ingredCount = ingredients;
        //Show UI
    }

    public List<Cake> Cakes;
    Cake workingCake;

    public void StoreCake() {
        workingCake = new Cake(Ingredients);
        UIManager.Instance.AllowNext(false);
        UIManager.Instance.SetChosenCards(workingCake);

        Ingredients.Clear();
    }

    public void NameCake(string name) {
        workingCake.Name = name;
        //Debug.Log(name);
        UIManager.Instance.AllowNext(name.Length>3 && name.Length<20);

    }

    public void CakeNamed() {
        Cakes.Add(workingCake);
        //Debug.Log("NAMED" + workingCake.Name);
        workingCake = new Cake(Ingredients);
        PrepareMainMenu();
    }

    #endregion


    #region Create Cake

    public Cake ActiveCake;

    public void StartCakeCreation() {
        prepareCake();
        Ingredients.Clear();
        //UI?
    }

    void prepareCake() {
        int rnd = Random.Range(0, Cakes.Count);
        SetActiveCake(Cakes[rnd]);
        Debug.Log(ActiveCake.Name);
        UIManager.Instance.AllowNext(false);
        UIManager.Instance.SetCakeName(ActiveCake.Name);
    }

    public void SetActiveCake(Cake cake) {
        ActiveCake = cake;
    }

    public Cake currentCake;

    public void CompareCake() {
        currentCake = new Cake(Ingredients);
        int errors = currentCake.Compare(ActiveCake);

        UIManager.Instance.SetResultCards(currentCake);

        if (errors==0) {
            // WIN
        } else {
            //  X errors
        }
    }

    #endregion


}
