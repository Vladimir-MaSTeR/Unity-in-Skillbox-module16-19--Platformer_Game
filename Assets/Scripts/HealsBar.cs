using UnityEngine;
using UnityEngine.UI;
public class HealsBar : MonoBehaviour {
    [SerializeField] private Canvas canvasHealthBar;
    [SerializeField] private Image healthBarImage;


    private void Start() {
        canvasHealthBar.gameObject.SetActive(false);
        healthBarImage.fillAmount = 1;
    }

    public void SetHealthValue(float currentHealth, float maxHealth) {
        canvasHealthBar.gameObject.SetActive(currentHealth < maxHealth);
        healthBarImage.fillAmount = currentHealth / 100;

        if(healthBarImage.fillAmount <= 0) {
            canvasHealthBar.gameObject.SetActive(false);
        }

    }

}
