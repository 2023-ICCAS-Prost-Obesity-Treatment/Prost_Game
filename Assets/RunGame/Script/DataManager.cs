using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    public float playTimeCurrent = 10f;
    public float playTimeMax = 10f;
    public float magnetTimeCurrent = 0f;
    public float magnetTimeMax = 5f;
    public float itemMoveSpeed = 15f; 
    public int score = 0; //실제 스코어 저장할 곳
    public bool PlayerDie = false; //사망판단
    public int stage = 0;
    public int stageView = 0;

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
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

}

