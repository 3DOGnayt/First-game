using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camwc : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;
    private Vector3 _offset = Vector3.zero;
    private Vector3 _angleOffset = Vector3.zero;

   
    private void Awake()
    {
        _offset = transform.position - _player.transform.position;
        _angleOffset = transform.rotation.eulerAngles;
    }

    void LateUpdate()
    {
        transform.position = _player.transform.position - _player.transform.forward * _offset.magnitude;
        transform.position = new Vector3(transform.position.x, _offset.y, transform.position.z);
        transform.rotation = Quaternion.Euler(_angleOffset.x, _player.transform.rotation.eulerAngles.y, _angleOffset.z);
    }
}
