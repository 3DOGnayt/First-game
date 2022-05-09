using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour, Itakedamage
{
    [SerializeField] private int _hp = 40;
    [SerializeField] private Transform Player;
    [SerializeField] private NavMeshAgent enemy;
    ///[SerializeField] public float speed = 4f;
    
    private bool _isAlive = true;
    public LayerMask whatisPlayer, whatisGround;

    private Animator _animator = null;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float WalkPointRange;

    public float timeBetweenAttack;
    bool alreadyAttack;

    public float sightRange, attackRange;
    public bool playerInSingrange, playerInAttackRange;

    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSingrange = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatisPlayer);

        if (!playerInSingrange && !playerInAttackRange) Patroling();
        if (playerInSingrange && !playerInAttackRange) Chase();
        if (playerInSingrange && playerInAttackRange) Attack();

    }

    private void Patroling()
    {
        if (!walkPointSet) Search();

        if (walkPointSet)
            enemy.SetDestination(walkPoint);

        Vector3 distanceToWalckPoint = transform.position - walkPoint;

        if (distanceToWalckPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void Search()
    {
        float a = Random.Range(-WalkPointRange, WalkPointRange);
        float s = Random.Range(-WalkPointRange, WalkPointRange);

        walkPoint = new Vector3(transform.position.x + a, transform.position.y, transform.position.z + s);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatisGround))
            walkPointSet = true;
    }

    private void Chase()
    {
        enemy.SetDestination(Player.position);
    }

    private void Attack()
    {
        enemy.SetDestination(transform.position);

        transform.LookAt(Player);

        if (!alreadyAttack)
        {
            _animator.SetBool("Attack", true);




            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);     
        }
    }

    private void ResetAttack()
    {
        alreadyAttack = false;    
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
