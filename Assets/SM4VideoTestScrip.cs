using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SM4VideoTestScrip : MonoBehaviour
{
    void Start()
    {
        /*
        var videoAttributes = new VideoAttributes();
        videoAttributes.path = @"\Events\mllhildEvents\Images\smileevil.mp4";
        videoAttributes.fit = 1;
        InstantiateVideo(videoAttributes);
        */
    }
    

    public List<SM4VideoWindow> videoContainerList = new List<SM4VideoWindow>();

    public void InstantiateVideo(VideoAttributes videoAttributes)
    {
        var videoContainer = Instantiate(new GameObject(), transform);
        StartCoroutine(LoadAndPlayVideo(videoAttributes, videoContainer));
    }
    

    IEnumerator LoadAndPlayVideo(VideoAttributes videoAttributes, GameObject videoContainer)
    {
        
        var rawImage = videoContainer.AddComponent<RawImage>();
        
        var rectTransform = videoContainer.GetComponent<RectTransform>();
        rectTransform.localScale = videoAttributes.scale;
        rectTransform.rotation = videoAttributes.rotation;
        rectTransform.position = videoAttributes.position;
        rectTransform.sizeDelta = videoAttributes.sizeDelta;
        rawImage.color = videoAttributes.color;
        var videoPlayer = videoContainer.AddComponent<UnityEngine.Video.VideoPlayer>();
        var audioSource = videoContainer.AddComponent<AudioSource>();
        
        // dont use Path.Combine it loves to bug out
        videoAttributes.path = Application.streamingAssetsPath + videoAttributes.path;
        videoPlayer.url = @videoAttributes.path;
        var renderTexture = new RenderTexture(
            (int)videoAttributes.sizeDelta.x,(int)videoAttributes.sizeDelta.y,24);
        videoPlayer.targetTexture = renderTexture;
        rawImage.texture = renderTexture;
        videoPlayer.playOnAwake = true;
        videoPlayer.isLooping = videoAttributes.loop;
        videoPlayer.waitForFirstFrame = true;
        switch (videoAttributes.fit)
        {
            case 0:
                videoPlayer.aspectRatio = VideoAspectRatio.NoScaling;
                break;
            case 1:
                videoPlayer.aspectRatio = VideoAspectRatio.Stretch;
                break;
            case 2:
                videoPlayer.aspectRatio = VideoAspectRatio.FitHorizontally;
                break;
            case 3:
                videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
                break;
            case 4:
                videoPlayer.aspectRatio = VideoAspectRatio.FitInside;
                break;
            case 5:
                videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
                break;
            default:
                videoPlayer.aspectRatio = VideoAspectRatio.NoScaling;
                break;
        }
        
        
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        videoPlayer.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
        var videoWindow = new SM4VideoWindow();
        videoWindow.window = videoContainer;
        videoWindow.rawImage = rawImage;
        videoWindow.videoPlayer = videoPlayer;
        videoWindow.audioSource = audioSource;
        videoWindow.renderTexture = renderTexture;
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
        //Destroy(renderTexture);
        //Destroy(rawImage.texture);
        //Destroy(videoPlayer.targetTexture);
        //Destroy(gameObject);
    }

    public void VideoListClear()
    {
        foreach (var videoWindow in videoContainerList)
        {
            Destroy(videoWindow.rawImage.texture);
            Destroy(videoWindow.videoPlayer.targetTexture);
            Destroy(videoWindow.renderTexture);
            Destroy(videoWindow.audioSource);
            Destroy(videoWindow.gameObject);
        }
        videoContainerList.Clear();
        
    }
}

public class VideoAttributes
{
    public string path = "";
    public Vector2 sizeDelta = new Vector2(1000,1000);
    public Vector2 scale = new Vector2(1,1);
    public Vector2 position = new Vector2(1,1);
    public Quaternion rotation = new Quaternion(0,0,0,0);
    public Color color = new Color(1,1,1,1);
    public int layer = 0;
    public bool loop = true;
    public int fit = 0;
    /*
       0 videoPlayer.aspectRatio = VideoAspectRatio.NoScaling;
       1 videoPlayer.aspectRatio = VideoAspectRatio.Stretch;
       2 videoPlayer.aspectRatio = VideoAspectRatio.FitHorizontally;
       3 videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
       4 videoPlayer.aspectRatio = VideoAspectRatio.FitInside;
       5 videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
     */
    
}
