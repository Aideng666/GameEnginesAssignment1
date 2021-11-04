using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevelScene()
    {
        if (!FindObjectOfType<CommandInvoker>().GetLevelSaved())
        {
            Debug.Log("No level has been saved yet");
            return;
        }

        SceneManager.LoadScene("Loaded Level");
    }

    public void LoadLevelCreator()
    {
        SceneManager.LoadScene("LevelCreator");
    }

    public void LoadExampleLevel()
    {
        SceneManager.LoadScene("ExampleLevel");
    }
}
