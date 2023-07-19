using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jump = 10f;
    public float jump2 = 12f;

    private int jumpCount = 0;
    private Animator animator;
    GameManager gameManager;
    // DataManager DataManager;
    void start()
    {
        gameManager=FindObjectOfType<GameManager>();
        // dataManager=FindObjectOfType<DataManager>();
    }
    public void JumpBtn()
    {
        if (jumpCount == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
            jumpCount += 1;
        }
        else if (jumpCount == 1)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
            jumpCount += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Land") == 0)
        {
            jumpCount = 0;
        }
        if(collision.gameObject.tag.CompareTo("Obstacle") == 0)
        {
            DataManager.Instance.playTimeCurrent-=2f;
        }
    }
    public void PlayerAniRun()
    {
        animator.SetInteger("State",0);
    }
}
