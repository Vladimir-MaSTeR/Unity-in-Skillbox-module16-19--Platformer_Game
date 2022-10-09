using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int valueCreateEnemyOneWave;
    [SerializeField] private int valueCreateEnemyTwoWave;


    private int currentValueEnemyOneWave = 0;
    private int currentValueEnemyTwoWave = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentValueEnemyOneWave = 0;
        currentValueEnemyTwoWave = 0;
    }


    private void OnEnable()
    {
        Enemy.onDeathEnemy += RespawnEnemy;
    }

    private void OnDisable()
    {
        Enemy.onDeathEnemy -= RespawnEnemy;
    }

    public void RespawnEnemy()
    {
        if (currentValueEnemyOneWave < valueCreateEnemyOneWave)
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            currentValueEnemyOneWave++;
        }

        if (currentValueEnemyOneWave >= valueCreateEnemyOneWave + 5 && currentValueEnemyTwoWave < valueCreateEnemyTwoWave)
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            currentValueEnemyTwoWave++;
        }
    }
}
