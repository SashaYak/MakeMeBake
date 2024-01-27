using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card {

    public Ingredient Type;
    public Sprite CardImage;
    public Sprite CakeImage;

    public BottomType Bottom;
    public TopType Top;
    public HeightType Height;


    public float BottomDistance() {
        return bottomDistance(Bottom);
    }

    static float bottomDistance(BottomType type) {
        float returnValue = 0;

        switch (type) {
            case BottomType.left:
                break;
            case BottomType.middle:
                break;
            case BottomType.right:
                break;
            default:
                break;
        }

        return returnValue;
    }

    public float TopDistance() {
        return topDistance(Top);
    }

    static float topDistance(TopType type) {
        float returnValue = 0;

        switch (type) {
            case TopType.left:
                break;
            case TopType.middle:
                break;
            case TopType.right:
                break;
            default:
                break;
        }

        return returnValue;
    }

    public float HeightDistance() {
        return heightDistance(Height);
    }

    static float heightDistance(HeightType type) {
        float returnValue = 0;

        switch (type) {
            case HeightType.zero:
                break;
            case HeightType.medium:
                break;
            case HeightType.high:
                break;
            default:
                break;
        }

        return returnValue;
    }

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

public enum HeightType {
    zero,
    medium,
    high
}