using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndGame : MonoBehaviour
{
    HorseMovement horseMovement;
    public GameObject gameOver;
    bool hasExploded = false;

    public GameObject explosionEffect;

    private void Start()
    {
        horseMovement = FindObjectOfType<HorseMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(!hasExploded) {
                Explode();
                hasExploded = true;
            }
        }
    }
    void Explode() {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        horseMovement.enabled = false;
        gameOver.SetActive(true);
    }
}
