using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toStart : MonoBehaviour
{
    
    public void ToStart()
    {
       SceneManager.LoadScene("StartGame");
    }

    void OnMouseDown()
    {
        ToStart();
    }
}

