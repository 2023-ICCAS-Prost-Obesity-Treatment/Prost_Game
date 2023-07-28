using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class StepCount : MonoBehaviour
{
    [SerializeField] public Text stepText;
    public int step;

    private void Awake()
    {
        AndroidRuntimePermissions.RequestPermission("android.permission.ACTIVITY_RECOGNITION");
    }
    

    void Start()
    {

        InputSystem.EnableDevice(AndroidStepCounter.current);
        AndroidStepCounter.current.MakeCurrent();
    }

    void Update()
    {
        long step=AndroidStepCounter.current.stepCounter.ReadValue();
        UserManager.Instance.stepPoint=step;
        stepText.text=step.ToString("N0");
    }
}
