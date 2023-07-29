using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PlayerMove;

public class GmaeManager : MonoBehaviour
{
    public GameObject[] NumberImage;
    public Sprite[] Number;
    public Image TimeBar;
    public GameObject EndPanel;
    public GameObject[] StageMap;
    public GameObject LoadMap;
    public Text StageText;
    public GameObject BG_1;
    public GameObject BG_2;
    public GameObject BG_3;
    public GameObject CoverImage;
    public Text EndScore;
    public GameObject resurrectionImage; // 부활 이미지 오브젝트를 Inspector에서 설정
    private Vector3 playerStartPosition;
    private Vector3 playerDeathPosition;
    public int canResurrect = 1;
    public PlayerMove playerMoveScript;



    bool BG_flag = false;
    public Animator _ani;

    public void Start()
    {
        // 게임 시작 시 플레이어 위치를 저장
        GameObject player = GameObject.FindWithTag("Player");
        // 죽은 위치 초기화
        playerDeathPosition = Vector3.zero;
        // PlayerMove 스크립트의 델리게이트에 함수 연결
        playerMoveScript.onPlayerDie += OnPlayerDie;
    }

    public void OnclickStartButton()
    {
        CoverImage.SetActive(false);
    }

    public void Next_Stage()
    {
        if (!BG_flag)
        {
            BG_1.SetActive(false);
            BG_2.SetActive(true);
            BG_3.SetActive(false);
            BG_flag = true;
        }
        else
        {
            BG_1.SetActive(false);
            BG_2.SetActive(false);
            BG_3.SetActive(true);
            BG_flag = false;
        }


        DataManager.Instance.stage += 1;
        DataManager.Instance.stageView += 1;

        if (DataManager.Instance.stage > StageMap.Length)
        {
            DataManager.Instance.stage = DataManager.Instance.stage % StageMap.Length;
            if (DataManager.Instance.stage == 0)
            {
                DataManager.Instance.stage = StageMap.Length;
            }

        }
        StageStart();
    }
    public void StageStart()
    {
        for (int temp = 1; temp <= StageMap.Length; temp++)
        {
            if (temp == DataManager.Instance.stage)
            {
                StageMap[temp - 1].transform.position = new Vector3(15f, StageMap[temp - 1].transform.position.y, StageMap[temp - 1].transform.position.z); //�����ʿ��� ���� �̵��� �� �ڸ������
                StageMap[temp - 1].SetActive(true);
            }
            else
            {
                StageMap[temp - 1].SetActive(false);
            }
        }
    }

    public void Load_Map()
    {
        LoadMap.transform.position = new Vector3(15f, LoadMap.transform.position.y, LoadMap.transform.position.z);
        LoadMap.SetActive(true);
    }
    private void Update()
    {


        if (DataManager.Instance.stageView == 0)
        {
            StageText.text = "START";
        }
        else
        {
            StageText.text = "Stage" + DataManager.Instance.stageView.ToString();
        }

        int temp = DataManager.Instance.score / 100;
        NumberImage[0].GetComponent<Image>().sprite = Number[temp];

        int temp2 = DataManager.Instance.score % 100;

        temp2 = temp2 / 10;
        NumberImage[1].GetComponent<Image>().sprite = Number[temp2];

        int temp3 = DataManager.Instance.score % 10;
        NumberImage[2].GetComponent<Image>().sprite = Number[temp3];

        if (!DataManager.Instance.PlayerDie)
        {
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1�ʿ� 1�� ��

            TimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;

            if (DataManager.Instance.playTimeCurrent < 0) //�ð� �� �Ǹ� ����
            {
                SoundManager.Instance.StopSound("BG");
                SoundManager.Instance.StopSound("Jump");
                DataManager.Instance.PlayerDie = true;


            }
            if (DataManager.Instance.magnetTimeCurrent > 0)
            {
                DataManager.Instance.magnetTimeCurrent -= 1 * Time.deltaTime;
            }
        }
        if (DataManager.Instance.PlayerDie == true)
        {
            playerDeathPosition = DataManager.Instance.transform.position;
            EndPanel.SetActive(true);
            _ani.SetBool("Die", true);
            EndScore.text = "SCORE : " + DataManager.Instance.score.ToString();
            UserManager.Instance.userScore = DataManager.Instance.score;
        }
    }
    /*public void Restart_Btu()
      {
          DataManager.Instance.stage = 0;
          DataManager.Instance.stageView = 0;
          DataManager.Instance.score = 0;
          DataManager.Instance.PlayerDie = false;
          DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
          DataManager.Instance.magnetTimeCurrent = 0;

          SceneManager.LoadScene("RunGameScene");
          SoundManager.Instance.PlaySound("BG");
     }
    */


    private void OnPlayerDie(Vector3 deathPosition)
    {
        // 죽은 위치를 저장합니다.
        playerDeathPosition = deathPosition;

        // 죽음 처리 로직
        DataManager.Instance.PlayerDie = true;
        EndPanel.SetActive(true);
        _ani.SetBool("Die", true);
        EndScore.text = "SCORE : " + DataManager.Instance.score.ToString();
        UserManager.Instance.userScore = DataManager.Instance.score;
    }

    // 부활 아이템을 누를 때 호출될 함수
    public void ResurrectPlayer()
    {
        if (canResurrect == 1)
        {
            // 부활 로직을 실행합니다.
            DataManager.Instance.PlayerDie = false;
            DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
            DataManager.Instance.magnetTimeCurrent = 0;
            EndPanel.SetActive(false);
            _ani.SetBool("Die", false);

            _ani.SetTrigger("revive");

            // 플레이어를 죽은 위치로 이동시킵니다.
            DataManager.Instance.transform.position = playerDeathPosition;

            canResurrect = 0; // 다시 부활하지 않도록 상태를 변경합니다.



            SoundManager.Instance.PlaySound("BG");
            // 부활 후 추가로 해야 할 작업들을 추가할 수 있습니다.
            // 예: 아이템 초기화 등
        }
    }
}

