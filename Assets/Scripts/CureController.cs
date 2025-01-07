using UnityEngine;
public class CureController : MonoBehaviour {
    [SerializeField] private float cure = 30;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            float currentHealth = collision.gameObject.GetComponent<Health>().GetCurrentHealth();
            float MaxHealth = collision.gameObject.GetComponent<Health>().GetMaxHealth();

            if(currentHealth < MaxHealth) {
                collision.gameObject.GetComponent<Health>().CurePlayer(cure);
                audioSource.PlayOneShot(clip);
                Debug.Log("Играку подобрал лекарство");

                Destroy(gameObject);
            }
        }

    }
}
