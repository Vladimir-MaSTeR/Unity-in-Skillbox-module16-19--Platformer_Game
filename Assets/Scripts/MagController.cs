using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MagController : MonoBehaviour
{
    [SerializeField] private GameObject magPanel;
    [SerializeField] private GameObject smithy; // панель кузницы


    [SerializeField] private Button smithyButton;
    [SerializeField] private Button sneilLevelStartButton;

    [Header("кнопки покупки")]
    //[SerializeField] private Button SwordImageButton;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dorClip;


    //События
    public static Action onEventClickSwordImageButton;
    public static Action onEventSpearDamageImageButton;
    public static Action onEventSpearImageButton;


    private void Start()
    {
        magPanel.SetActive(false);
        smithy.SetActive(false);
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && magPanel.active == false)
            {
                audioSource.PlayOneShot(dorClip);
                magPanel.SetActive(true);
            }
           
            
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSource.PlayOneShot(dorClip);
                magPanel.SetActive(true);
            }


        }
    }



    public void onCleckExitMagButton()
    {
        magPanel.SetActive(false);
        smithy.SetActive(false);
        smithyButton.interactable = true;
        audioSource.PlayOneShot(dorClip);
    }

    public void onClickSmithybutton()
    {
        smithy.SetActive(true);
        smithyButton.interactable = false;
    }

    public void onClickExitSmithybutton()
    {
        smithy.SetActive(false);
        smithyButton.interactable = true;
    }

    public void onClickSwordImageButton()
    {
        onEventClickSwordImageButton?.Invoke();
    }

    public void onClickSpearDamageImageButton()
    {
        onEventSpearDamageImageButton?.Invoke();
    }

    public void onClickSpearImageButton()
    {
        onEventSpearImageButton?.Invoke();
    }


}
