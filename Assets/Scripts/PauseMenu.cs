using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject pauseFirstButton;
    public GameObject ratBall;

    private void Start()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire3"))
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        ratBall.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        ratBall.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<MenuController>().SelectFirstMenuButton(pauseFirstButton);
    }

    public void SetMouseSensitivity(float sensitivity)
    {
        FindObjectOfType<CameraManager>().mouseSensitivity = sensitivity;
        PlayerPrefs.SetFloat("CameraSensitivity", sensitivity);
    }

    public void SetController(bool isUsingController)
    {
        if (isUsingController) {
            FindObjectOfType<CameraManager>().Xaxis = "CameraX";
            FindObjectOfType<CameraManager>().Yaxis = "CameraY";
            PlayerPrefs.SetString("ControlSettingX", "CameraX");
            PlayerPrefs.SetString("ControlSettingY", "CameraY");
        } else {
            FindObjectOfType<CameraManager>().Xaxis = "Mouse X";
            FindObjectOfType<CameraManager>().Yaxis = "Mouse Y";
            PlayerPrefs.SetString("ControlSettingX", "Mouse X");
            PlayerPrefs.SetString("ControlSettingY", "Mouse Y");
        }
    }
}
