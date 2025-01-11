using GamePush;
using Texts;
using TMPro;
using UnityEngine;

namespace DefaultNamespace {
    public class PressETrigerFinish : MonoBehaviour {
        [SerializeField] private Canvas pressECanvas;

        [Space]
        [Header("---------- “≈ —“ќ¬џ≈ ѕќЋя ---------")]
        [SerializeField] private TextMeshProUGUI _text;

        private Language language;

        private void Start() {
            pressECanvas.gameObject.SetActive(false);
        }


        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.CompareTag("Player")) {
                pressECanvas.gameObject.SetActive(true);
                ChechLanguage();
            }
        }
        private void OnTriggerExit2D(Collider2D collision) {
            if(collision.CompareTag("Player")) {
                pressECanvas.gameObject.SetActive(false);
            }
        }

        private void ChechLanguage() {
            if(Language.Russian == language) {
                Debug.Log($"язык игры - –усский");
                if(null != _text) {
                    _text.text = HistoryTextRu.EXIT_TEXT_SNAIL_SCEN_RU;
                }
            } else if(Language.English == language) {
                Debug.Log($"язык игры - јнглийский");
                if(null != _text) {
                    _text.text = HistoryTextEng.EXIT_TEXT_SNAIL_SCEN_ENG;
                }
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
