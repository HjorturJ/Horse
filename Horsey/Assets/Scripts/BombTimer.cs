using UnityEngine;
using TMPro;

public class BombTimer : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    public GameObject explosionEffect;
    private float time = 120;
    CountDown countdown;

    private void Start()
    {
        countdown = FindObjectOfType<CountDown>();
    }

    void Update()
    {
        if (countDownText != null && countdown.bombTimerStart == true)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            if (seconds == "60") seconds = "59";
            countDownText.text = (minutes + ":" + seconds);
            if (time < 10.0)
            {
                countDownText.color = Color.red;
            }
            if (time < 0.0)
            {
                countDownText.text = "00:00";
                Invoke("GameOver", 0.1f);
            }
        }

    }
    void GameOver()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject.transform.parent.transform.parent.gameObject);
    }
}
