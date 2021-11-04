using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] List<Text> tutorialTexts;

    bool hasMovedLeft;
    bool hasMovedRight;
    bool hasJumped;
    bool tutorialCompleted;

    void Start()
    {
        tutorialTexts[1].enabled = false;
        tutorialTexts[2].enabled = false;
    }

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

        if (hasMovedLeft && hasMovedRight && !hasJumped)
        {
            tutorialTexts[0].enabled = false;
            tutorialTexts[1].enabled = true;
        }
        if (hasJumped && !tutorialCompleted)
        {
            tutorialTexts[1].enabled = false;
            tutorialTexts[2].enabled = true;
        }
        if (tutorialCompleted)
        {
            tutorialTexts[0].enabled = false;
            tutorialTexts[1].enabled = false;
            tutorialTexts[2].enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            hasMovedLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            hasMovedRight = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasMovedLeft && hasMovedRight)
        {
            hasJumped = true;
        }

        if (hasJumped && FindObjectOfType<PlayerMovement>().gameObject.transform.position.y > 5)
        {
            tutorialCompleted = true;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Loaded Level");
    }

    public void LoadLevelCreator()
    {
        SceneManager.LoadScene("LevelCreator");
    }
}
