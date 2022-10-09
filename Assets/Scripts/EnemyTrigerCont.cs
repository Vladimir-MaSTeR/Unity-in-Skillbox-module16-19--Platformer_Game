using System;
using UnityEngine;

public class EnemyTrigerCont : MonoBehaviour
{

    public static Action onStartEnemyTriger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onStartEnemyTriger?.Invoke();
            Debug.Log("Игрок задел EnemyTrigerCont");
        }
    }
}
