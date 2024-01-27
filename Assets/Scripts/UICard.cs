using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICard : MonoBehaviour {

    public CardType Type;

    public Image TargetImage;
    public bool Selected = false;

    public Card UsedCard;
    public GameObject SelectedIndicator;

    public GameObject Correct;
    public GameObject Wrong;

    private void Awake() {
        Selected = false;
    }


    public void SetCard(Card card) {
        this.UsedCard = card;
        this.TargetImage.sprite = card.CardImage;

    }

    public void Select() {
        Selected = !Selected;
        if (Selected) {
            GameManager.Instance.SelectIngredient(UsedCard.Type);
        } else {
            GameManager.Instance.DeselectIngredient(UsedCard.Type);
        }
        SelectedIndicator.SetActive(Selected);
    }

    public void CheckCorrect() {
        if (UsedCard.Type.isCorrect) {
            Correct.SetActive(true);
            Wrong.SetActive(false);
        } else {
            Correct.SetActive(false);
            Wrong.SetActive(true);
        }
    }


    public enum CardType {
        selectable,
        result
    }

}


