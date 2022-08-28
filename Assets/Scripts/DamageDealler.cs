using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float damage = 35;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damagebl"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Debug.Log("Нанесён Урон");
            
        }

       // Destroy(gameObject);

    }
}
