using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baker : MonoBehaviour {
    public Image[] Targets;
    public GameObject[] TargetHolder;
    public UICard[] ResultCards;
    public Image[] AuraTargets;
    public void BakeCake(Cake cake) {


        foreach (GameObject go in TargetHolder)
        {
            go.GetComponent<RectTransform>().localPosition = new Vector3(
                0f, 0f, 0f
                );
        }




        foreach(Image m in AuraTargets) 
        {
            m.enabled = false;
        }
         foreach(GameObject go in TargetHolder) 
        {
            go.SetActive(false);
        }



        int auraTargetsCount = 0;
        int counter = 0;

        for (int i = 0; i < cake.Ingredients.Count; i++) {

            Card card = GameManager.Instance.GetCard(cake.Ingredients[i]);
            if (card.Bottom == PositionType.zero && card.Top == PositionType.zero
                && card.HeightBottom == PositionType.zero && card.HeightTop == PositionType.zero)
            {
                AuraTargets[auraTargetsCount].enabled = true;
                AuraTargets[auraTargetsCount].sprite = card.CakeImage;
                auraTargetsCount++;
            }
            else
            {
                TargetHolder[counter].SetActive(true);
                Targets[counter].sprite = card.CakeImage;


                TargetHolder[counter].GetComponent<RectTransform>().localPosition = new Vector3(
                    TargetHolder[counter].GetComponent<RectTransform>().localPosition.x + card.BottomDistance(),
                    TargetHolder[counter].GetComponent<RectTransform>().localPosition.y + card.HeightBottomDistance(),
                    TargetHolder[counter].GetComponent<RectTransform>().localPosition.z
                    );

                if (i < 2)
                {
                    float newHightPos = TargetHolder[counter].GetComponent<RectTransform>().localPosition.y + card.HeightTopDistance();

                    TargetHolder[counter + 1].GetComponent<RectTransform>().localPosition = new Vector3(
                        TargetHolder[counter].GetComponent<RectTransform>().localPosition.x + card.TopDistance(),
                        newHightPos,
                        TargetHolder[counter + 1].GetComponent<RectTransform>().localPosition.z
                        );
                }
                counter++;
            }
        }
    }
}
