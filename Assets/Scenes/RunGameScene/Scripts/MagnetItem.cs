using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagnetItem : MonoBehaviour
{
    public GameObject player;
    public Vector3 OB_base_location;
    private bool isMagnetActive = false;
    private bool isCooldown = false;
    private float magnetStartTime;
    private float magnetDuration = 5.0f;
    private float cooldownDuration = 5.0f;
    public Image img_Skill;
    
    private void Awake()
    {
        OB_base_location = gameObject.transform.localPosition;
    }
    public void OnEnable()
    {
        gameObject.transform.localPosition = OB_base_location;
    }
    // Update is called once per frame
    // void Update()
    // {
    //     player = GameObject.FindGameObjectWithTag("PlayerPosition");
    //     float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
    //     if(DataManager.Instance.PlayerDie == false && DataManager.Instance.magnetTimeCurrent > 0)
    //     {
    //         if (distance < 6)
    //         {
    //             Vector2 dir = player.transform.position - transform.position;
    //             transform.Translate(dir.normalized * DataManager.Instance.itemMoveSpeed * Time.deltaTime, Space.World);

    //         }
    //     }
    // }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (!DataManager.Instance.PlayerDie)
    //     {
    //         if (collision.gameObject.tag.CompareTo("Player") == 0)
    //         {
    //             DataManager.Instance.magnetTimeCurrent = DataManager.Instance.magnetTimeMax;
    //             gameObject.SetActive(false);
    //         }
    //     }
    // }
    // public void MannetBtn()
    // {

    //     player = GameObject.FindGameObjectWithTag("PlayerPosition");
    //     float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
    //     if(DataManager.Instance.PlayerDie == false && DataManager.Instance.magnetTimeCurrent > 0)
    //     {
    //         if (distance < 6)
    //         {
    //             Vector2 dir = player.transform.position - transform.position;
    //             transform.Translate(dir.normalized * DataManager.Instance.itemMoveSpeed * Time.deltaTime, Space.World);

    //         }
    //     }
    // }
    // IEnumerator CoolTime (float cool)
    // {
    //     print("쿨타임 코루틴 실행");
 
    //     while (cool > 1.0f)
    //     {
    //         cool -= Time.deltaTime;
    //         img_Skill.fillAmount = (1.0f / cool);
    //         yield return new WaitForFixedUpdate();
    //     }
        
    //     print("쿨타임 코루틴 완료");
    // }
    public void MagnetBtn()
    {
        DataManager.Instance.magnetTimeCurrent = DataManager.Instance.magnetTimeMax;
        img_Skill.color=Color.black;
        if (!isMagnetActive && !isCooldown) // Check if the magnet effect is not already active and not in cooldown
        {
            StartCoroutine(ActivateMagnetEffect());
        }
    }

    IEnumerator ActivateMagnetEffect()
    {
        // OB_base_location = gameObject.transform.localPosition;
        // gameObject.transform.localPosition = OB_base_location;
        isMagnetActive = true; // Activate the magnet effect
        magnetStartTime = Time.time; // Record the start time

        while (Time.time - magnetStartTime < magnetDuration)
        {
            // Magnet effect logic (runs for 6 seconds)
            player = GameObject.FindGameObjectWithTag("PlayerPosition");
            float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
            if (DataManager.Instance.PlayerDie == false && DataManager.Instance.magnetTimeCurrent > 0)
            {
                if (distance < 6)
                {
                    Vector2 dir = player.transform.position - transform.position;
                    transform.Translate(dir.normalized * DataManager.Instance.itemMoveSpeed * Time.deltaTime, Space.World);
                }
            }
            yield return null; // Wait for the next frame
            Debug.Log("under 6 second");
        }

        isMagnetActive = false; // Deactivate the magnet effect
        StartCoroutine(Cooldown(cooldownDuration)); // Start the cooldown
    }

    IEnumerator Cooldown(float cool)
    {
        
        isCooldown = true; // Start cooldown

        while (cool > 1.0f)
        {
            // Update the cooldown UI fill amount
            img_Skill.fillAmount = (1.0f/cool);
            cool -= Time.deltaTime;
            yield return new WaitForFixedUpdate(); // Wait for the next frame
        }

        // Cooldown is over, reset the cooldown UI
        img_Skill.fillAmount = 0.0f;
        isCooldown = false;
    }
}
