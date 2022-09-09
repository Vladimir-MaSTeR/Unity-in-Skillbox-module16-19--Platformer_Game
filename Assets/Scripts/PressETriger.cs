using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressETriger : MonoBehaviour
{
    [SerializeField] private Canvas pressECanvas;

    private void Start()
    {
        pressECanvas.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressECanvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressECanvas.gameObject.SetActive(false);
        }
    }
}
