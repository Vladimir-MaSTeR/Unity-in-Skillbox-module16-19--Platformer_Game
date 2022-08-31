using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDeallerOnEnemy : MonoBehaviour
{
    [SerializeField] private float damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Debug.Log("Играку нанесён урон");

        }

    }
}
