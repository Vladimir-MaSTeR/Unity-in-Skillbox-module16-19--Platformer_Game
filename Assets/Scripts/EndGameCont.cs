using GamePush;
using Texts;
using TMPro;
using UnityEngine;
public class EndGameCont : MonoBehaviour {
    [SerializeField] private GameObject _dragon;
    [SerializeField] private GameObject _endGamePanel;

    [Space(20)]
    [Header("---------- “≈ —“ќ¬џ≈ ѕќЋя “»“–ќ¬ ----------")]
    [SerializeField] private TextMeshProUGUI _endGameMainText;
    [SerializeField] private TextMeshProUGUI _mainMenuButtonTextEndGamePanel;

    private Language language;

    void Start() {
        _endGamePanel.SetActive(false);
    }

    void Update() {
        if(_dragon.activeSelf == false) {
            Time.timeScale = 0;
            _endGamePanel.SetActive(true);
            if(Language.Russian == language) {
                // buttonText.text = "начать игру";
                Debug.Log($"язык игры - –усский");
                _endGameMainText.text = HistoryTextRu.END_GAME_MAIN_TEXT_RU;
                _mainMenuButtonTextEndGamePanel.text = HistoryTextRu.MAIN_MENU_BUTTON_TEXT_END_GAME_PANEL_RU;
            } else if(Language.English == language) {
                Debug.Log($"язык игры - јнглийский");
                _endGameMainText.text = HistoryTextEng.END_GAME_MAIN_TEXT_ENG;
                _mainMenuButtonTextEndGamePanel.text = HistoryTextEng.MAIN_MENU_BUTTON_TEXT_END_GAME_PANEL_ENG;
            } else if(Language.Turkish == language) {
                Debug.Log($"язык игры - “урецкий");
            } else if(Language.German == language) {
                Debug.Log($"язык игры - Ќемецкий");
            } else if(Language.Spanish == language) {
                Debug.Log($"язык игры - »спанский");
            }
        }
    }
}
