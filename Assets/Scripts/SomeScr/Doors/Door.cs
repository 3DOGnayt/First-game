using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isActive = false;
    //public GameObject dver;

    private void Update()
    {
        if (!isActive) return;
        Destroy(gameObject, 2);

        //if (!isActive || Input.GetAxis("Vertical") != 0)
        //{
        //    transform.localPosition = new Vector3(0f, -10f, 0f);
        //}
        //else
        //{
        //    transform.localPosition = new Vector3(0f, -10f, 0f);
        //}
    }

   
}