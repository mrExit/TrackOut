using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] [Min (0)]  float _speedWeapons;
    [SerializeField] AudioSource _audio;
    private void Start()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        _audio.Play();
        GameObject bullet = Instantiate(_bullet);
        bullet.transform.position = transform.position+new Vector3(0,0,1);       
        yield return new  WaitForSeconds(_speedWeapons);
        StartCoroutine(Fire());
    }

}
