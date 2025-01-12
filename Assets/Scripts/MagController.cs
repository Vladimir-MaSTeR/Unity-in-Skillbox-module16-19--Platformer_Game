using System;
using GamePush;
using Texts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MagController : MonoBehaviour {
    [Header("--------- ПАНЕЛИ ---------")]
    [SerializeField] private GameObject magPanel;
    [SerializeField] private GameObject smithy;              // панель кузницы
    [SerializeField] private GameObject textMagHistoryPanel; // панель с текстом истории в магазине

    [Header("--------- КНОПКИ ---------")]
    [SerializeField] private Button smithyButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button sneilLevelStartButton;

    [Header("--------- КАРТИНКИ СТРЕЛОК ДЛЯ ПОНИМАНИЯ КТО ГОВОРИТ ---------")]
    [SerializeField] private GameObject arrowPlayerImage;
    [SerializeField] private GameObject arrowOrsicImage;


    [Header("--------- ТЕКСТ ИСТОРИИ ---------")]
    // [SerializeField] private Text textHistory;
    [SerializeField] private TextMeshProUGUI textHistory;
    [SerializeField] private TextMeshProUGUI _nextDialogButtonTextMagPanel;
    [SerializeField] private TextMeshProUGUI _exitMagButtonTextMagPanel;
    [SerializeField] private TextMeshProUGUI _smithyButtonTextMagPanel;
    [SerializeField] private TextMeshProUGUI _sneilLevelStartButtonTextMagPanel;

    [Space(10)]
    [Header("Текстовые поля, торговли")]
    [SerializeField] private TextMeshProUGUI _spearImageButtonSmithyText_1_MagPanel;
    [SerializeField] private TextMeshProUGUI _spearImageButtonSmithyText_2_MagPanel;
    [SerializeField] private TextMeshProUGUI _spearImageButtonSmithyText_3_MagPanel;

    [Space(5)]
    [SerializeField] private TextMeshProUGUI _spearDamageImageButtonSmithyText_1_MagPanel;
    [SerializeField] private TextMeshProUGUI _spearDamageImageButtonSmithyText_2_MagPanel;
    [SerializeField] private TextMeshProUGUI _spearDamageImageButtonSmithyText_3_MagPanel;

    [Space(5)]
    [SerializeField] private TextMeshProUGUI _swordImageButtonSmithyText_1_MagPanel;
    [SerializeField] private TextMeshProUGUI _swordImageButtonSmithyText_2_MagPanel;
    [SerializeField] private TextMeshProUGUI _swordImageButtonSmithyText_3_MagPanel;

    [Space(5)]
    [SerializeField] private TextMeshProUGUI _exitSmithyButtonSmithyTextMagPanel;

    [Header("--------- ЗВУК ---------")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dorClip;


    private String[] noSneilLevelHistoryTextRu = new String[]
    {
    HistoryTextRu.ORSIC_MEET_SNEIL_1_RU, HistoryTextRu.PLAYER_MEET_SNEIL_1_RU,
    HistoryTextRu.ORSIC_MEET_SNEIL_2_RU, HistoryTextRu.PLAYER_MEET_SNEIL_2_RU,
    HistoryTextRu.ORSIC_MEET_SNEIL_3_RU, HistoryTextRu.PLAYER_MEET_SNEIL_3_RU,
    HistoryTextRu.ORSIC_MEET_SNEIL_4_RU, HistoryTextRu.PLAYER_MEET_SNEIL_4_RU,
    HistoryTextRu.ORSIC_MEET_SNEIL_5_RU, HistoryTextRu.PLAYER_MEET_SNEIL_5_RU,
    HistoryTextRu.ORSIC_MEET_SNEIL_6_RU, HistoryTextRu.PLAYER_MEET_SNEIL_6_RU,
    HistoryTextRu.ORSIC_MEET_SNEIL_7_RU, HistoryTextRu.PLAYER_MEET_SNEIL_7_RU,
    HistoryTextRu.ORSIC_MEET_SNEIL_8_RU
    }; // 14 елементов

    private String[] noSneilLevelHistoryTextEng = new String[]
    {
    HistoryTextEng.ORSIC_MEET_SNEIL_1_ENG, HistoryTextEng.PLAYER_MEET_SNEIL_1_ENG,
    HistoryTextEng.ORSIC_MEET_SNEIL_2_ENG, HistoryTextEng.PLAYER_MEET_SNEIL_2_ENG,
    HistoryTextEng.ORSIC_MEET_SNEIL_3_ENG, HistoryTextEng.PLAYER_MEET_SNEIL_3_ENG,
    HistoryTextEng.ORSIC_MEET_SNEIL_4_ENG, HistoryTextEng.PLAYER_MEET_SNEIL_4_ENG,
    HistoryTextEng.ORSIC_MEET_SNEIL_5_ENG, HistoryTextEng.PLAYER_MEET_SNEIL_5_ENG,
    HistoryTextEng.ORSIC_MEET_SNEIL_6_ENG, HistoryTextEng.PLAYER_MEET_SNEIL_6_ENG,
    HistoryTextEng.ORSIC_MEET_SNEIL_7_ENG, HistoryTextEng.PLAYER_MEET_SNEIL_7_ENG,
    HistoryTextEng.ORSIC_MEET_SNEIL_8_ENG
    };

    private String[] YesSneilLevelHistoryTextRu = new String[]
    {
    HistoryTextRu.PLAYER_MEET_SNEIL_END_1_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_1_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_2_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_2_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_3_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_3_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_4_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_4_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_5_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_5_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_6_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_6_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_7_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_7_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_8_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_8_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_9_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_9_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_10_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_10_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_11_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_11_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_12_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_12_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_13_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_13_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_14_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_14_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_15_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_15_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_16_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_16_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_17_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_17_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_18_RU, HistoryTextRu.ORSIC_MEET_SNEIL_END_18_RU,
    HistoryTextRu.PLAYER_MEET_SNEIL_END_19_RU
    };

    private String[] YesSneilLevelHistoryTextEng = new String[]
    {
    HistoryTextEng.PLAYER_MEET_SNEIL_END_1_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_1_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_2_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_2_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_3_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_3_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_4_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_4_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_5_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_5_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_6_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_6_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_7_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_7_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_8_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_8_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_9_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_9_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_10_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_10_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_11_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_11_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_12_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_12_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_13_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_13_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_14_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_14_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_15_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_15_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_16_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_16_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_17_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_17_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_18_ENG, HistoryTextEng.ORSIC_MEET_SNEIL_END_18_ENG,
    HistoryTextEng.PLAYER_MEET_SNEIL_END_19_ENG
    };

    //private String[] playerSneilHistoryText = new String[] { };

    private int startHistory = 0; // переменна отвечает за текст истории. | 0 = начало игры | 1 = Пройден уровень с улитками ||||
    private int indexHistoryText = 0;
    private Language language;

    //События
    public static Action onEventClickSwordImageButton;
    public static Action onEventSpearDamageImageButton;
    public static Action onEventSpearImageButton;
    public static Action onEventClickSneilLevelButton;
    public static Action onEventClickExitMagButton;


    private void Start() {
        magPanel.SetActive(false);
        smithy.SetActive(false);

        arrowPlayerImage.SetActive(false);
        arrowOrsicImage.SetActive(false);

        //  CheckStartHistory();
    }

    private void Update() {
        historyText();
    }


    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            if(Input.GetKey(KeyCode.E) && magPanel.active == false) {
                audioSource.PlayOneShot(dorClip);
                magPanel.SetActive(true);

                CheckLanguage();
                CheckStartHistory();
            }


        }
    }

    private void CheckLanguage() {
        language = GP_Language.Current();
        if(Language.Russian == language) {
            // buttonText.text = "начать игру";
            Debug.Log($"Язык игры - Русский");
            _nextDialogButtonTextMagPanel.text = HistoryTextRu.NEXT_DIALOG_BUTTON_TEXT_MAG_PANEL_RU;
            _exitMagButtonTextMagPanel.text = HistoryTextRu.EXIT_MAG_BUTTON_TEXT_MAG_PANEL_RU;
            _smithyButtonTextMagPanel.text = HistoryTextRu.SMITHY_BUTTON_TEXT_MAG_PANEL_RU;
            _sneilLevelStartButtonTextMagPanel.text = HistoryTextRu.SNEIL_LEVEL_START_BUTTON_TEXT_MAG_PANEL_RU;

            _spearImageButtonSmithyText_1_MagPanel.text = HistoryTextRu.SPEAR_IMAGE_BUTTON_SMITHY_TEXT_1_MAG_PANEL_RU;
            _spearImageButtonSmithyText_2_MagPanel.text = HistoryTextRu.SPEAR_IMAGE_BUTTON_SMITHY_TEXT_2_MAG_PANEL_RU;
            _spearImageButtonSmithyText_3_MagPanel.text = HistoryTextRu.SPEAR_IMAGE_BUTTON_SMITHY_TEXT_3_MAG_PANEL_RU;

            _spearDamageImageButtonSmithyText_1_MagPanel.text = HistoryTextRu.SPEAR_DAMAGE_IMAGE_BUTTON_SMITHY_TEXT_1_MAG_PANEL_RU;
            _spearDamageImageButtonSmithyText_2_MagPanel.text = HistoryTextRu.SPEAR_DAMAGE_IMAGE_BUTTON_SMITHY_TEXT_2_MAG_PANEL_RU;
            _spearDamageImageButtonSmithyText_3_MagPanel.text = HistoryTextRu.SPEAR_DAMAGE_IMAGE_BUTTON_SMITHY_TEXT_3_MAG_PANEL_RU;

            _swordImageButtonSmithyText_1_MagPanel.text = HistoryTextRu.SWORD_IMAGE_BUTTON_SMITHY_TEXT_1_MAG_PANEL_RU;
            _swordImageButtonSmithyText_2_MagPanel.text = HistoryTextRu.SWORD_IMAGE_BUTTON_SMITHY_TEXT_2_MAG_PANEL_RU;
            _swordImageButtonSmithyText_3_MagPanel.text = HistoryTextRu.SWORD_IMAGE_BUTTON_SMITHY_TEXT_3_MAG_PANEL_RU;

            _exitSmithyButtonSmithyTextMagPanel.text = HistoryTextRu.EXIT_SMITHY_BUTTON_SMITHY_TEXT_MAG_PANEL_RU;
        } else if(Language.English == language) {
            Debug.Log($"Язык игры - Английский");
            _nextDialogButtonTextMagPanel.text = HistoryTextEng.NEXT_DIALOG_BUTTON_TEXT_MAG_PANEL_ENG;
            _exitMagButtonTextMagPanel.text = HistoryTextEng.EXIT_MAG_BUTTON_TEXT_MAG_PANEL_ENG;
            _smithyButtonTextMagPanel.text = HistoryTextEng.SMITHY_BUTTON_TEXT_MAG_PANEL_ENG;
            _sneilLevelStartButtonTextMagPanel.text = HistoryTextEng.SNEIL_LEVEL_START_BUTTON_TEXT_MAG_PANEL_ENG;
            
            _spearImageButtonSmithyText_1_MagPanel.text = HistoryTextEng.SPEAR_IMAGE_BUTTON_SMITHY_TEXT_1_MAG_PANEL_ENG;
            _spearImageButtonSmithyText_2_MagPanel.text = HistoryTextEng.SPEAR_IMAGE_BUTTON_SMITHY_TEXT_2_MAG_PANEL_ENG;
            _spearImageButtonSmithyText_3_MagPanel.text = HistoryTextEng.SPEAR_IMAGE_BUTTON_SMITHY_TEXT_3_MAG_PANEL_ENG;

            _spearDamageImageButtonSmithyText_1_MagPanel.text = HistoryTextEng.SPEAR_DAMAGE_IMAGE_BUTTON_SMITHY_TEXT_1_MAG_PANEL_ENG;
            _spearDamageImageButtonSmithyText_2_MagPanel.text = HistoryTextEng.SPEAR_DAMAGE_IMAGE_BUTTON_SMITHY_TEXT_2_MAG_PANEL_ENG;
            _spearDamageImageButtonSmithyText_3_MagPanel.text = HistoryTextEng.SPEAR_DAMAGE_IMAGE_BUTTON_SMITHY_TEXT_3_MAG_PANEL_ENG;

            _swordImageButtonSmithyText_1_MagPanel.text = HistoryTextEng.SWORD_IMAGE_BUTTON_SMITHY_TEXT_1_MAG_PANEL_ENG;
            _swordImageButtonSmithyText_2_MagPanel.text = HistoryTextEng.SWORD_IMAGE_BUTTON_SMITHY_TEXT_2_MAG_PANEL_ENG;
            _swordImageButtonSmithyText_3_MagPanel.text = HistoryTextEng.SWORD_IMAGE_BUTTON_SMITHY_TEXT_3_MAG_PANEL_ENG;

            _exitSmithyButtonSmithyTextMagPanel.text = HistoryTextEng.EXIT_SMITHY_BUTTON_SMITHY_TEXT_MAG_PANEL_ENG;
        } else if(Language.Turkish == language) {
            Debug.Log($"Язык игры - Турецкий");
        } else if(Language.German == language) {
            Debug.Log($"Язык игры - Немецкий");
        } else if(Language.Spanish == language) {
            Debug.Log($"Язык игры - Испанский");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            if(Input.GetKeyDown(KeyCode.E)) {
                audioSource.PlayOneShot(dorClip);
                magPanel.SetActive(true);

                CheckLanguage();
                CheckStartHistory();
            }


        }
    }

    private void CheckStartHistory() {
        if(PlayerPrefs.HasKey("startHistory")) {
            startHistory = PlayerPrefs.GetInt("startHistory");

        } else {
            startHistory = 0;
        }

        Debug.Log($"переменная startHistory = {startHistory}");
    }

    private void historyText() {
        language = GP_Language.Current();
        if(startHistory == 0 && magPanel.activeSelf == true) {
            smithyButton.gameObject.SetActive(false);
            sneilLevelStartButton.gameObject.SetActive(false);

            nextTextButton.gameObject.SetActive(true);
            nextTextButton.interactable = true;

            if(Language.Russian == language) {
                textHistory.text = noSneilLevelHistoryTextRu[indexHistoryText];
            } else {
                textHistory.text = noSneilLevelHistoryTextEng[indexHistoryText];
            }

            if(indexHistoryText % 2 != 0) {
                arrowPlayerImage.SetActive(true);
                arrowOrsicImage.SetActive(false);
            } else {
                arrowPlayerImage.SetActive(false);
                arrowOrsicImage.SetActive(true);
            }

            if(indexHistoryText == 14) {
                nextTextButton.gameObject.SetActive(false);
                sneilLevelStartButton.gameObject.SetActive(true);
                sneilLevelStartButton.interactable = true;
            }


        } else if(startHistory == 1 && magPanel.activeSelf == true) {


            smithyButton.gameObject.SetActive(false);
            sneilLevelStartButton.gameObject.SetActive(false);

            nextTextButton.gameObject.SetActive(true);
            nextTextButton.interactable = true;

            if(Language.Russian == language) {
                textHistory.text = YesSneilLevelHistoryTextRu[indexHistoryText];
            } else {
                textHistory.text = YesSneilLevelHistoryTextEng[indexHistoryText];
            }

            if(indexHistoryText % 2 == 0) {
                arrowPlayerImage.SetActive(true);
                arrowOrsicImage.SetActive(false);
            } else {
                arrowPlayerImage.SetActive(false);
                arrowOrsicImage.SetActive(true);
            }

            if(indexHistoryText == 36) {
                smithyButton.gameObject.SetActive(true);

                nextTextButton.gameObject.SetActive(false);

                sneilLevelStartButton.gameObject.SetActive(true);
            }

        } else {
            smithyButton.gameObject.SetActive(true);
            sneilLevelStartButton.gameObject.SetActive(true);
            nextTextButton.gameObject.SetActive(false);

        }
    }

    public void onClickNextHistoryButton() {
        indexHistoryText++;
    }


    public void onCleckExitMagButton() {
        magPanel.SetActive(false);
        smithy.SetActive(false);
        smithyButton.interactable = true;
        audioSource.PlayOneShot(dorClip);

        if(startHistory == 0) {
            indexHistoryText = 0;
        }

        onEventClickExitMagButton?.Invoke();
    }

    public void onClickSmithybutton() {
        smithy.SetActive(true);
        CheckLanguage();
        
        textMagHistoryPanel.SetActive(false);

        smithyButton.interactable = false;
        exitButton.interactable = false;
        sneilLevelStartButton.interactable = false;
    }

    public void onClickExitSmithybutton() {
        smithy.SetActive(false);
        textMagHistoryPanel.SetActive(true);

        smithyButton.interactable = true;
        exitButton.interactable = true;
        sneilLevelStartButton.interactable = true;
        CheckLanguage();
    }

    public void onClickSwordImageButton() {
        onEventClickSwordImageButton?.Invoke();
    }

    public void onClickSpearDamageImageButton() {
        onEventSpearDamageImageButton?.Invoke();
    }

    public void onClickSpearImageButton() {
        onEventSpearImageButton?.Invoke();
    }

    public void onClickSneilLevelButton() {
        onEventClickSneilLevelButton?.Invoke();
        magPanel.SetActive(false);
    }


}
