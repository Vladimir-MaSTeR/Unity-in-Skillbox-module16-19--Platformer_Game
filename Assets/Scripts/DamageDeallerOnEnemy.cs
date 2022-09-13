using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDeallerOnEnemy : MonoBehaviour
{
    [SerializeField] private float damage = 10;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            audioSource.PlayOneShot(clip);
            Debug.Log("Играку нанесён урон");

        }

    }
}
