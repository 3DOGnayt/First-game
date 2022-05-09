using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy = null;
    //[SerializeField] private GameObject _med = null;
    //[SerializeField] private GameObject _ammo = null;    
    [SerializeField] private Transform _spawnerposition = null;

    void Start()
    {
        Instantiate(_enemy, _spawnerposition.position, _spawnerposition.rotation);
        //Instantiate(_med, _spawnerposition.position, _spawnerposition.rotation);
        //Instantiate(_ammo, _spawnerposition.position, _spawnerposition.rotation);
    }

}
