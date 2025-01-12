using GamePush;
using Texts;
using TMPro;
using UnityEngine;
public class PressETriger : MonoBehaviour {
    [SerializeField] private Canvas pressECanvas;

    [Space]
    [Header("---------- ��������� ���� ---------")]
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
        language = GP_Language.Current();
        if(Language.Russian == language) {
            Debug.Log($"���� ���� - �������");
            if(null != _text) {
                _text.text = HistoryTextRu.SAVE_TEXT_RU;
            }
        } else if(Language.English == language) {
            Debug.Log($"���� ���� - ����������");
            if(null != _text) {
                _text.text = HistoryTextEng.SAVE_TEXT_ENG;
            }
        } else if(Language.Turkish == language) {
            Debug.Log($"���� ���� - ��������");
        } else if(Language.German == language) {
            Debug.Log($"���� ���� - ��������");
        } else if(Language.Spanish == language) {
            Debug.Log($"���� ���� - ���������");
        }
    }
}
