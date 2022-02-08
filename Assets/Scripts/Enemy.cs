using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform _positionPlayer;
    [SerializeField] GameObject _bullet;
    Vector3 _targetPosition;
    [SerializeField] [Range(1,50)] int _hp = 5;
    [SerializeField] [Range(0.2f, 5)] float _pausedMove = 3;
    // Start is called before the first frame update
    private void Awake()
    {
             
    }
    void Start()
    {
        StartCoroutine(Move(_pausedMove));
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Damage();
        }
    }
    private void Fire()
    {
        _positionPlayer = GameObject.FindWithTag("Player").transform;
        GameObject bullet = Instantiate(_bullet);
        bullet.SetActive(true);
        bullet.transform.position = new Vector3(transform.position.x,transform.position.y+2f, transform.position.z);
        bullet.transform.LookAt(_positionPlayer, bullet.transform.forward);        
    }
    private void Damage()
    {    
        _hp--;
        if (_hp < 1)
        {
            Destroy(gameObject);
            GameController.EnemyDestroyed();
        }
    }

    IEnumerator Move(float pausedForSeconds)
    {
       
         _targetPosition =new Vector3(Random.Range(-5f, 5f), transform.position.y, Random.Range(0f, 5f));        
        yield return new WaitForSeconds(pausedForSeconds);
        Fire();
        StartCoroutine(Move(pausedForSeconds));
    }
}
