using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginForm : MonoBehaviour
{
    public InputField idInputField;
    public InputField passwordInputField;
    public GameObject LoginAlert;
    private const string serverURL = "http://www.myserver.com/login"; // post url

    public void SendLoginRequest()
    {
        // 입력된 ID와 Password 가져오기
        string id = idInputField.text;
        string password = passwordInputField.text;

        // 폼 데이터 생성
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("password", password);

        // 서버에 HTTP POST 요청 보내기
        StartCoroutine(PostLoginRequest(form));
    }

    IEnumerator PostLoginRequest(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(serverURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("Error: " + www.error);
                LoginAlert.SetActive(true);
            }
            else  // connection success
            {
                Debug.Log("Response: " + www.downloadHandler.text);
                bool response = bool.Parse(www.downloadHandler.text);
                if (response)
                {
                    // 서버의 응답이 true인 경우 InitialScene으로 넘어감
                    SceneManager.LoadScene("InitialScene");
                }
                else
                {
                    // 서버의 응답이 false인 경우 login alery panel 표시
                    LoginAlert.SetActive(true);
                }
            }
        }
    }
    void CloseAlertForm()
    {
        LoginAlert.SetActive(false);
    }
}
