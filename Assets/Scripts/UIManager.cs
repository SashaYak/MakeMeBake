using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public static UIManager Instance;


    public UIScreen[] Screens;

    public UICard[] SelectionCards;
    public UICard[] GuessingCards;


    public UICard[] ChosenCards;
    public UICard[] ResultCards;



    public Baker Baker;


    public Button[] NextButtons;

    public TMP_InputField TextInput;

    public TMP_Text CakeName;
    public TMP_Text CakeName2;

    List<UIScreen> activeScreens = new List<UIScreen>();
    Dictionary<ScreenName, UIScreen> usedScreens;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
            return;
        }

        usedScreens = new Dictionary<ScreenName, UIScreen>();

        foreach (UIScreen screen in Screens) {
            usedScreens.Add(screen.Name, screen);
        }

        ActivateScreen(2);
    }

    // Start is called before the first frame update
    void Start() {
        Card[] cards = GameManager.Instance.Cards;
        for (int i = 0; i < cards.Length; i++) {
            SelectionCards[i].Prepare();
            SelectionCards[i].SetCard(cards[i]);
            GuessingCards[i].Prepare();
            GuessingCards[i].SetCard(cards[i]);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public void ActivateScreen(int screenName) {
        ActivateScreen((ScreenName)screenName);
        Debug.Log(screenName);
    }

    public void ActivateScreen(ScreenName name ) {

        foreach (UIScreen screen in activeScreens) {
            DeactivateScreen(screen.Name);
        }
        activeScreens.Clear();

        activeScreens.Add(usedScreens[name]);

        if (usedScreens[name].ParentScreen!= ScreenName.empty) {
            ActivateScreen(usedScreens[name].ParentScreen);
        }

        foreach (GameObject gameObject in usedScreens[name].ScreenElements) {
            gameObject.SetActive(true);
        }

        Clear();
    }

    public void DeactivateScreen(ScreenName name) {
        foreach (GameObject gameObject in usedScreens[name].ScreenElements) {
            gameObject.SetActive(false);
        }
    }

    public void Clear() {
        foreach (UICard card in SelectionCards) {
            card.Clear();
        }
        foreach (UICard card in GuessingCards) {
            card.Clear();
        }
    }


    public void SetChosenCards(Cake cake) {
        for (int i = 0; i < ChosenCards.Length; i++) {
            ChosenCards[i].Prepare();
            ChosenCards[i].SetCard(GameManager.Instance.GetCard(cake.Ingredients[i]));
        }
    }


    public void SetResultCards(Cake cake) {
        for (int i = 0; i < ResultCards.Length; i++) {
            ResultCards[i].Prepare();
            ResultCards[i].SetCard(GameManager.Instance.GetCard(cake.Ingredients[i]), cake.Ingredients[i].isCorrect);
        }
    }


    public void ClearTextInput() {
        TextInput.text = "";
    }


    public void SetCakeName(string cakeName) {
        CakeName.text = cakeName;
        CakeName2.text = cakeName;
        Debug.Log(cakeName);
    }

    public void AllowNext(bool allowed=false) {
        foreach (Button button in NextButtons) {
            button.interactable = allowed;
        }
    }
}

[System.Serializable]
public class UIScreen {

    public ScreenName Name;
    public GameObject[] ScreenElements;
    public ScreenName ParentScreen = ScreenName.empty;
    

}

[System.Serializable]
public enum ScreenName {
    empty,
    StartScreen,
    TitleScreen,
    Credits, //not yet used
    Player1ScreenPrepare,
    Player1ScreenName,
    Player2Screen,
    CakeScreen
}