using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public UIScreen[] Screens;

    List<UIScreen> activeScreens = new List<UIScreen>();
    Dictionary<ScreenName, UIScreen> usedScreens = new Dictionary<ScreenName, UIScreen>();

    private void Awake() {
        foreach (UIScreen screen in Screens) {
            usedScreens.Add(screen.Name, screen);
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ActivateScreen(ScreenName name ) {

        foreach (UIScreen screen in activeScreens) {
            DeactivateScreen(screen.Name);
        }
        activeScreens.Clear();

        if (usedScreens[name].ParentScreen!= ScreenName.empty) {
            ActivateScreen(usedScreens[name].ParentScreen);
        }

        foreach (GameObject gameObject in usedScreens[name].ScreenElements) {
            gameObject.SetActive(true);
        }

    }

    public void DeactivateScreen(ScreenName name) {
        foreach (GameObject gameObject in usedScreens[name].ScreenElements) {
            gameObject.SetActive(false);
        }
    }
}

public class UIScreen {

    public ScreenName Name;
    public GameObject[] ScreenElements;
    public ScreenName ParentScreen = ScreenName.empty;


}


public enum ScreenName {
    empty,
    StartScreen,
    Endscreen,
    Credits,
    Player1Screen,
    Player2Screen,
    CakeScreen
}