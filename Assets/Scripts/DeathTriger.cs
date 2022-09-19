using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;



public class DeathTriger : MonoBehaviour
{
    public static Action<bool> deathPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deathPlayer?.Invoke(true);
        }
    }
}
