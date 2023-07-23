using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class StepCount : MonoBehaviour
{
    [SerializeField] public Text text;
    private int dailyStepCount = 0;
    private bool isDayStarted = false;

    private void Awake()
    {
        AndroidRuntimePermissions.RequestPermission("android.permission.ACTIVITY_RECOGNITION");
    }

    void Start()
    {
        InputSystem.EnableDevice(AndroidStepCounter.current);
        AndroidStepCounter.current.MakeCurrent();
        ResetDailyStepCount();
    }

    void Update()
    {
        int currentStep = AndroidStepCounter.current.stepCounter.ReadValue();

        // 현재 시간
        System.DateTime now = System.DateTime.Now;
        // 자정 시간 (00:00:00)
        System.DateTime midnight = now.Date;

        // 하루가 시작되었는지 확인
        if (now >= midnight && !isDayStarted)
        {
            ResetDailyStepCount();
            isDayStarted = true;
        }

        // 하루치 걸음 수를 증가
        dailyStepCount += currentStep;
        text.text = "STEP : " + dailyStepCount.ToString("NO");
    }

    // 하루치 걸음 수 초기화 메서드
    private void ResetDailyStepCount()
    {
        dailyStepCount = 0;
        isDayStarted = false;
    }
}
