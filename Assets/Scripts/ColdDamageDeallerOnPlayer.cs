using System;
using UnityEngine;
public class ColdDamageDeallerOnPlayer : MonoBehaviour {
    //[SerializeField] private float damage = 30;
    [SerializeField] private GameManager gameManagerScript;

    [SerializeField] private float delimetrDamageBoss = 30;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private float currentDamage;

    //------EVENTS---------
    public static Func<int> onSwordDamage;

    private void Start() {
        currentDamage = (float)(onSwordDamage?.Invoke());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")) {
            currentDamage = (float)(onSwordDamage?.Invoke());

            audioSource.PlayOneShot(clip);
            collision.gameObject.GetComponent<Health>().TakeDamage(currentDamage);
            Debug.Log($"Монстру нанесён урон холодным на {currentDamage} урона");
        }

        if(collision.CompareTag("Boss")) {
            currentDamage = (float)(onSwordDamage?.Invoke());
            float currentDamageBoss = currentDamage / delimetrDamageBoss;

            audioSource.PlayOneShot(clip);
            collision.gameObject.GetComponent<Health>().TakeDamage(currentDamageBoss);
            Debug.Log($"Босу нанесён урон холодным на {currentDamageBoss} урона");
        }
    }


    public float GetCurrentDamage() {
        return this.currentDamage;
    }

    public void SetCurrentDamage(float damage) {
        this.currentDamage = damage;
    }
}
