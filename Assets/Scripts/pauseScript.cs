using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    public GameObject menuObject;
    public bool isPaused = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuObject.SetActive(!menuObject.activeInHierarchy);
            isPaused = !isPaused;

            if (isPaused && playerController.Instance.music == 1)
            {
                Time.timeScale = 0f;
                FindObjectOfType<soundManager>().Pause("music(1)");
            }
            if (!isPaused && playerController.Instance.music == 1)
            {
                Time.timeScale = 1f;
                FindObjectOfType<soundManager>().Resume("music(1)");
            }
            if (isPaused && playerController.Instance.music == 2)
            {
                Time.timeScale = 0f;
                FindObjectOfType<soundManager>().Pause("music(2)");
            }
            if (!isPaused && playerController.Instance.music == 2)
            {
                Time.timeScale = 1f;
                FindObjectOfType<soundManager>().Resume("music(2)");
            }
        }
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        if (!isPaused)
        {
            Time.timeScale = 1f;
        }

    }
    public void Unpause()
    {
        menuObject.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        menuObject.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
}
