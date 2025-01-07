using System;
using UnityEngine;
public class DeathTriger : MonoBehaviour {
    public static Action<bool> deathPlayer;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            deathPlayer?.Invoke(true);
        }
    }
}
