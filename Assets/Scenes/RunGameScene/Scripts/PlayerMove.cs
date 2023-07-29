using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump = 10f; //ù��° ���� �� 
    public float jump2 = 12f; // �ι�° ���� ��
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

    public void Jump_Btn() //��ư�� ���� �Լ�
    {
        if (!DataManager.Instance.PlayerDie)
        {
            // Debug.Log("���� ��ư ���� + " + jumpCount + " : " + gameObject.GetComponent<Rigidbody2D>().velocity);
            SoundManager.Instance.PlaySound("Jump");
            if (jumpCount == 0 )
            { //������ �ѹ��� ����
                if(gameObject.transform.position.y < 1)
                {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                jumpCount = 1; //����Ƚ�� �߰�
                Debug.Log("111");
                PlayerAni_Jump();

                }
            }

            else if (jumpCount == 1 ) //���� �ѹ� ��
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0); //y�ప�̰���?
                jumpCount = 2; // ����Ƚ�� �߰�
                Debug.Log("222");
            }
            
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("OnCollisionEnter2D / " + collision.gameObject.name + " : " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Land")) // �ٴڰ� �浹�� ���� 
        {
            jumpCount = 0;
            // Debug.Log("�ٴ�   " + jumpCount);
            PlayerAni_Run();
        }
        else
        {
            jumpCount = 0;
            // Debug.Log("�ٴ� �ƴ�  " + jumpCount);
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


