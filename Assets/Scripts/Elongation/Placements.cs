using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Placements : MonoBehaviour
{
    private static int position = 0;
    private static GameObject RNAPolymerase;

    public AudioSource correct;
    public AudioSource incorrect;

    public GameObject txt;
    public GameObject txt2;
    public GameObject button;

    private string[] nucleotideSequence = 
    {
        "guanine",
        "cytosine",
        "cytosine",
        "adenine",
        "uracil",
        "cytosine",
        "guanine",
        "guanine",
        "adenine"
    };

    private static bool[] sequence = new bool[9];

    void Start()
    {
        RNAPolymerase = GameObject.Find("RNAPolymerase");
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (position == 0 || sequence[position - 1])
        {
            if (other.gameObject.tag.Equals(nucleotideSequence[position]))
            {
                Debug.Log(position);
                // delete other
                Destroy(other.gameObject);
                
                // attach nucleotide to placement
                GameObject[] inactive = FindObjectsOfType<GameObject>(true).Where(go => !go.gameObject.activeInHierarchy).ToArray();
                GameObject curNucleotide = null;

                foreach (GameObject nucleotide in inactive)
                {
                    if (nucleotide.tag.Equals((position + 1).ToString()))
                    {
                        curNucleotide = nucleotide;
                    } 
                }

                correct.Play();
                curNucleotide.SetActive(true);

                // move polymerase
                RNAPolymerase.gameObject.transform.Translate(0, 0, 0.6f);
                sequence[position] = true;
                position++;
                
                // destroy self script
                Destroy(this);
            }
        }

        else
        {
            // add incorrect nucleotide sound effect here if needed
            incorrect.Play();
        }

        if(sequence[7/*8*/])
        {
            txt.SetActive(true);
            txt2.SetActive(true);
            button.SetActive(true);
        }
    }
}

//Add these lines for when the scene is over and they can move on:
//txt.SetActive(true);
//button.SetActive(true);
