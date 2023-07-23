using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Player")==0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        UnityEditor.EditorApplication.isPlaying=false;
        Application.Quit();
    }
}
