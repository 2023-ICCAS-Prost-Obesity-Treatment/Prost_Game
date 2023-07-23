using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadZone : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject LoadMap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.PlayerDie == false)
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)
            {
                gameManager.GetComponent<GameManager>().Next_Stage();
                Invoke("Close", 1.5f);
            }
        }
    }

    void Close()
    {
        LoadMap.SetActive(false);
    }
}
