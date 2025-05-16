using System;
using System.Collections;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [ReadOnly][SerializeField] private Camera photoCamera;
    [SerializeField] private AudioClip takephotoSfx;
    //private Texture2D screenCapture;

    [SerializeField] private Image imagePrev;
    [SerializeField] private TextMeshProUGUI serverResponseField;
    
    private const string SERVER_NAME = "http://*.*.*.*:0000/upload";
    
    
    
    [SerializeField] private VoidEvent onFBtnPressed;


    private void OnEnable() {
        onFBtnPressed.AddListener(StartPhotoCapturing);
    }

    private void OnDisable() {
        onFBtnPressed.RemoveListener(StartPhotoCapturing);
    }

    private void Start()
    {
        photoCamera = Camera.main;
    }

    public void StartPhotoCapturing()
    {
        StartCoroutine(CapturePhotoFromOtherCamera());
    }

    IEnumerator CapturePhotoFromOtherCamera()
    {
        yield return new WaitForEndOfFrame();
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        photoCamera.targetTexture = rt;
        photoCamera.Render();
        RenderTexture.active = rt;
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0,0,Screen.width, Screen.height), 0, 0);
        ss.Apply();
        RenderTexture.active = null;
        photoCamera.targetTexture = null;
        Destroy(rt);
        Sprite photoSprite = Sprite.Create(ss, new Rect(0,0, ss.width, ss.height), new Vector2(0.5f,0.5f),100f);

        imagePrev.sprite = photoSprite;
        
        byte[] imageBytes = ss.EncodeToPNG();
        string fileName = "Unity Photo.png";

        WWWForm form = new WWWForm();
        form.AddField("postText", "Unity photo!");
        form.AddBinaryData("image", imageBytes, fileName, "image/png");

        UnityWebRequest request = UnityWebRequest.Post(SERVER_NAME, form);
        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.Success)
        {
            serverResponseField.text += " Yükleme başarılı: " + request.downloadHandler.text;
        }
        else
        {
            serverResponseField.text += " Yükleme başarısız: " + request.error;
        }

    }

}
