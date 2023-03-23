using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] GameObject startButton;

    public void SwitchScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
