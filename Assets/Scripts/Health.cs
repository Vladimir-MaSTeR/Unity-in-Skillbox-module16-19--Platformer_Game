using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private HealsBar healsBar;


    private float currentHealth;
    private bool isAlive;


    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
        healsBar.gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healsBar.SetHealthValue((int)currentHealth, (int)maxHealth);
        ChekIsAlive();
    }

    private void ChekIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
        } else
        {
            isAlive = false;
        }
    }
}
