using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStage : MonoBehaviour
{
   
    public static Action onfinishStage;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            onfinishStage?.Invoke();
        }
    }


}
