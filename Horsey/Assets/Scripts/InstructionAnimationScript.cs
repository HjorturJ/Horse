using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionAnimationScript : MonoBehaviour {

    private Transform[] pressedImages;

    void Start() {
        pressedImages = GetComponentsInChildren<Transform>();

        //Debug.Log(pressedImages[0].name);
        for (int i = 1; i < pressedImages.Length; i++) {
            pressedImages[i].gameObject.SetActive(false);
        }
        StartCoroutine(ToggleAnimation());
    }

    IEnumerator ToggleAnimation() {
        //1&6, 2&5, 3&4
        var i = 1;
        var k = 6;
        while (true) {
            Debug.Log(i);
            if (i > 3) i = 1;
            if (k < 4) k = 6;

            pressedImages[i].gameObject.SetActive(true);
            pressedImages[k].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            pressedImages[i].gameObject.SetActive(false);
            pressedImages[k].gameObject.SetActive(false);

            i++;
            k--;
        }

    }
}
