using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public static Action<int> onCoin;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onCoin?.Invoke(1);
            var parent = transform.parent.gameObject;
            Destroy(parent);
        }
    }
}
