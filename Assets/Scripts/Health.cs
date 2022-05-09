using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health = 10;

    private void Update()
    {
        transform.Rotate(0, 0.8f, 0f);       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<ITakeHp>().TakeHp(_health);
            Destroy(gameObject);
        }        
    }
}
