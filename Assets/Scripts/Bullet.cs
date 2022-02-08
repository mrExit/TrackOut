using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] [Range(1,30)]float _speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime*_speed;
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
  
}
