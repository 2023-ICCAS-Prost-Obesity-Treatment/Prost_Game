using UnityEngine;

public class ResurrectionItem : MonoBehaviour
{
    public GmaeManager gameManager;

    // ��ư�� ������ �� ����Ǵ� �Լ�
    public void OnResurrectionImageClicked()
    {
        // canResurrect�� 1�� ���� ��Ȱ�ϵ��� �մϴ�.
        if (gameManager.canResurrect == 1)
        {
            gameManager.ResurrectPlayer();
        }
    }
}
