using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ReadInput : MonoBehaviour
{
    string inputString;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject uiLayer;
    [SerializeField] AppState appState;
    public void ReadStringInput(string stringFromButton)
    {
        inputString = stringFromButton;
        // Debug.Log(inputString);

        // Check if inputString is valid
        if (inputString == null || inputString == "")
        {
            Debug.Log("Input string is null or empty.");
            return;
        }

        videoPlayer.url = inputString;
        videoPlayer.Play();

        uiLayer.SetActive(false);
        appState.lockMovement = false;

        videoPlayer.errorReceived += OnVideoPlayerError;
    }

    private void OnVideoPlayerError(VideoPlayer source, string message)
    {
        Debug.LogError("Video Player Error: " + message);
        uiLayer.SetActive(true);
        appState.lockMovement = true;
    }
}
