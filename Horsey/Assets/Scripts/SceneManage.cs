using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Restart");
			RestartGame();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Pause");
            EndGame();
        }

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.anyKey)
            {
                PlayGame();
            }
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

    public void MainMenu() {
        SceneManager.LoadScene("Main_Menu");
    }

    public void EndGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
