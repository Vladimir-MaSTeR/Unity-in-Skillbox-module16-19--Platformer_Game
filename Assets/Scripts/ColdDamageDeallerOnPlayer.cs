using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdDamageDeallerOnPlayer : MonoBehaviour
{
    //[SerializeField] private float damage = 30;
    [SerializeField] private GameManager gameManagerScript;

    [SerializeField] private float delimetrDamageBoss = 30;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private float currentDamage;

    //------EVENTS---------
    public static Func<int> onSwordDamage;

    private void Start()
    {
        currentDamage = (float)(onSwordDamage?.Invoke());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentDamage = (float)(onSwordDamage?.Invoke());

            audioSource.PlayOneShot(clip);
            collision.gameObject.GetComponent<Health>().TakeDamage(currentDamage);
            Debug.Log($"������� ������ ���� �������� �� {currentDamage} �����");
        }

        if (collision.CompareTag("Boss"))
        {
            currentDamage = (float)(onSwordDamage?.Invoke());
            float currentDamageBoss = currentDamage / delimetrDamageBoss;

            audioSource.PlayOneShot(clip);
            collision.gameObject.GetComponent<Health>().TakeDamage(currentDamageBoss);
            Debug.Log($"���� ������ ���� �������� �� {currentDamageBoss} �����");
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
