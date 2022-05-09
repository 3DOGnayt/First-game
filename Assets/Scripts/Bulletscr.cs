using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscr : MonoBehaviour
{
    [SerializeField] private float _speed = 60;
    private int _damage = 0;

    public void Init(int damage, Transform target)

    {
        _damage = damage;
        Destroy(gameObject, 10);    
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<Itakedamage>().Takedamage(_damage);        
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<Itakedamage>().Takedamage(_damage);
        }
        Destroy(gameObject);
        
    }

}
