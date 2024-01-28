using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card {

    public Ingredient Type;
    public Sprite CardImage;
    public Sprite CakeImage;

    public PositionType Bottom;
    public PositionType Top;
    public PositionType HeightBottom;
    public PositionType HeightTop;


    public float BottomDistance() {
        return bottomDistance(Bottom);
    }

    static float bottomDistance(PositionType type) {
        float returnValue = 0;

        switch (type) {
            case PositionType.zero:
                returnValue = -150f;
                break;
            case PositionType.one:
                returnValue = -75f;
                break;
            case PositionType.two:
                returnValue = 0f;
                break;
            case PositionType.three:
                returnValue = 75f;
                break;
            case PositionType.four:
                returnValue = 150f;
                break;
            default:
                break;
        }

        return returnValue;
    }

    public float TopDistance() {
        return bottomDistance(Top);
    }
 

    public float HeightBottomDistance() {
       return heightBottomDistance(HeightBottom);
    }

    static float heightBottomDistance(PositionType type)
    {
        float returnValue = 0;

        switch (type)
        {
            case PositionType.zero:
                returnValue = 0f;
                break;
            case PositionType.one:
                returnValue = -50f;
                break;
            case PositionType.two:
                returnValue = -150f;
                break;
            case PositionType.three:
                returnValue = -250f;
                break;
            case PositionType.four:
                returnValue = -300f;
                break;
            default:
                break;
        }

        return returnValue;
    }



    public float HeightTopDistance()
    {
        return heightTopDistance(HeightTop);
    }
    static float heightTopDistance(PositionType type)
    {
        float returnValue = 0;

        switch (type)
        {
            case PositionType.zero:
                returnValue = 0f;
                break;
            case PositionType.one:
                returnValue = 50f;
                break;
            case PositionType.two:
                returnValue = 150f;
                break;
            case PositionType.three:
                returnValue = 250f;
                break;
            case PositionType.four:
                returnValue = 300f;
                break;
            default:
                break;
        }

        return returnValue;
    }

}


public enum PositionType
{
    zero,
    one,
    two, 
    three,
    four
}