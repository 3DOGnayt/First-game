using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int _ammo = 20;

    private void Update()
    {
        transform.Rotate(0, 0.8f, 0f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<ITakeAmmo>().TakeAmmo(_ammo);
            Destroy(gameObject);
        }
    }
}
