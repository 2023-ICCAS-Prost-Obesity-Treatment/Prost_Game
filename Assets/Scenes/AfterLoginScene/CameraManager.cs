using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.Networking;
using System.IO;
using System.Collections;
using System;
using Defective.JSON;

public class CameraManager : MonoBehaviour
{
    WebCamTexture camTexture;

    public RawImage cameraViewImage; //카메라가 보여질 화면
    public GameObject cameraPanel;


    public void CameraOn() //카메라 켜기
    {
        cameraPanel.SetActive(true);
        Debug.Log("Camear Function Start");
        //카메라 권한 확인
        if(!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }

        if(WebCamTexture.devices.Length == 0) //카메라가 없다면..
        {
            Debug.Log("no camera!");
            return;
        }

        WebCamDevice[] devices = WebCamTexture.devices; //스마트폰의 카메라 정보를 모두 가져옴.
        int selectedCameraIndex = -1;

        //후면 카메라 찾기
        for (int i = 0; i< devices.Length; i++)
        {
            if(devices[i].isFrontFacing == false)
            {
                selectedCameraIndex = i;
                break;
            }
        }

        //카메라 켜기
        if(selectedCameraIndex >= 0)
        {
            //선택된 후면 카메라를 가져옴.
            camTexture = new WebCamTexture(devices[selectedCameraIndex].name);
            
            camTexture.requestedFPS = 30; //카메라 프레임설정

            cameraViewImage.texture = camTexture; //영상을 raw Image에 할당.

            camTexture.Play(); // 카메라 시작하기
        }
    }
    public void CaptureAndPredict()
    {
        // 카메라 캡처
        Texture2D texture = new Texture2D(camTexture.width, camTexture.height);
        texture.SetPixels(camTexture.GetPixels());
        texture.Apply();

        // 이미지를 바이트 배열로 변환
        byte[] bytes = texture.EncodeToPNG();

        Debug.Log("@@@@바이트 배열로 변환 : @@@@@\n");
        
    }
    public void CameraOff() //카메라 끄기
    {
        if(camTexture != null)
        {
            camTexture.Stop(); //카메라 정지
            WebCamTexture.Destroy(camTexture); //카메라 객체반납
            camTexture = null; //변수 초기화
            cameraPanel.SetActive(false);
        }
    }
}