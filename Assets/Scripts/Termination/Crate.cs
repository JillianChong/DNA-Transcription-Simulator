using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private int atpCounter = 0;
    private GameObject[] atp = {null, null, null, null };
    
    private GameObject rho = null;

    public GameObject txt;
    public GameObject txt2;
    public GameObject button;

    public GameObject disappear;

    private int movementCounter = 0;
    private Vector3[] movements =
    {
        new Vector3(-3.625f, 1.313f, 3.815f),
        new Vector3(-3.625f, 2.118f, 3.815f),
        new Vector3(-2.729f, 2.118f, 3.815f),
        new Vector3(-1.451f, 2.118f, 3.815f)
    };

    private void Start()
    {
        rho = GameObject.Find("Rho");
    }

    // Update is called once per frame
    void Update()
    {
        if (atpCounter == 4)
        {
            rho.transform.position = movements[movementCounter];
            movementCounter++;

            // resetting atps
            foreach (GameObject _atp in atp)
            {
                Destroy(_atp);
            }

            atpCounter = 0;
        }

        if (movementCounter == movements.Length)
        {
            movementCounter = 0;
            
            // snip
            Destroy(GameObject.Find("RNA"));

            disappear.SetActive(false);

            // end is here
            txt.SetActive(true);
            txt2.SetActive(true);
            button.SetActive(true);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("atp"))
        {
            GetComponent<AudioSource>().Play();

            bool all = false;

            foreach (GameObject atp_ in atp)
            {
                if (atp_ != null && other.gameObject.GetInstanceID() == atp_.GetInstanceID())
                {
                    all = true;
                }
            }

            if (!all)
            {
                atp[atpCounter] = other.gameObject;
                atpCounter++;
                Debug.Log("Entered: " + atpCounter);

            }
        }
    }

}
