using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombscr : MonoBehaviour
{
    public GameObject _boom = null;
    [SerializeField] private Transform _spawnerposition = null;

    private int _damagebomb = 0;
    
    public void Init1(int damage, Transform target)
    {
        _damagebomb = damage;
        //Destroy(gameObject, 3);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<Itakedamage>().Takedamage(_damagebomb);
        }
        else if (other.CompareTag("Player"))
        {
            //_boom = Instantiate(_boom, _spawnerposition.position, _spawnerposition.rotation);
            other.GetComponent<Itakedamage>().Takedamage(_damagebomb);
        }
        Destroy(gameObject);
        _boom = Instantiate(_boom, _spawnerposition.position, _spawnerposition.rotation);
        Destroy(_boom, 0.4f);

        //if (other.CompareTag("Player"))
        //{
        //    other.GetComponent<Itakedamage>().Takedamage(_damagebomb);
        //}        
        //Destroy(gameObject);
    }

}
