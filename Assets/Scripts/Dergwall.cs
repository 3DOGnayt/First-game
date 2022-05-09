using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dergwall : MonoBehaviour
{
    [SerializeField] private Dergwall _dw = null;
    [SerializeField] private GameObject door = null;

    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            _dw.isActive = true;
        door.transform.Translate(new Vector3(0, -11, 0));
    }
}
