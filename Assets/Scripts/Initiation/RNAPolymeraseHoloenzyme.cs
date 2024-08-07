using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RNAPolymeraseHoloenzyme : MonoBehaviour
{
    private bool collision10 = false;
    private bool collision35 = false;

    public GameObject txt;
    public GameObject txt2;
    public GameObject button;

    void Update()
    {
        if (collision10 && collision35)
        {
            GetComponent<AudioSource>().Play();

            // activate untwisted DNA
            GameObject[] inactive = FindObjectsOfType<GameObject>(true).Where(go => !go.gameObject.activeInHierarchy).ToArray();
            GameObject untwisted = null;

            foreach (GameObject gameObj in inactive)
            {
                if (gameObj.name.Equals("UntwistedStrand"))
                {
                    untwisted = gameObj;
                }
            }


            untwisted.SetActive(true);

            txt.SetActive(true);
            txt2.SetActive(true);
            button.SetActive(true);



            // destroy holoenzyme, twisted DNA
            Destroy(GameObject.Find("TwistedStrand"));
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollEnter");
        switch (other.gameObject.tag)
        {
            case "region10":
                collision10 = true;
                break;
            case "region35":
                collision35 = true;
                break;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "region10":
                collision10 = false;
                break;
            case "region35":
                collision35 = false;
                break;
        }
    }
    
}
