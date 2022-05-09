using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour, Itakedamage
{
    [SerializeField] private int _hp = 40;
    [SerializeField] private Transform Player;
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] public float speed = 4f;
    
    private bool _isAlive = true;
    //Rigidbody rig;
    //private float distance;
    //private float radiusOfview = 20;
    //private float attackDistance = 1.5f;

    private void Awake()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();       
    }    
    private void Start()
    {
        //rig = GetComponent<Rigidbody>();
        enemy = GetComponent<NavMeshAgent>();
        //_target = GameObject.Find("Player");
        //navMeshAgent.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        //Vector3 pos = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        //rig.MovePosition(pos);
        //transform.LookAt(Player);
        //distance = Vector3.Distance(Player.position, transform.position);

        enemy.SetDestination(Player.position);

        //if (distance > radiusOfview)
        //{
        //    GetComponent<NavMeshAgent>().enabled = false;
        //    GetComponent<Animator>().Play("Wait");
        //}

        //if (distance < radiusOfview & distance >= attackDistance)
        //{
        //    GetComponent<NavMeshAgent>().enabled = true;
        //    GetComponent<NavMeshAgent>().destination = Player.position;
        //    GetComponent<Animator>().Play("Walk");
        //}

        //if (distance < attackDistance)
        //{
        //    GetComponent<NavMeshAgent>().enabled = false;
        //    GetComponent<Animator>().Play("Attack");
        //}


        //if (_playerInmyeyes)
        //    navMeshAgent.SetDestination(_target.transform.position);
        //else if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        //{
        //    m_Currentwpi = (m_Currentwpi + 1) % waypoints.Length;
        //    navMeshAgent.SetDestination(waypoints[m_Currentwpi].position);
        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    PlayerInmyeyesrly(other);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    PlayerInmyeyesrly(other);
    //}

    //private void PlayerInmyeyesrly(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //        _playerInmyeyes = !_playerInmyeyes;
    //}

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
