using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdDamageDeallerOnPlayer : MonoBehaviour
{
    [SerializeField] private float damage = 30;
    [SerializeField] private GameManager gameManagerScript;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private float currentDamage;

    private void Start()
    {
        currentDamage = damage;
        gameManagerScript.SetCurrentDamageSwordText((int)currentDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentDamage = gameManagerScript.GetCurrentDamageSwordText();

            audioSource.PlayOneShot(clip);
            collision.gameObject.GetComponent<Health>().TakeDamage(currentDamage);
            Debug.Log($"Монстру нанесён урон холодным на {currentDamage} урона");
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
