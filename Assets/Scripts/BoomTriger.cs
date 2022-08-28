using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomTriger : MonoBehaviour
{
    [SerializeField] private PointEffector2D boobEffector;

    private void Start()
    {
        boobEffector.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Damagebl"))
        {
            boobEffector.gameObject.SetActive(true);
        }
        
    }
}
