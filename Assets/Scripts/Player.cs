using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, Itakedamage, ITakeHp, ITakeAmmo
{
    [SerializeField] private GameObject settingsMenu = null;
    [Space]
    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _bulletpref = null;
    [SerializeField] private GameObject _bombpref = null;
    [SerializeField] private Transform _bulletStartPosition = null;
    [SerializeField] private Transform _bombStartPosition = null;
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _rotspeed = 20;
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _ammo = 50;
    [SerializeField] private int _bulletinmagazine = 10;
    [SerializeField] private float _bulletforse = 0.001f;
    [SerializeField] private float _jumpforse = 100;
    [SerializeField] private float _jumpspeed = 0.1f;

    public Text IndicatorHP;
    public Text IndicatorAmmo;
    private bool _fire = false;
    private bool _reloud = false;
    private bool isGrounded = true;
    private bool _fire1 = false;
    private int _damage = 4;
    private int _damagebomb = 20;
    public bool isActive = false;
    private bool _isAlive = true;
    private Vector3 _direction = Vector2.zero;
    private Transform _target = null;
    
    private Animator _animator = null;
    private AudioSource _audioSource = null;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        //_target = GameObject.FindGameObjectWithTag("enemy").transform;
    }
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_ammo != 0)
                Reload();            
        }

        if (Input.GetMouseButtonDown(0))
            _fire = true;
        if (Input.GetMouseButtonDown(1))
            _fire1 = true;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        _direction.z = Input.GetAxis("Vertical");
        _direction.x = Input.GetAxis("Horizontal");        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _player.transform.position += _player.transform.up * _jumpforse * _jumpspeed;
            isGrounded = false;
        }

        //IndicatorHP.text = "" + _hp;
        //IndicatorAmmo.text = "" + _ammo + " |";
        //IndicatorM.text = "" + _bulletinmagazine;                
    }
  
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Flour"))
            isGrounded = true;
    }
    private void FixedUpdate()
    {
        if (_bulletinmagazine <= 10)
        {
            if (_fire && _bulletinmagazine != 0)
            {
                Fire();
                _bulletinmagazine = _bulletinmagazine - 1;
            } 
        }
        
        if (_reloud && _ammo != 0)
        {
            _ammo = _ammo - 10;
        }
        else _reloud = false;

        if (_fire1)
            Firebomb();
        Move();
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal1") * _rotspeed * Time.deltaTime, 0));

        IndicatorHP.text = "" + _hp;
        IndicatorAmmo.text = "" + _ammo + " | " + _bulletinmagazine;
    }
    
    private void Move()
    {
        if (_direction != Vector3.zero)
            _animator.SetBool("Go", true);
        else
            _animator.SetBool("Go", false);

        var speed = _direction * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
    }
    
    private void Fire()
    {
        _animator.SetBool("Fire", true);
        var bullet = GameObject.Instantiate(_bulletpref, _bulletStartPosition.position,
            _bulletStartPosition.transform.rotation).GetComponent<Bulletscr>();
        bullet.Init(_damage, _target);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletforse, ForceMode.Impulse);
        _audioSource.Play();
        _fire = false;
        Invoke("EndFire", 0.5f);
    }
    
    private void EndFire()
    {
        _animator.SetBool("Fire", false);
    }
    private void Reload()
    {
        StartCoroutine(Reloading());
    }

    IEnumerator Reloading()
    {        
        _reloud = true;
        while (_bulletinmagazine == 0) 
        {
            _bulletinmagazine = _bulletinmagazine + 10;
            if (_bulletinmagazine == 10)
                yield return null;            
        }
        _reloud = false;
    }

    private void Firebomb()
    {
        var bomb = GameObject.Instantiate(_bombpref, _bombStartPosition.position, _bombStartPosition.transform.rotation).GetComponent<Bombscr>();
        bomb.Init1(_damagebomb, _target);
        _fire1 = false;

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
        _animator.SetBool("Death", true);
        _isAlive = false;  
    }

    public void TakeHp(int health)
    {
        _hp += health;
    } 
    public void TakeAmmo(int ammo)
    {
        _ammo += ammo;
    }   
    
}
