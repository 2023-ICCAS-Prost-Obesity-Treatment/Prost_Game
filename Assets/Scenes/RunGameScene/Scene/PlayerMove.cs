using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump = 10f; //ù��° ���� �� 
    public float jump2 = 12f; // �ι�° ���� ��

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Land") == 0) //�ٴڰ� �浹�� ���� 
        {
            jumpCount = 0;
        }
        if (collision.gameObject.tag.CompareTo("Block") == 0) // block�� �浹�� playtime ����
        {
            DataManager.Instance.playTimeCurrent -= 2f;
        }
    }

    int jumpCount = 0;

    public void Jump_Btn() //��ư�� ���� �Լ�
    {
        if (!DataManager.Instance.PlayerDie)
        {
            SoundManager.Instance.PlaySound("Jump");
            if (jumpCount == 0)
            { //������ �ѹ��� ����
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                jumpCount += 1; //����Ƚ�� �߰�
            }

            else if (jumpCount == 1) //���� �ѹ� ��
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0); //y�ప�̰���?
                jumpCount += 1; // ����Ƚ�� �߰�
            }
        }
    }
} 

