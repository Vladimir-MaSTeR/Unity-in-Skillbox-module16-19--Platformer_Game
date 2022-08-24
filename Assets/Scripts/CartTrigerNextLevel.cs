using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartTrigerNextLevel : MonoBehaviour
{

    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float cameraPositionX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Телега вошли в зону тригера");

        if (collision.CompareTag("Cart"))
        {
            Debug.Log("Тиргер сработал на телеге");

            cameraPosition.position = new Vector3(cameraPositionX, cameraPosition.position.y, cameraPosition.position.z);
        }
    }
}
