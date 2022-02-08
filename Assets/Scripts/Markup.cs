using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Markup : MonoBehaviour
{
    [SerializeField] List<Transform> _lines;
    [SerializeField] int _speed;

    
    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        for (int x = 0; x < _lines.Count; x++)
        {
            _lines[x].position += new Vector3(0, 0, 1) * Time.deltaTime * _speed;
            if (_lines[x].localPosition.z <= -19.28943)
            {
                _lines[x].position += new Vector3(0, 0, 24);
            }
        }
    }
}
