using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour, Itakedamage
{
    [SerializeField] private int _hp = 200;
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform Player;

    private Animator _animator = null;
    private AudioSource _audioSource = null;
    private bool _isAlive = true;
    private GameObject _boss = null;
    private Vector3 _direction = Vector2.zero;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        enemy.SetDestination(Player.position);
        if (_direction != Vector3.zero)
            _animator.SetBool("GoBo 1", true);
        //else
        //    _animator.SetBool("GoBo 1", false);
    }

    private void Follow(GameObject player)
    {
        var direction = player.transform.position - _boss.transform.position;
        var newDirection = Vector3.RotateTowards(_boss.transform.forward, direction, Time.deltaTime, 0f);
        _boss.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void Attack()
    {
       
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
