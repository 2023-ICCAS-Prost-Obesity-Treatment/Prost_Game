using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyManager : MonoBehaviour
{
    private Button button;
    void start()
    {
        button=GetComponent<Button>();
    }
    private void OnButtonClick()
    {
        
        int currentStepPoint=100000;  //TODO get current step
        // clicked button
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        string buttonText = button.GetComponentInChildren<Text>().text;
        string []tokens=buttonText.Split(' ');
        
        if (buttonText == "select")
        {
            buttonText = "selected";
            button.GetComponentInChildren<Text>().text = buttonText;
            button.GetComponent<Image>().color = Color.red;
            return;
        }
        
        if (buttonText == "selected")
        {
            return;
        }

        int selectedStepPoint = int.Parse(tokens[1]);
        // 현재의 STEP point와 비교하여 차감
        if (currentStepPoint >= selectedStepPoint && clickedButton == button)
        {
            currentStepPoint -= selectedStepPoint;
            SetButtonSelectedStyle(clickedButton);
        }
    }

    private void SetButtonSelectedStyle(Button button)
    {
        // 버튼의 Text를 "Selected"로 변경하고 색상을 빨간색으로 변경
        button.GetComponentInChildren<Text>().text = "Selected";
        button.GetComponent<Image>().color = Color.red;
    }
}
