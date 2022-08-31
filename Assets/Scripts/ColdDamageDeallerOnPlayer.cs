using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdDamageDeallerOnPlayer : MonoBehaviour
{
    [SerializeField] private float damage = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Debug.Log("Монстру нанесён урон холодным");
        }
    }
}
