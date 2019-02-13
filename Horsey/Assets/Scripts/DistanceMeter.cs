using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceMeter : MonoBehaviour {
    public GameObject horsePos;
    public Slider slider;

    private void Update() {
        if (horsePos && slider) {
            slider.value = horsePos.transform.position.x;
        }
    }
}
