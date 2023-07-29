using UnityEngine;

public class ResurrectionItem : MonoBehaviour
{
    public GmaeManager gameManager;

    // 버튼이 눌렸을 때 실행되는 함수
    public void OnResurrectionImageClicked()
    {
        // canResurrect가 1일 때만 부활하도록 합니다.
        if (gameManager.canResurrect == 1)
        {
            gameManager.ResurrectPlayer();
        }
    }
}
