/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Scrollbar HealthBar;
    public SoundManager soundManager;
    public Text ScoreText;
    public GameObject EndPanel;
    public Button jumpButton;
    public Button slideButton;

    private Rigidbody2D Player;
    public PolygonCollider2D PlayerIdle;
    public PolygonCollider2D PlayerSlide;
    private Animator PlayerAni;
    private const float POWER = 25.0f;
    private bool jump = false;
    private bool slide = false;
    private int jumpCount = 0;
    private int Score = 0;
    private float health = 100f;
    private bool isGrounded = false;
    private void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        PlayerAni = GetComponent<Animator>();
        ScoreRenew();
        LifeRenew();

        StartCoroutine("NextPage");

        // ��ư�� ���� Ŭ�� �̺�Ʈ ó��
        jumpButton.onClick.AddListener(Jump);
        slideButton.onClick.AddListener(Slide);
    }

    private void FixedUpdate()
    {
        if (jumpCount > 0 && jump && isGrounded) // ���� ��� �ִ� ���¿����� ���� �����ϵ��� ����
        {
            Player.velocity = (Vector2.up * POWER);
            PlayerAni.SetInteger("Jump", jumpCount);
            jump = false;
            isGrounded = false; // �����ϸ� ������ ������ ���·� ����
        }
    }

    private void Update()
    {
        health -= 0.02f;
        LifeRenew();

        // ��ư �Է��� ����Ͽ� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < 2 && !slide)
        {
            Jump();
        }



        if (0 >= HealthBar.size)
        {
            PlayerAni.SetBool("Die", true);
            GameManager.instance.gameOver = true;
        }

        if (transform.position.y < -10)
        {
            GameManager.instance.gameOver = true;
        }

        if (GameManager.instance.gameOver)
        {
            EndPanel.SetActive(true);
            LifeRenew();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // ���� ����� ��
        {
            jumpCount = 0;
            PlayerAni.SetInteger("Jump", jumpCount);
            PlayerAni.SetBool("Idle", true);
            isGrounded = true; // ���� ��� �ִ� ���·� ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Potion"))
        {
            health += 5f;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Trap"))
        {
            PlayerAni.SetBool("Crash", true);
            health -= 10;
            LifeRenew();
        }

        if (collision.CompareTag("Pit"))
        {
            GameManager.instance.gameOver = true;
        }

        if (collision.CompareTag("Coin"))
        {
            Score++;
            ScoreRenew();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Crystal"))
        {
            Score += 10;
            ScoreRenew();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            PlayerAni.SetBool("Crash", false);
        }
    }

    void Jump()
    {
        jumpCount++;
        jump = true;
        PlayerAni.SetBool("Idle", false);
    }

    void Slide()
    {
        PlayerAni.SetBool("Slide", true);
        slide = true;
        PlayerSlide.enabled = true;
        PlayerIdle.enabled = false;
    }

    void LifeRenew()
    {
        HealthBar.size = health / 100f;
    }

    void ScoreRenew()
    {
        ScoreText.text = "Score : " + Score.ToString();
    }

    IEnumerator NextPage()
    {
        while (true)
        {
            yield return new WaitForSeconds(15.0f);
            GameManager.instance.stage++;
        }
    }
}
*/