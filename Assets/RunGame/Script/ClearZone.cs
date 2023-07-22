using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZone : MonoBehaviour
{
    public GameObject gameManager;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    } // start와 거의 똑같은 기능.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.PlayerDie == false)
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)
            {
                gameManager.GetComponent<GameManager>().Load_Map();
            }
        }
    }
}
