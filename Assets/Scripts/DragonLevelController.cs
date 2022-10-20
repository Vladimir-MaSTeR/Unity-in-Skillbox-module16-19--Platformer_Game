using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonLevelController : MonoBehaviour
{
    [Header("Звук")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dorClip;

    [Header("Необходимый урон для входа к боссу")]
    [SerializeField] private int requiredDamage = 80;


    private string str1 = "Пока рано. Нужно зайти к Орсику";
    private string str2 = "Надо подкачаться. Думаю урона больше 80 хватит...";
    //private string str1 = "";


    private int endSneilLevel = 0;
    private string currentDialogText = "";

    private int currentDamageSword = 0;
    private int currentDamageSpear = 0;


    //---EVENT---
    public static Action<String> onEventDragonLEvel;
    public static Action onEventStartDragonLevel;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LaodDamageAndHistorySave();
                Debug.Log($"endSneilLevel = {endSneilLevel}");



                if (endSneilLevel == 0)
                {
                    onEventDragonLEvel?.Invoke(str1);

                }
                else
                {
                    onEventDragonLEvel?.Invoke(str2);
                }


                if (endSneilLevel > 0 && currentDamageSword >= requiredDamage || endSneilLevel > 0 && currentDamageSpear >= requiredDamage)
                {
                    audioSource.PlayOneShot(dorClip);
                    onEventStartDragonLevel?.Invoke();
                   // SceneManager.LoadScene(3);
                }
                //  audioSource.PlayOneShot(dorClip);

            }


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {

                LaodDamageAndHistorySave();
                Debug.Log($"endSneilLevel = {endSneilLevel}");


                if (endSneilLevel == 0)
                {
                    onEventDragonLEvel?.Invoke(str1);

                } else
                {
                    onEventDragonLEvel?.Invoke(str2);
                }


                if (endSneilLevel > 0 && currentDamageSword >= requiredDamage || endSneilLevel > 0 && currentDamageSpear >= requiredDamage)
                {
                    audioSource.PlayOneShot(dorClip);
                    onEventStartDragonLevel?.Invoke();
                    //SceneManager.LoadScene(3);
                }
                
                //  audioSource.PlayOneShot(dorClip);
            }


        }
    }


    private void LaodDamageAndHistorySave()
    {
        if (PlayerPrefs.HasKey("DamageSword"))
        {
            currentDamageSword = PlayerPrefs.GetInt("DamageSword");
            Debug.Log($"загрузил DamageSword = {currentDamageSword}");
        }

        if (PlayerPrefs.HasKey("DamageSpear"))
        {
            currentDamageSpear = PlayerPrefs.GetInt("DamageSpear");
            Debug.Log($"загрузил DamageSpear = {currentDamageSpear}");
        }

        if (PlayerPrefs.HasKey("startHistory"))
        {
            endSneilLevel = PlayerPrefs.GetInt("startHistory");
            Debug.Log($"загрузил startHistory = {endSneilLevel}");
        }
        else
        {
            endSneilLevel = 0;
        }
    } 


   
}
