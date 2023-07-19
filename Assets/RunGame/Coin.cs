using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager gameManager;
    int saladPoint=100;
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player")==0)
            {
                gameManager.AddScore(saladPoint);
                // GameObject.Destroy(collision.gameObject);
                gameObject.SetActive(false);
            }
    }
}