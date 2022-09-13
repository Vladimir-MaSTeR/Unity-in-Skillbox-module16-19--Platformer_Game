using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private int damage = 35;
    //[SerializeField] private GameManager gameManagerScript;

    private int currentDamage;

    //������ � ���������
    public static Func<int> onSpearDamage;
    public static Action onCollisionWithEnemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentDamage = (int)(onSpearDamage?.Invoke());
            onCollisionWithEnemy?.Invoke();

            collision.gameObject.GetComponent<Health>().TakeDamage(currentDamage);
            Debug.Log( $"������� ������ ���� ����������� ������� �� {currentDamage} �����");
             Destroy(gameObject);

        }
    }


    public int GetStartDamage()
    {
        return this.damage;
    }
}
