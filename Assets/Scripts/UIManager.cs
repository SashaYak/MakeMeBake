using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public static UIManager Instance;


    public UIScreen[] Screens;

    public UICard[] SelectionCards;

    public Baker Baker;


    public Button[] NextButtons;

    public TMP_InputField TextInput;

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

        ActivateScreen(1);
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ActivateScreen(int screenName) {
        ActivateScreen((ScreenName)screenName);
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
        TextInput.text = "";

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
    Endscreen,
    Credits,
    Player1ScreenPrepare,
    Player1ScreenName,
    Player2Screen,
    CakeScreen
}