using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseScreen : MonoBehaviour
{
    public static bool isPaused = false;
    public FirstPersonController controller;

    public PlayerData playerData;
    public GameObject player;
    
    public GameObject playCanvas;
    public GameObject pauseCanvas;

    private void Start()
    {
        if (GameObject.Find("_PlayerData") != null)
        {
            playerData = GameObject.Find("_PlayerData").GetComponent<PlayerData>();
            Destroy(GameObject.Find("TempData"));
        }
        else
        {
            playerData = GameObject.Find("TempData").GetComponent<PlayerData>();
        }

        player = GameObject.Find("Player Variant");
        controller = player.gameObject.GetComponent<FirstPersonController>();
        pauseCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        playCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller.enabled = true;
    }

    void Pause()
    {
        playCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        controller.enabled = false;
    }

    public void BackToCheckpoint()
    {
        Resume();
        player.transform.position = playerData.checkpoint.position;
        player.transform.rotation = playerData.checkpoint.rotation;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
