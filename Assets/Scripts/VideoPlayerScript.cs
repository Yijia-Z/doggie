using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public int loopCount = 3; // number of times to loop the video
    private int loopCounter = 0; // counter variable to keep track of the number of loops

    public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;
    public RawImage rawImage;
    private void Start()
    {
        videoPlayer1.loopPointReached += OnLoopPointReached;
        videoPlayer2.loopPointReached += OnLoopPointReached; // subscribe to the VideoPlayer's loopPointReached event
    }

    public void PlayVideo(int videoNumber)
    {
        switch (videoNumber)
        {
            case 1:
                rawImage.enabled = true; // enable the RawImage component before playing the video
                rawImage.texture = videoPlayer1.texture;
                videoPlayer1.SetActive(true);
                videoPlayer1.Play();
                break;
            case 2:
                rawImage.enabled = true;
                rawImage.texture = videoPlayer2.texture;
                videoPlayer2.SetActive(true);
                videoPlayer2.Play();
                break;
            default:
                Debug.LogError("Invalid video number");
                break;
        }
    }
    private void OnLoopPointReached(VideoPlayer vp)
    {
        if (loopCounter < loopCount - 1) // check if we have reached the specified number of loops
        {
            loopCounter++;
            vp.Play(); // play the video again
        }
        else
        {
            rawImage.enabled = false; // disable the RawImage component when the video ends
            vp.SetActive(false);
            loopCounter = 0;
        }
    }
}