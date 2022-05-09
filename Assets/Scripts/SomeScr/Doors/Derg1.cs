using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derg1 : MonoBehaviour
{
    [SerializeField] private Door _door = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            _door.isActive = true;
        Destroy(gameObject);
    }
}
