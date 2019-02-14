using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionAnimFadeOut : MonoBehaviour {
    public Image[] images;
    private float timer;
    private bool fadeStarted = false;

    void Update() {
        timer += Time.deltaTime;

        if (timer > 30 && !fadeStarted) {
            fadeStarted = true;
            StartCoroutine(FadeOut());

        }
    }

    IEnumerator FadeOut() {
        float alpha;
        float reduce = 0.01f;
        while(true) {
            foreach (var image in images) {
                alpha = image.color.a;
                image.color = new Color(255, 255, 255, alpha -= reduce);
            }
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
