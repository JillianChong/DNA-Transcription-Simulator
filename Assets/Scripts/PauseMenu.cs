using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public RawImage crossHair;

    // Start is called before the first frame update
    void Start()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        //if (sceneName != "Elongation")
        //{
            // Uncomment line below for crosshair
            crossHair.enabled = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("Initiation");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Elongation");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Termination");
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        //if (!SceneManager.GetActiveScene().name.Equals("Elongation"))
        //{
            // Uncomment the 3 lines below for crosshair
            Cursor.lockState = CursorLockMode.Locked; // locks cursor to middle of screen 
            Cursor.visible = false; // makes mouse cursor invisible so you just see crosshair
            crossHair.enabled = true; // enables crosshair
        //}
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        //if (sceneName != "Elongation")
        //{
            // Uncomment the 3 lines below for crosshair
            Cursor.lockState = CursorLockMode.None; // unlocks cursor so player can press resume if necessary 
            Cursor.visible = true; // makes mouse cursor visible
            crossHair.enabled = false; // disables crosshair so it's not block screen
        //}
    }
}
