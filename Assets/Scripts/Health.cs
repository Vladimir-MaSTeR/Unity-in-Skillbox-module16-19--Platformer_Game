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
    }

    private void OnEnable()
    {
        DeathTriger.deathPlayer += PlayerIsDeath;
    }

    private void OnDisable()
    {
        DeathTriger.deathPlayer -= PlayerIsDeath;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healsBar.SetHealthValue(currentHealth, maxHealth);
        ChekIsAlive();
    }

    public void CurePlayer(float cure)
    {
        currentHealth += cure;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healsBar.SetHealthValue(currentHealth, maxHealth);
        ChekIsAlive();

    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public bool CheckIsAlive()
    {
        return isAlive;
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

    private void PlayerIsDeath(bool value)
    {
        isAlive = !value;
    }
}
