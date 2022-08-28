using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedTriger : MonoBehaviour
{

    private bool playerDetected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Damagebl"))
        {
            playerDetected = true;
        }

    }

    public bool getPlayerDetected()
    {
        return this.playerDetected;
    }


}
