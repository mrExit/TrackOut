using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour{
     
    [SerializeField] [Min (0)] float _speed=1;
    [SerializeField] Slider _hpSlaider;
    [SerializeField] GameObject _loseUI;
    [SerializeField] AudioSource _audio;    


    private int HP = ParametrCar.HP;
    
    private bool _isLive = true;
    void Start()
    {        
        _hpSlaider.value = (float)HP / (float)ParametrCar.HP;
    }
    private void Update()
    {
        Move();    
        
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
            //_rb.AddForce(new Vector3(0, 0, 0.1f), ForceMode.Impulse);
            transform.position += new Vector3(0, 0, 1)*Time.deltaTime*_speed;
         else if (Input.GetKey(KeyCode.S))
            //_rb.AddForce(new Vector3(0, 0, -0.1f), ForceMode.Impulse);
        transform.position -= new Vector3(0, 0, 1) * Time.deltaTime*_speed;
        if (Input.GetKey(KeyCode.D))
            //_rb.AddForce(new Vector3(0.1f, 0, 0), ForceMode.Impulse);
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime*_speed;        
        else if (Input.GetKey(KeyCode.A))
            //_rb.AddForce(new Vector3(-0.1f, 0, 0), ForceMode.Impulse);
        transform.position -= new Vector3(1, 0, 0) * Time.deltaTime*_speed;
    }
    private void OnCollisionEnter(Collision collision)
    {       

        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            Destroy(collision.gameObject);
            CountHP();       
        }
    }
    private void CountHP()
    {
        HP--;
        _audio.Play();
        _hpSlaider.value = (float)HP / (float)ParametrCar.HP;
        if ((HP <= 0) && _isLive)
            Lose();
    }
    private void Lose()
    {    
        {
            _isLive = false;
            Time.timeScale = 0;
            Instantiate(_loseUI);
        }
    }


}
