using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump = 10f; //첫번째 점프 값 
    public float jump2 = 12f; // 두번째 점프 값

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Land") == 0) //바닥과 충돌시 동작 
        {
            jumpCount = 0;
        }
        if (collision.gameObject.tag.CompareTo("Block") == 0) // block과 충돌시 playtime 감소
        {
            DataManager.Instance.playTimeCurrent -= 2f;
        }
    }

    int jumpCount = 0;

    public void Jump_Btn() //버튼에 넣을 함수
    {
        if (!DataManager.Instance.PlayerDie)
        {
            SoundManager.Instance.PlaySound("Jump");
            if (jumpCount == 0)
            { //점프를 한번도 안함
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                jumpCount += 1; //점프횟수 추가
            }

            else if (jumpCount == 1) //점프 한번 함
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0); //y축값이겠지?
                jumpCount += 1; // 점프횟수 추가
            }
        }
    }
} 

