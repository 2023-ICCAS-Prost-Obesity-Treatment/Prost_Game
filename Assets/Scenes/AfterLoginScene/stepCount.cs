using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class StepCount : MonoBehaviour
{
    [SerializeField] public Text stepText;
    protected int step;

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
        stepText.text = AndroidStepCounter.current.stepCounter.ReadValue().ToString("N0");
    }
}
