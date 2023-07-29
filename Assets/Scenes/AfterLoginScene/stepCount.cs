using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;
using UnityEngine.Networking;

public class StepCount : MonoBehaviour
{
    
    [SerializeField] public Text dailyStepText;
    public Text stepPointText;
    public int step;
    public AudioSource audioSource;
    public AudioClip audioClipCoin;
    public GameObject stepPointImg;


    private bool hasResetStep = false; // Flag to check if step has been reset

    private void Awake()
    {
        AndroidRuntimePermissions.RequestPermission("android.permission.ACTIVITY_RECOGNITION");
    }

    void Start()
    {
        InputSystem.EnableDevice(AndroidStepCounter.current);
        AndroidStepCounter.current.MakeCurrent();
        StartCoroutine(SendStepToServerCoroutine());
    }

    void Update()
    {
        long currentStep = AndroidStepCounter.current.stepCounter.ReadValue();
        System.DateTime currentTime = System.DateTime.Now;
        // If it's midnight (00:00), reset the step count
        if (IsMidnight(currentTime) && !hasResetStep)
        {
            ResetStepCount(currentStep);
            hasResetStep = true;
        }
        else if (!IsMidnight(currentTime))
        {
            hasResetStep = false;
        }

        dailyStepText.text = currentStep.ToString("N0");
        
    }

    public void ClickStepPoint()
    {
        audioSource.PlayOneShot(audioClipCoin);
        long dailyStep=long.Parse(dailyStepText.text);
        stepPointText.text=(dailyStep-UserManager.Instance.prevStepPoint).ToString("N0");
        UserManager.Instance.prevStepPoint=dailyStep;
        stepPointImg.SetActive(false);
    }

    private bool IsMidnight(System.DateTime currentTime)
    {
        // Check if it's midnight (00:00)
        if (currentTime.Hour == 0 && currentTime.Minute == 0 && currentTime.Second == 0)
        {
            return true;
        }

        return false;
    }

    private void ResetStepCount(long currentStep)
    {
        step = 0;
        UserManager.Instance.dailyStepList.Add(currentStep);
    }
    // Coroutine to send step data to the server every minute
    private IEnumerator SendStepToServerCoroutine()
    {
        while (true)
        {
            // Wait for 1 minute
            yield return new WaitForSeconds(60f);

            // Call the coroutine to send step data to the server
            StartCoroutine(SendStepToServer());
        }
    }

    // Coroutine to send step data to the server
    private IEnumerator SendStepToServer()
    {
        string url = ""; // Replace with your server URL
        WWWForm form = new WWWForm();
        form.AddField("step", step.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Success to send STEP POINT to server");
            }
            else
            {
                Debug.Log("Failed to send STEP POINT to server: " + www.error);
            }
        }
    }
}
