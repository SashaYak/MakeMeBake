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

    public GameObject buildingAnimation;

    public GameObject winAssets;
    public GameObject loseAssets;

    public TMP_Text PunTextWin;
    public TMP_Text PunTextLose;

    public List<string> losePuns;
    public List<string> winPuns;

    List<UIScreen> activeScreens = new List<UIScreen>();
    Dictionary<ScreenName, UIScreen> usedScreens;

    private void Awake() {
        TextInput.characterLimit = 19;


        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
            return;
        }

        usedScreens = new Dictionary<ScreenName, UIScreen>();

        foreach (UIScreen screen in Screens) {
            usedScreens.Add(screen.Name, screen);
            activeScreens.Add(screen);
        }

        ActivateScreen(2);


        losePuns = new List<string>
        {
            "What do you call a bakery with bad bread? A crumbling business.",
            "I was going to make a baking joke, but I didn’t have the whisk.",
            "Why was the baking sheet feeling sad? It had too many crepes in its life.",
            "It was a recipe for disaster.",
            "You burnt your bread, so I guess it’s toast now.",
            "Keep calm and bake on!",
            "I was going to tell a bread joke, but it’s a bit stale.",
            "I tried to convince the baker to go on a diet, but he just floured up and rolled away.",
            "I asked the baker to make me a loaf of bread with a Kickstarter theme. He said it would take some dough to get started."
        };

        winPuns = new List<string> 
        {
            "Life is what you bake it.",
            "I’m floured by your skills.",
            "This is my jam!",
            "This recipe is a piece of cake!",
            "Baking is a piece of cake for me, I loaf it.",
            "It was piece of cake!",
            "I asked the baker if he could make me a cake shaped like a guitar, but he said it would be a bit of a jam.",
            "Baking is my bread and butter.",
            "Baking is a piece of cake… or bread, or pie!"
        };
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
        SoundManager.PlayConfirmSound();
        
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

    public void BakeCake(Cake cake) 
    {
        PunTextWin.text = "";
        PunTextLose.text = "";
        buildingAnimation.SetActive(true);
        Baker.BakeCake(cake);
        Invoke("StopBuildingAnimation", 2f);
    }

    void StopBuildingAnimation() 
    {
        buildingAnimation.SetActive(false);
    }

    public void SetPun(bool win)
    {
        if (win)
        {
            winAssets.SetActive(true);
            loseAssets.SetActive(false);
            Invoke("ShowWinPun", 1f);
        }
        else
        {
            winAssets.SetActive(false);
            loseAssets.SetActive(true);
            Invoke("ShowLosePun", 1f);
        }
    }
    void ShowWinPun()
    {
        PunTextWin.text = winPuns[Random.Range(0, winPuns.Count)];
    }
    void ShowLosePun() 
    {
        Debug.Log("hhhere");
        PunTextLose.text = losePuns[Random.Range(0, losePuns.Count)];
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