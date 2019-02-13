using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour {
    public TextMeshProUGUI countDownText;
    private float time;
    private bool timerStart = true;
    public float restartDelay = 0.1f;

    private void Start() {
        if(timerStart == true) {
            StartCountDownTimer();
        }
    }

    void StartCountDownTimer() {
        if(countDownText != null) {   
            time = 70;
            countDownText.text = "02:00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01067f);
        }
    }

    void UpdateTimer() {
        if (countDownText != null) {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            countDownText.text = (minutes + ":" + seconds);
            if (time < 10.0)
            {
                countDownText.color = Color.red;
            }
            if (time < 0.0) {
                countDownText.text = "00:00";
                Invoke("Restart", restartDelay);
            }
        }

    }
    void Restart() {
        Debug.Log("Game over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
