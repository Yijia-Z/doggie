using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Exit : MonoBehaviour
{

    public void exit_game()
    {
        DatingProgress.ClearKeys();
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;

        #else
        Application.Quit();

        #endif
    }
}
