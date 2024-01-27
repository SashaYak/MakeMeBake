using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour {

    public float IncreaseDuration = 1;
    public float Offset = 0;
    public float SizeIncrease = 2;

    float current = 0;
    bool increasing = true;

    // Start is called before the first frame update
    void Start() {
        current += Offset* IncreaseDuration;
        float scale = 1 + (current * (SizeIncrease - 1));
        this.transform.localScale = new Vector3(scale, scale, scale);

    }

    // Update is called once per frame
    void Update() {
        float modifier = 1;
        if (current >= IncreaseDuration) {
            increasing = false;
        }
        if (current <= 0) {
            increasing = true;
        }
        if (!increasing) {
            modifier = -1;
        }

        modifier = modifier * Time.deltaTime / IncreaseDuration;
        current += modifier;
        float scale = 1 + (current * (SizeIncrease - 1));
        this.transform.localScale = new Vector3(scale, scale, scale);
    }
}
