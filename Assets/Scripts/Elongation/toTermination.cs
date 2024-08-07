using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toTermination : MonoBehaviour
{

    public void ToTermination()
    {
        SceneManager.LoadScene("Termination");
    }

    void OnMouseDown()
    {
        ToTermination();
    }
}

