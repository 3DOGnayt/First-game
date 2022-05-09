using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    //[SerializeField] private int _reloadspd = 1;

    public bool isActive = false;    
    private int _bulletinmagazine = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            StartReloading();        
    }
    private void StartReloading()
    {
        _bulletinmagazine = 0;
        StartCoroutine(Reloading());
    }

    IEnumerator Reloading()
    {
        while (_bulletinmagazine < 10) // пока колиество пуль в магазине < 10, можно будет нажать на R и пополнить к-во пуль до 7. 
        {
            _bulletinmagazine++;
            if(_bulletinmagazine == 10)
            yield return null;
        }
    }
}
