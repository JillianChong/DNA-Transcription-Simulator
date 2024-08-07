using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toElongation : MonoBehaviour
{

    public void ToElongation()
    {
        SceneManager.LoadScene("Elongation");
    }

    void OnMouseDown()
    {
        ToElongation();
    }
}

