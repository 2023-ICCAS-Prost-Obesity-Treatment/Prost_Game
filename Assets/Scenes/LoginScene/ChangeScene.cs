using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public void AfterLoginSceneChange()
    {
        SceneManager.LoadScene("initialScene");
    }
    public void GameSceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StoreSceneChange()
    {
        SceneManager.LoadScene("PointStore");
    }
}
