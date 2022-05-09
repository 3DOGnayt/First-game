using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    /// не используется 

    //[SerializeField] private BossArea _bossarea = null;
    //[SerializeField] private Transform _Wallpos = null;           Это все мои попытки, а ведь можно было все сделать ПРОЩЕ.
    //[SerializeField] private Wall _Wall = null;

    //public bool isActive = false;

    //private void OnEnable()
    //{
    //    CDoor();
    //}

    //private void CDoor()
    //{        
    //    transform.Translate(new Vector3(0, +10, 0));
    //}
        
    //private void Update()
    //{
    //    if (!isActive) return;
    //    Instantiate(_Wall, _Wallpos.position, _Wallpos.rotation);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //        _bossarea.isActive = true;

    //}
}
