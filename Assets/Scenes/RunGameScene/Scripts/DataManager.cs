using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    public float playTimeMax = 20f;
    public float playTimeCurrent = 20f;
    public float magnetTimeCurrent = 0f;
    public float magnetTimeMax = 5f;
    public float itemMoveSpeed = 15f;

    static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
    public int score = 0; //���� ���ھ� ������ ��
    public bool PlayerDie = false; //����Ǵ�
    public int stage = 0;
    public int stageView = 0;
}

