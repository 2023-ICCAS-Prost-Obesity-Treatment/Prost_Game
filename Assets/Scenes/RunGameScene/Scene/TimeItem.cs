using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeItem : MonoBehaviour
{
    public GameObject player;
    public Vector3 OB_base_location;
    private void Awake()
    {
        OB_base_location = gameObject.transform.localPosition;
    }
    public void OnEnable()
    {
        gameObject.transform.localPosition = OB_base_location;
    }
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("PlayerPosition");
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if (DataManager.Instance.PlayerDie == false && DataManager.Instance.magnetTimeCurrent > 0)
        {
            if (distance < 6)
            {
                Vector2 dir = player.transform.position - transform.position;
                transform.Translate(dir.normalized * DataManager.Instance.itemMoveSpeed * Time.deltaTime, Space.World); ;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.Instance.PlayerDie)
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)
            {
                DataManager.Instance.playTimeCurrent += 3f; //시간 추가
                if (DataManager.Instance.playTimeCurrent > DataManager.Instance.playTimeMax) //시간이 max보다 커지면 max로 변환
                {
                    DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
                }
                gameObject.SetActive(false);
            }
        }
    }
}



    // Start is called before the first frame update

