using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<PlayerMovement>().GetLevelComplete())
        {
            canvas.enabled = false;
        }
        else
        {
            canvas.enabled = true;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
    }
}
