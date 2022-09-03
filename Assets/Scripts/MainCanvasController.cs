using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour
{
    [Header("Панели главного меню")]
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject autorPanel;

    [Header("Панели меню истории")]
    [SerializeField] private Canvas historyCanvas;
    [SerializeField] private Image currentImageHistory;
    [SerializeField] private Sprite[] imagesHistory;
    [SerializeField] private Text textHistory;
    [SerializeField] private Text buttonText;


    private String[] historyText = new String[] { HistoryText.ZERO, HistoryText.ONE, HistoryText.TWO, HistoryText.THREE, HistoryText.FOUR,
                                                  HistoryText.FIVE, HistoryText.SIX, HistoryText.SEVEN, HistoryText.EIGHT, HistoryText.NINE, HistoryText.TEN};
    private int indexHistoryText = 0;
    private int imagesIndex = 0;

    private void Start()
    {
        mainCanvas.gameObject.SetActive(true);
        historyCanvas.gameObject.SetActive(false);
        autorPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    //-------Main Canvas Methods-----------
    public void onClickAutorButton()
    {
        autorPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void onClickExitAutorButton()
    {
        autorPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void onClickQuitGameButton()
    {
        Application.Quit();
    }

    public void onClickStartGame()
    {
        mainCanvas.gameObject.SetActive(false);
        historyCanvas.gameObject.SetActive(true);

        currentImageHistory.sprite = imagesHistory[0];
        textHistory.text = historyText[0];
        indexHistoryText = 0;
        imagesIndex = 0;
    }

    //-------History Canvas Methods-----------

    public void onClickBackMainMenu()
    {
        mainCanvas.gameObject.SetActive(true);
        historyCanvas.gameObject.SetActive(false);
        // тут ещё нужно будет сбросить текст  и картинку на начало истории. 
    }

    public void onClickNextHistory()
    {
        indexHistoryText++;

        if (indexHistoryText != historyText.Length)
        {
            textHistory.text = historyText[indexHistoryText];
        }
       
        if (indexHistoryText == 2 || indexHistoryText == 3 || indexHistoryText == 5
            || indexHistoryText == 6 || indexHistoryText == 7 || indexHistoryText == 8)
        {
            currentImageHistory.sprite = imagesHistory[++imagesIndex];
        }

        if (indexHistoryText == 10)
        {
            buttonText.text = "начать игру";
        }

        if (indexHistoryText == 11)
        {
            SceneManager.LoadScene(1);
        }
    }

    //-------------------------------------
    public void OnClickRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
