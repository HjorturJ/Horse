using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    void Update ()
    {
        if(Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Restart");
			RestartGame();
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Pause");
            SceneManager.LoadScene("Pause_Scene");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        Debug.Log("Restarted");
        SceneManager.LoadScene("Main_Scene");
    }

    public void EndGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
