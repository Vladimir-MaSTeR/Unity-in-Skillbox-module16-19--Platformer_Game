using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SavePointController : MonoBehaviour
{
    [SerializeField] private GameObject[] needToShowObject;
    [SerializeField] private GameObject[] needToFalseShowObject;


    public static Action onTapSavePoint;


    private void Start()
    {
        foreach (var item in needToShowObject)
        {
            item.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            onTapSavePoint?.Invoke();
            foreach (var item in needToShowObject)
            {
                item.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            onTapSavePoint?.Invoke();
            foreach (var item in needToShowObject)
            {
                item.SetActive(true);
            }
        }
    }

    
}
