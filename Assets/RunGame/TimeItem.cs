using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItem : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(!DataManager.Instance.PlayerDie)
    {
        if(collision.gameObject.tag.CompareTo("Player")==0)
        {
            // 시간 추가
            DataManager.Instance.playTimeCurrent+=3f;

            if(DataManager.Instance.playTimeCurrent>DataManager.Instance.playTimeMax)
            {
                DataManager.Instance.playTimeCurrent=DataManager.Instance.playTimeMax;
            }

        }
        gameObject.SetActive(false);
    }
   }
}
