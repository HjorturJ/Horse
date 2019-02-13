using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndGame : MonoBehaviour {
    HorseMovement horseMovement;
    public GameObject gameOver;
    public GameObject winMenu;
    bool hasExploded = false;

    public GameObject explosionEffect;

    private void Start() {
        horseMovement = FindObjectOfType<HorseMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            if (!hasExploded) {
                Explode();
                hasExploded = true;
            }
        }

        if(collision.gameObject.tag == "Win") {
            Win();
        }
    }

    void Win() {
        horseMovement.enabled = false;
        winMenu.SetActive(true);
        Destroy(gameObject);
    }

    void Explode() {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        //This should destroy all of the horse aswell
        Destroy(horseMovement.transform.parent.transform.parent.gameObject);
        horseMovement.enabled = false;
        gameOver.SetActive(true);
        Destroy(gameObject);
    }
}
