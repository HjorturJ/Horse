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
			Debug.Log("Pressed");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
           EndGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
