using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{    
    [SerializeField] private BossArea _Ba = null;
    [SerializeField] private GameObject wall = null;

    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            _Ba.isActive = true;
        Destroy(gameObject);
       wall.transform.Translate(new Vector3(0, +10.5f, 0));
    }
}
