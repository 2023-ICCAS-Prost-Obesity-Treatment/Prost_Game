using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    bool BG_flag = false;
    public Animator _ani;


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

        if(DataManager.Instance.stage > StageMap.Length)
        {
            DataManager.Instance.stage = DataManager.Instance.stage % StageMap.Length;
            if(DataManager.Instance.stage == 0)
            {
                DataManager.Instance.stage = StageMap.Length;
            }

        }
        StageStart();
    }
    public void StageStart()
    {
        for(int temp = 1; temp <= StageMap.Length; temp++)
        {
            if(temp == DataManager.Instance.stage)
            {
                StageMap[temp - 1].transform.position = new Vector3(15f, StageMap[temp - 1].transform.position.y, StageMap[temp - 1].transform.position.z); //�����ʿ��� ���� �̵��� �� �ڸ������
                StageMap[temp - 1].SetActive(true);
            }
            else
            {
                StageMap[temp-1].SetActive(false);
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
            EndPanel.SetActive(true);
            _ani.SetBool("Die", true);
            EndScore.text="SCORE : "+DataManager.Instance.score.ToString();
            UserManager.Instance.userScore=DataManager.Instance.score;
        }
    }
    // public void Restart_Btu()
    // {
    //     DataManager.Instance.stage = 0;
    //     DataManager.Instance.stageView = 0;
    //     DataManager.Instance.score = 0;
    //     DataManager.Instance.PlayerDie = false;
    //     DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
    //     DataManager.Instance.magnetTimeCurrent = 0;

    //     SceneManager.LoadScene("SampleScene");
    //     SoundManager.Instance.PlaySound("BG");
    // }

}