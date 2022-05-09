using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flour : MonoBehaviour
{
    [SerializeField] private Flour _flour = null;    
    
    public bool isGrounded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            _flour.isGrounded = true;
    }
}
