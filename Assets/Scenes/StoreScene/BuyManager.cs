using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyManager : MonoBehaviour
{
    public Text[] itemArray; 
    public void OnButtonClick()
    {
        int currentStepPoint = 100000; // TODO: 현재 STEP 포인트 값 가져오기

        // 클릭한 버튼 가져오기
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        string buttonText = clickedButton.GetComponentInChildren<Text>().text;
        string buttonTag=clickedButton.tag; // item0, item1, item2
        Debug.Log("TAg : "+buttonTag);
        int itemIndex = int.Parse(buttonTag.Substring("item".Length)); // 0, 1, 2
        
        // 쉼표 제거
        string numberString = buttonText.Replace(",", "");
        string[] tokens = numberString.Split(' ');
        Text buttonTextComponent = clickedButton.GetComponentInChildren<Text>();
        if (int.TryParse(tokens[0], out int selectedStepPoint))
        {
            if (currentStepPoint >= selectedStepPoint)
            {
                currentStepPoint -= selectedStepPoint;
                buttonTextComponent.text = "Selected";
                buttonTextComponent.color = Color.red;
                
                UserManager.Instance.buyedItem.Add(itemIndex,"Selected");  // 구입 품목에 추가
                Debug.Log("UserManager - buyedItem:");

                foreach (var item in UserManager.Instance.buyedItem)
                {
                    Debug.Log("Item Index: " + item.Key + ", Item State: " + item.Value);
                }
            }
            else
            {
                Debug.Log("STEP 포인트가 부족합니다.");
            }
        }
        else
        {
            Debug.Log("유효하지 않은 숫자 형식입니다.");
            if (buttonText == "Select")
            {
                buttonTextComponent.text = "Selected";
                buttonTextComponent.color = Color.red;
                UserManager.Instance.buyedItem[itemIndex]="Selected";  // 구입한 아이템을 선택된 상태로 변경
            }
            else if (buttonText == "Selected")
            {
                buttonTextComponent.text = "Select";
                buttonTextComponent.color = Color.black;
                UserManager.Instance.buyedItem[itemIndex]="Select";  // 구입한 아이템을 선택안된 상태로 변경
            }
        }
    }
    void Start()
    {
        Dictionary<int, string> buyedList = UserManager.Instance.buyedItem;
        var enumerator = buyedList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var pair = enumerator.Current;
            int itemIndex = pair.Key;
            string itemState = pair.Value;
            Debug.Log("Item Index: " + itemIndex + ", Item State: " + itemState);
            string itemTag="item"+itemIndex;
            GameObject itemObject=GameObject.FindWithTag(itemTag);
            if(itemObject!=null)
            {
                Text itemText=itemObject.GetComponentInChildren<Text>();
                itemText.text=itemState;
                if(itemState=="Selected")
                {
                    itemText.color=Color.red;
                }
                else
                {
                    itemText.color=Color.black;
                }
            }
        }
    }

}
