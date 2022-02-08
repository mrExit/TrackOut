using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject _enemy;
    [SerializeField] [Range(1,5)] int _numberOfEnemies;
    [SerializeField] GameObject _winUI;
    [SerializeField] Text _challengeText;
    [SerializeField] Text _moneyText;


    static int countEnemies;
    static GameObject winUI;
    void Awake()
    {
        Initialization();
    }
 
    private void Update()
    {
        _moneyText.text = ParametrCar.Money.ToString();
    }

    private void CreatedEnemies(int numberOfEnemies=1)
    {
        
       for (int x = 1; x<=numberOfEnemies; x++)
        {
            Debug.Log("+++");
            Instantiate(_enemy).transform.position = new Vector3(Random.Range(-5f, 5f), 1.3f, Random.Range(0f, 5f));
        }
    }
    static public void EnemyDestroyed()
    {
        countEnemies--;
        ParametrCar.Money += 100;
        if (countEnemies==0)
        {
           Time.timeScale = 0;
            Instantiate(winUI);
        }
    }
    private void Initialization()
    {
        countEnemies = _numberOfEnemies;
        winUI = _winUI;
        CreatedEnemies(_numberOfEnemies);
        _moneyText.text = ParametrCar.Money.ToString();
        _challengeText.text = $"”ничтожить врагов: {_numberOfEnemies}";
    }

}
