using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UserImageChange : MonoBehaviour
{
    public RawImage rawImage; // 불러온 이미지를 보여줄 RawImage
    void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    public void GetImage()
    {
        NativeGallery.GetImageFromGallery((image) =>
        {
            FileInfo selectedImage = new FileInfo(image);

            if (!string.IsNullOrEmpty(image))
                StartCoroutine(LoadImage(image));

        });
    }

    // 이미지 로드 코루틴            
    IEnumerator LoadImage(string imagePath)
    {
        byte[] imageData = File.ReadAllBytes(imagePath);
        string imageName = Path.GetFileName(imagePath).Split('.')[0];
        string saveImagePath = Application.persistentDataPath + "/Image";

        File.WriteAllBytes(saveImagePath + imageName + ".jpg", imageData);

        var tempImage = File.ReadAllBytes(imagePath);

        Texture2D texture = new Texture2D(1080, 1440);
        texture.LoadImage(tempImage);

        rawImage.texture = texture;

        yield return null;
    }
}
