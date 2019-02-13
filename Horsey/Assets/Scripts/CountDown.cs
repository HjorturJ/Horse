using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text text;
    public float countdown = 3.0f;
    public bool stop;
    AudioSource shots;
    public GameObject movement;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("CountDown").GetComponent<Text>();
        shots = GameObject.Find("Bullets").GetComponent<AudioSource>();
        movement.GetComponent<HorseMovement>().enabled = false;
        text.text = "3";
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stop == false) {
            countdown -= Time.deltaTime;
        }
        if(countdown <= 2.0f && countdown > 1.0f) {
            text.text = "2";
        } else if(countdown <= 1.0f && countdown > 0.0f) {
            text.text = "1";
        } else if(countdown <= 0.0f) {
            text.text = "Go!";
            stop = true;
            StartCoroutine(FadeTextToZeroAlpha(1f, text));
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        playSound();
        movement.GetComponent<HorseMovement>().enabled = true;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        } 
        Destroy(text);
        Destroy(this);
    }

    public void playSound() 
    {
        if (!shots.isPlaying)
        {
            shots.Play();
        }
    }
}
