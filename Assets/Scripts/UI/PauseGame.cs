using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseScreen;
    public FirstPersonLook firstPersonLook;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        firstPersonLook.sensitivity = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1f;
                pauseScreen.SetActive(false);
                firstPersonLook.sensitivity = 2f;
            }
            else
            {
                isPaused = true;
                Time.timeScale = 0f;
                pauseScreen.SetActive(true);
                firstPersonLook.sensitivity = 0f;
            }
        }
    }
}
