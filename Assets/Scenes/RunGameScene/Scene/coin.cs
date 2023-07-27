using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
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
        if (collision.gameObject.tag.CompareTo("Player") == 0) { //플레이어가 코인과 충돌하면
            SoundManager.Instance.PlaySound("Coin");
            DataManager.Instance.score += 1; //점수를 1점 높이고
            gameObject.SetActive(false); // 자신을 화면에서 꺼
        }
    }
}
