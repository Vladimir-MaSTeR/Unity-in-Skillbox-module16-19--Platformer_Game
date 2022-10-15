using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MagController : MonoBehaviour
{
    [Header("Панели")]
    [SerializeField] private GameObject magPanel;
    [SerializeField] private GameObject smithy; // панель кузницы
    [SerializeField] private GameObject textMagHistoryPanel; // панель с текстом истории в магазине

    [Header("Кнопки")]
    [SerializeField] private Button smithyButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button sneilLevelStartButton;

    [Header("Картинки стрелок для понимания кто говорит")]
    [SerializeField] private GameObject arrowPlayerImage;
    [SerializeField] private GameObject arrowOrsicImage;


    [Header("Текст истории")]
    [SerializeField] private Text textHistory;

    [Header("Звук")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dorClip;


    private String[] noSneilLevelHistoryText = new String[] {
        HistoryText.ORSIC_MEET_SNEIL_1, HistoryText.PLAYER_MEET_SNEIL_1, 
        HistoryText.ORSIC_MEET_SNEIL_2, HistoryText.PLAYER_MEET_SNEIL_2, 
        HistoryText.ORSIC_MEET_SNEIL_3, HistoryText.PLAYER_MEET_SNEIL_3,
        HistoryText.ORSIC_MEET_SNEIL_4, HistoryText.PLAYER_MEET_SNEIL_4,
        HistoryText.ORSIC_MEET_SNEIL_5, HistoryText.PLAYER_MEET_SNEIL_5,
        HistoryText.ORSIC_MEET_SNEIL_6, HistoryText.PLAYER_MEET_SNEIL_6,
        HistoryText.ORSIC_MEET_SNEIL_7, HistoryText.PLAYER_MEET_SNEIL_7,
        HistoryText.ORSIC_MEET_SNEIL_8}; // 14 елементов

    private String[] YesSneilLevelHistoryText = new String[] {
        HistoryText.PLAYER_MEET_SNEIL_END_1, HistoryText.ORSIC_MEET_SNEIL_END_1,
        HistoryText.PLAYER_MEET_SNEIL_END_2, HistoryText.ORSIC_MEET_SNEIL_END_2,
        HistoryText.PLAYER_MEET_SNEIL_END_3, HistoryText.ORSIC_MEET_SNEIL_END_3,
        HistoryText.PLAYER_MEET_SNEIL_END_4, HistoryText.ORSIC_MEET_SNEIL_END_4,
        HistoryText.PLAYER_MEET_SNEIL_END_5, HistoryText.ORSIC_MEET_SNEIL_END_5,
        HistoryText.PLAYER_MEET_SNEIL_END_6, HistoryText.ORSIC_MEET_SNEIL_END_6,
        HistoryText.PLAYER_MEET_SNEIL_END_7, HistoryText.ORSIC_MEET_SNEIL_END_7,
        HistoryText.PLAYER_MEET_SNEIL_END_8, HistoryText.ORSIC_MEET_SNEIL_END_8,
        HistoryText.PLAYER_MEET_SNEIL_END_9, HistoryText.ORSIC_MEET_SNEIL_END_9,
        HistoryText.PLAYER_MEET_SNEIL_END_10, HistoryText.ORSIC_MEET_SNEIL_END_10,
        HistoryText.PLAYER_MEET_SNEIL_END_11, HistoryText.ORSIC_MEET_SNEIL_END_11,
        HistoryText.PLAYER_MEET_SNEIL_END_12, HistoryText.ORSIC_MEET_SNEIL_END_12,
        HistoryText.PLAYER_MEET_SNEIL_END_13, HistoryText.ORSIC_MEET_SNEIL_END_13,
        HistoryText.PLAYER_MEET_SNEIL_END_14, HistoryText.ORSIC_MEET_SNEIL_END_14,
        HistoryText.PLAYER_MEET_SNEIL_END_15, HistoryText.ORSIC_MEET_SNEIL_END_15,
        HistoryText.PLAYER_MEET_SNEIL_END_16, HistoryText.ORSIC_MEET_SNEIL_END_16,
        HistoryText.PLAYER_MEET_SNEIL_END_17, HistoryText.ORSIC_MEET_SNEIL_END_17,
        HistoryText.PLAYER_MEET_SNEIL_END_18, HistoryText.ORSIC_MEET_SNEIL_END_18,
        HistoryText.PLAYER_MEET_SNEIL_END_19 };

    //private String[] playerSneilHistoryText = new String[] { };

    private int startHistory = 0; // переменна отвечает за текст истории. | 0 = начало игры | 1 = Пройден уровень с улитками ||||
    private int indexHistoryText = 0;
    //private int indexPlayerSneilHistoryText = 0;

    //События
    public static Action onEventClickSwordImageButton;
    public static Action onEventSpearDamageImageButton;
    public static Action onEventSpearImageButton;
    public static Action onEventClickSneilLevelButton;



    private void Start()
    {
        magPanel.SetActive(false);
        smithy.SetActive(false);

        arrowPlayerImage.SetActive(false);
        arrowOrsicImage.SetActive(false);

      //  CheckStartHistory();
    }

    private void Update()
    {
        historyText();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && magPanel.active == false)
            {
                audioSource.PlayOneShot(dorClip);
                magPanel.SetActive(true);

                CheckStartHistory();
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

                CheckStartHistory();
            }


        }
    }

    private void CheckStartHistory()
    {
        if (PlayerPrefs.HasKey("startHistory"))
        {
            startHistory = PlayerPrefs.GetInt("startHistory");

        } else
        {
            startHistory = 0;
        }

        Debug.Log($"переменная startHistory = {startHistory}");
    }

    private void historyText ()
    {
        if (startHistory == 0 && magPanel.activeSelf == true)
        {
            //smithyButton.interactable = false;
            //sneilLevelStartButton.interactable = false;

            smithyButton.gameObject.SetActive(false);
            sneilLevelStartButton.gameObject.SetActive(false);

            nextTextButton.gameObject.SetActive(true);
            nextTextButton.interactable = true;

            textHistory.text = noSneilLevelHistoryText[indexHistoryText];

            if (indexHistoryText % 2 != 0)
            {
                arrowPlayerImage.SetActive(true);
                arrowOrsicImage.SetActive(false);
            } else
            {
                arrowPlayerImage.SetActive(false);
                arrowOrsicImage.SetActive(true);
            }

            if (indexHistoryText == 14)
            {
                nextTextButton.gameObject.SetActive(false);
                sneilLevelStartButton.gameObject.SetActive(true);
                sneilLevelStartButton.interactable = true;
            }



        } else if (startHistory == 1 && magPanel.activeSelf == true)
        {
           

            smithyButton.gameObject.SetActive(false);
            sneilLevelStartButton.gameObject.SetActive(false);

            nextTextButton.gameObject.SetActive(true);
            nextTextButton.interactable = true;

            textHistory.text = YesSneilLevelHistoryText[indexHistoryText];

            if (indexHistoryText % 2 == 0)
            {
                arrowPlayerImage.SetActive(true);
                arrowOrsicImage.SetActive(false);
            }
            else
            {
                arrowPlayerImage.SetActive(false);
                arrowOrsicImage.SetActive(true);
            }

            if (indexHistoryText == 36)
            {
                smithyButton.gameObject.SetActive(true);

                nextTextButton.gameObject.SetActive(false);

                sneilLevelStartButton.gameObject.SetActive(true);
            }

        } else
        {
            smithyButton.gameObject.SetActive(true);

            sneilLevelStartButton.gameObject.SetActive(true);

            nextTextButton.gameObject.SetActive(false);

        }
    }

    public void onClickNextHistoryButton()
    {
        indexHistoryText++;
    }


    public void onCleckExitMagButton()
    {
        magPanel.SetActive(false);
        smithy.SetActive(false);
        smithyButton.interactable = true;
        audioSource.PlayOneShot(dorClip);

        if (startHistory == 0)
        {
            indexHistoryText = 0;
        }
    }

    public void onClickSmithybutton()
    {
        smithy.SetActive(true);
        textMagHistoryPanel.SetActive(false);

        smithyButton.interactable = false;
        exitButton.interactable = false;
        sneilLevelStartButton.interactable = false;
    }

    public void onClickExitSmithybutton()
    {
        smithy.SetActive(false);
        textMagHistoryPanel.SetActive(true);

        smithyButton.interactable = true;
        exitButton.interactable = true;
        sneilLevelStartButton.interactable = true;
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

    public void onClickSneilLevelButton()
    {
        onEventClickSneilLevelButton?.Invoke();
        magPanel.SetActive(false);
    }


}
