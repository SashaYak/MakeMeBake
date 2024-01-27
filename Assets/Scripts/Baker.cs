using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baker : MonoBehaviour {
    public Image[] Targets;
    public GameObject[] TargetHolder;
    public UICard[] ResultCards; 

    public void BakeCake(Cake cake) {

        float xPosition = 0;
        float yPosition = 0;

        for (int i = 0; i < cake.Ingredients.Count; i++) {
            TargetHolder[i].SetActive(true);

            Card card = GameManager.Instance.GetCard(cake.Ingredients[i]);
            Targets[i].sprite = card.CakeImage;

            xPosition += card.BottomDistance();

            //Todo set position

            xPosition += card.TopDistance();
            yPosition += card.HeightDistance();


        }
    }
}
