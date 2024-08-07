using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{

    public Transform theDest;

    void OnMouseDown()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("GameObjDestination").transform;
    }

    void OnMouseUp()
    {
        GetComponent<Collider>().enabled = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

}
