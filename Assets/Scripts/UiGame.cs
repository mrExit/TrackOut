using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGame : MonoBehaviour
{
   
    int currentCarHP;
    bool isLose = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;        
        currentCarHP = ParametrCar.HP;
    }

 
  
}
