using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishStage : MonoBehaviour
{
   
    public static Action onfinishStage;
    public static Action onfinishStageSneil;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                onfinishStageSneil?.Invoke();

                if (PlayerPrefs.HasKey("startHistory"))
                {
                    PlayerPrefs.SetInt("startHistory", 2);
                }
                else
                {
                    PlayerPrefs.SetInt("startHistory", 1);
                }
            }

            onfinishStage?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                onfinishStageSneil?.Invoke();

                if (PlayerPrefs.HasKey("startHistory"))
                {
                    PlayerPrefs.SetInt("startHistory", 2);
                }
                else
                {
                    PlayerPrefs.SetInt("startHistory", 1);
                }
            }

            onfinishStage?.Invoke();
        }
    }


}
