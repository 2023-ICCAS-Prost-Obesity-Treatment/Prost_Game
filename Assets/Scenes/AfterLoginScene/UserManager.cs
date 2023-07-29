using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    public long userScore;
    public long dietPoint;
    // public Queue<long> stepPoint = new Queue<long>();
    public List<long> dailyStepList=new List<long>();
    public long prevStepPoint;
    public Dictionary<int, string> buyedItem = new Dictionary<int, string>();

    public static UserManager Instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // stepPoint 초기화
        prevStepPoint=0;
        // stepPoint.Enqueue(0);
    }
}
