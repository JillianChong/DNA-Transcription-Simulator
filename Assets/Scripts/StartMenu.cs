using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    public GameObject instructionUI;
    public GameObject startScreenUI;

    // Start is called before the first frame update
    void Start()
    {
        instructionUI.SetActive(false);
    }

    public void StartGame()
    {
        instructionUI.SetActive(false);
        startScreenUI.SetActive(false);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Initiation");
    }

    public void LoadInstructions()
    {
        instructionUI.SetActive(true);
        startScreenUI.SetActive(false);
    }

    public void UnloadInstructions()
    {
        instructionUI.SetActive(false);
        startScreenUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
