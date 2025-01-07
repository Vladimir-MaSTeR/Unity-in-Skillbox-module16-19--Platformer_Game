using System;
using GamePush;
using Texts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainCanvasController : MonoBehaviour {
    [Header("---------- ПАНЕЛИ ГЛАВНОГО МЕНЮ  ----------")]
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject autorPanel;

    [Space(5)]
    [Header("--- текстовые поля главного меню ---")]
    [Tooltip("Текстовое поле для названия игры")]
    [SerializeField] private TextMeshProUGUI _mainNameGameText;

    [Tooltip("Текстовое поле для кнопки старта")]
    [SerializeField] private TextMeshProUGUI _startGameBattonText;

    [Space(20)]
    [Header("---------- ПАНЕЛИ МЕНЮ ИСТОРИИ ----------")]
    [SerializeField] private Canvas historyCanvas;
    [SerializeField] private Image currentImageHistory;
    [SerializeField] private Sprite[] imagesHistory;
    [SerializeField] private TextMeshProUGUI textHistory;
    [SerializeField] private TextMeshProUGUI buttonText;

    [Space(20)]
    [Header("---------- ПАНЕЛЬ ИГРЫ ----------")]
    [SerializeField] private GameObject pausePanel;


    private String[] historyText;
    private int indexHistoryText = 0;
    private int imagesIndex = 0;

    //------- EVENTS -----------
    public static Action onClickRestartButton;
    public static Action onClickStartGameButton;
    public static Action onClicLoadLastSave;

    private void Start() {
        mainCanvas?.gameObject.SetActive(true);
        historyCanvas.gameObject.SetActive(false);
        autorPanel.SetActive(false);
        mainPanel.SetActive(true);

        if(null != pausePanel) {
            pausePanel.SetActive(false);
        }

        Language language = GP_Language.Current();
        if(Language.Russian == language) {
            Debug.Log($"Язык игры - Русский");
            _mainNameGameText.text = HistoryTextRu.GAME_NAME_RU;
            _startGameBattonText.text = HistoryTextRu.START_GAME_BATTON_RU;

            historyText = new String[]
            {
            HistoryTextRu.ZERO_RU, HistoryTextRu.ONE_RU, HistoryTextRu.TWO_RU, HistoryTextRu.THREE_RU, HistoryTextRu.FOUR_RU,
            HistoryTextRu.FIVE_RU, HistoryTextRu.SIX_RU, HistoryTextRu.SEVEN_RU, HistoryTextRu.EIGHT_RU, HistoryTextRu.NINE_RU, HistoryTextRu.TEN_RU
            };
        } else if(Language.English == language) {
            Debug.Log($"Язык игры - Английский");
            _mainNameGameText.text = HistoryTextEng.GAME_NAME_ENG;
            _startGameBattonText.text = HistoryTextEng.START_GAME_BATTON_ENG;

            historyText = new String[]
            {
            HistoryTextEng.ZERO_ENG, HistoryTextEng.ONE_ENG, HistoryTextEng.TWO_ENG, HistoryTextEng.THREE_ENG, HistoryTextEng.FOUR_ENG,
            HistoryTextEng.FIVE_ENG, HistoryTextEng.SIX_ENG, HistoryTextEng.SEVEN_ENG, HistoryTextEng.EIGHT_ENG, HistoryTextEng.NINE_ENG, HistoryTextEng.TEN_ENG
            };
        } else if(Language.Turkish == language) {
            Debug.Log($"Язык игры - Турецкий");
        } else if(Language.German == language) {
            Debug.Log($"Язык игры - Немецкий");
        } else if(Language.Spanish == language) {
            Debug.Log($"Язык игры - Испанский");
        }
    }

    //-------Main Canvas Methods-----------
    public void onClickAutorButton() {
        autorPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void onClickExitAutorButton() {
        autorPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void onClickQuitGameButton() {
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("startHistory");

        Application.Quit();
    }

    public void onClickStartGame() {
        // показываем рекламу
        ShowFullscreen();

#if UNITY_EDITOR
        mainCanvas.gameObject.SetActive(false);
        historyCanvas.gameObject.SetActive(true);

        currentImageHistory.sprite = imagesHistory[0];
        textHistory.text = historyText[0];
        indexHistoryText = 0;
        imagesIndex = 0;
#endif
    }

    //-------History Canvas Methods-----------

    public void onClickBackMainMenu() {
        mainCanvas.gameObject.SetActive(true);
        historyCanvas.gameObject.SetActive(false);
        // тут ещё нужно будет сбросить текст  и картинку на начало истории. 
    }

    public void onClickNextHistory() {
        indexHistoryText++;

        if(indexHistoryText != historyText.Length) {
            textHistory.text = historyText[indexHistoryText];
        }

        if(indexHistoryText == 2 || indexHistoryText == 3 || indexHistoryText == 5
           || indexHistoryText == 6 || indexHistoryText == 7 || indexHistoryText == 8) {
            currentImageHistory.sprite = imagesHistory[++imagesIndex];
        }

        if(indexHistoryText == 10) {
            buttonText.text = "начать игру";
        }

        if(indexHistoryText == 11) {
            onClickStartGameButton?.Invoke();
            SceneManager.LoadScene(2);
        }
    }

    //-------Pused Methods-------
    public void OnClickRestartScene() {
        onClickRestartButton?.Invoke();
    }

    public void OnClickExitGameToMainMenu() {
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("startHistory");

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void onClickPauseStart() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void onClickPauseEnd() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void OnClicLoadLastSave() {
        onClicLoadLastSave?.Invoke();
    }

    // Показать fullscreen
    public void ShowFullscreen() => GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);

    // Начался показ
    private void OnFullscreenStart() {
        Debug.Log("ON FULLSCREEN START");
    }
    // Закончился показ
    private void OnFullscreenClose(bool success) {
        Debug.Log("ON FULLSCREEN CLOSE");
#if !UNITY_EDITOR && UNITY_WEBGL
        mainCanvas.gameObject.SetActive(false);
        historyCanvas.gameObject.SetActive(true);

        currentImageHistory.sprite = imagesHistory[0];
        textHistory.text = historyText[0];
        indexHistoryText = 0;
        imagesIndex = 0;
#endif
    }

}
