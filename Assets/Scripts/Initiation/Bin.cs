using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bin : MonoBehaviour
{
    // alpha, alpha, beta, beta prime, sigma factor
    bool[] components = new bool[5];
    
    void Update()
    {
        // checks if all items are present
        bool allPresent = true;
        
        foreach (bool component in components)
        {
            if (!component)
            {
                allPresent = false;
            }
        }

        // makes holoenzyme appear
        // disables bin
        if (allPresent)
        {
            GameObject[] inactive = FindObjectsOfType<GameObject>(true).Where(go => !go.gameObject.activeInHierarchy).ToArray();
            GameObject holoenzyme = null;

            foreach (GameObject gameObj in inactive)
            {
                if (gameObj.name.Equals("RNAPolymeraseHoloenzyme"))
                {
                    holoenzyme = gameObj;
                }
            } 
            
            holoenzyme.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // checks other type, adds to component array
        switch (other.gameObject.tag)
        {
            case "alpha":
                if (!components[0])
                {
                    GetComponent<AudioSource>().Play();

                    components[0] = true;
                    Destroy(other.gameObject);
                } else if (!components[1])
                {
                    GetComponent<AudioSource>().Play();

                    components[1] = true;
                    Destroy(other.gameObject);
                }
                break;
            
            case "beta":
                if (!components[2])
                {
                    components[2] = true;
                    Destroy(other.gameObject);
                    GetComponent<AudioSource>().Play();
                }
                break;
            
            case "betaPrime":
                if (!components[3])
                {
                    components[3] = true;
                    Destroy(other.gameObject);
                    GetComponent<AudioSource>().Play();
                }
                break;
            
            case "sigmaFactor":
                if (!components[4])
                {
                    components[4] = true;
                    Destroy(other.gameObject);
                    GetComponent<AudioSource>().Play();
                }
                break;
        }
    }
}
