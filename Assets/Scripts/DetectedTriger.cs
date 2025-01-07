using UnityEngine;
public class DetectedTriger : MonoBehaviour {

    private bool playerDetected = false;

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.CompareTag("Damagebl")) {
            playerDetected = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Damagebl")) {
            playerDetected = false;
        }
    }

    public bool getPlayerDetected() {
        return this.playerDetected;
    }


}
