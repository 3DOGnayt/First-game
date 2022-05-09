using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    [SerializeField] private Watcher _wa = null;
    [SerializeField] private Transform _target = null;
    [SerializeField] private float _speed = 1;

    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            _wa.isActive = true;       
    }
    private void Watchers()
    {
        if (isActive == true)
        {
            var dir = _target.position - transform.position;
            var newDir = Vector3.RotateTowards(transform.forward, dir, _speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    private void Update()
    {
        Watchers();
        //var dir = _target.position - transform.position;
        //var newDir = Vector3.RotateTowards(transform.forward, dir, _speed * Time.deltaTime, 0f);
        //transform.rotation = Quaternion.LookRotation(newDir);
        //transform.rotation = Quaternion.LookRotation(_target.position - transform.position);
    }

}
