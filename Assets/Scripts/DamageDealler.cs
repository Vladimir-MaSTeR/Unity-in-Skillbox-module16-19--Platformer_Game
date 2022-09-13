using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private int damage = 35;
    //[SerializeField] private GameManager gameManagerScript;

    private int currentDamage;

    //работа с событиями
    public static Func<int> onSpearDamage;
    public static Action onCollisionWithEnemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentDamage = (int)(onSpearDamage?.Invoke());
            onCollisionWithEnemy?.Invoke();

            collision.gameObject.GetComponent<Health>().TakeDamage(currentDamage);
            Debug.Log( $"Монстру нанесён урон метательным оружием на {currentDamage} урона");
             Destroy(gameObject);

        }
    }


    public int GetStartDamage()
    {
        return this.damage;
    }
}
