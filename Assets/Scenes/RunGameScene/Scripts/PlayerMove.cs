using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump = 10f; //첫번째 점프 값 
    public float jump2 = 12f; // 두번째 점프 값
    public int jumpCount = 0;
    public Animator _ani;




    public void PlayerAni_Run()
    {
        _ani.SetInteger("state", 0);

    }
    public void PlayerAni_Jump()
    {
        _ani.SetInteger("state", 1);

    }

    public void Jump_Btn() //버튼에 넣을 함수
    {
        if (!DataManager.Instance.PlayerDie)
        {
            Debug.Log("점프 버튼 실행 + " + jumpCount + " : " + gameObject.GetComponent<Rigidbody2D>().velocity);
            SoundManager.Instance.PlaySound("Jump");
            if (jumpCount == 0 )
            { //점프를 한번도 안함
                if(gameObject.transform.position.y < 1)
                {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                jumpCount = 1; //점프횟수 추가
                Debug.Log("111");
                PlayerAni_Jump();

                }
            }

            else if (jumpCount == 1 ) //점프 한번 함
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0); //y축값이겠지?
                jumpCount = 2; // 점프횟수 추가
                Debug.Log("222");
            }
            
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("OnCollisionEnter2D / " + collision.gameObject.name + " : " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Land")) // 바닥과 충돌시 동작 
        {
            jumpCount = 0;
            Debug.Log("바닥   " + jumpCount);
            PlayerAni_Run();
        }
        else
        {
            jumpCount = 0;
            Debug.Log("바닥 아님  " + jumpCount);
        }

        Collider2D collider = collision.collider;
        if (collider.CompareTag("Block") && !collider.isTrigger)
        {
            Debug.Log("OnCollisionEnter2D Block / " + collider.gameObject.name);
            DataManager.Instance.playTimeCurrent -= 11f;
            PlayerAni_Run();
        }
    }
}


