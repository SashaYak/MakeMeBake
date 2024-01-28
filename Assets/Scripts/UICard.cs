using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UICard : MonoBehaviour {

    public CardType Type;

    public Image TargetImage;
    public Button TargetButton;
    public bool Selected = false;

    public Card UsedCard;
    public GameObject SelectedIndicator;

    public GameObject Correct;
    public GameObject Wrong;


    public void Prepare() {
        TargetImage = this.gameObject.GetComponent<Image>();
        TargetButton = this.gameObject.GetComponent<Button>();
        Clear();
    }


    public void SetCard(Card card, bool isCorrect=false) {
        this.UsedCard = card;
        this.TargetImage.sprite = card.CardImage;
        CheckCorrect(isCorrect);
        Debug.Log(isCorrect + " " + card.Type.Name);
    }

    public void Select() {

        if (!Selected && GameManager.Instance.GetIngridientsCount() > 2)
        {
            // Can't choose more ingridients
            SoundManager.PlayBackSound();
        }
        else

        {
            Selected = !Selected;
            if (SelectedIndicator != null)
            {
                SelectedIndicator.SetActive(Selected);
            }
            if (Selected)
            {
                GameManager.Instance.SelectIngredient(UsedCard.Type);
                SoundManager.PlayTakeCardSound();
            }
            else
            {
                GameManager.Instance.DeselectIngredient(UsedCard.Type);
                SoundManager.PlayBackSound();
            }
        }

    }

    public void CheckCorrect(bool isCorrect) {
        if (Wrong != null && Correct != null) {
            if (isCorrect) {
                Correct.SetActive(true);
                Wrong.SetActive(false);
            } else {
                Correct.SetActive(false);
                Wrong.SetActive(true);
            }
        }
    }

    public void Clear() {
        Selected = false;
        if (Wrong != null) {
            Wrong?.SetActive(false);

        }
        if (Correct != null) {
            Correct?.SetActive(false);

        }
        if (SelectedIndicator != null) {
            SelectedIndicator?.SetActive(false);

        }
    }




    public enum CardType {
        selectable,
        result
    }

}


