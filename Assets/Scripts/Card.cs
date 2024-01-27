using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card {

    public Ingredient Name;
    public Texture2D CardImage;
    public Texture2D CakeImage;


}

public enum BottomType {
    left, 
    middle,
    right
}

public enum TopType {
    left,
    middle,
    right
}

public enum HighType {
    zero,
    medium,
    high
}