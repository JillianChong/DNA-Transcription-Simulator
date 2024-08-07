using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject nucleotide;
    
    public void dropNucleotide()
    {
        GameObject newNucleotide = Instantiate(nucleotide);
        // gravity so it falls
        Rigidbody newRb = newNucleotide.AddComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        dropNucleotide();
    }
    
}
