using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, Itakedamage
{
    [SerializeField] private int _hp = 40;
    [SerializeField] public Transform[] waypoints;
    
    private bool _isAlive = true;     
    private bool _playerInmyeyes = false;     
    private int m_Currentwpi;
    private NavMeshAgent navMeshAgent = null;
    private GameObject _target = null;

     private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();       
    }    
    private void Start()
    {
        _target = GameObject.Find("Player");
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        if (_playerInmyeyes)
            navMeshAgent.SetDestination(_target.transform.position);
        else if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            m_Currentwpi = (m_Currentwpi + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_Currentwpi].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInmyeyesrly(other);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInmyeyesrly(other);
    }

    private void PlayerInmyeyesrly(Collider other)
    {
        if (other.CompareTag("Player"))
            _playerInmyeyes = !_playerInmyeyes;
    }

    public void Takedamage(int damage)
    {
        if (_isAlive)
        {
            _hp -= damage;
            if (_hp <= 0)
                Death();
        }
    }

    private void Death()
    {
        _isAlive = false;
        Destroy(gameObject);    
    
    }
}
