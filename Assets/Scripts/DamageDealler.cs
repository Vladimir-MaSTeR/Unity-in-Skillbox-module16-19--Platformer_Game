using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float damage = 35;
   // [SerializeField] private GameManager gameManagerScript;

    private float currentDamage;

    private void Start()
    {
        currentDamage = damage;
        //gameManagerScript.SetCurrentDamageSpearText((int)currentDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           // currentDamage = gameManagerScript.GetCurrentDamageSpearText();

            collision.gameObject.GetComponent<Health>().TakeDamage(currentDamage);
            Debug.Log("Монстру нанесён урон метательным оружием");
             Destroy(gameObject);

        }
    }


    public float GetCurrentDamage()
    {
        return this.currentDamage;
    }

    public void SetCurrentDamage(float damage)
    {
        this.currentDamage = damage;
    }
}
