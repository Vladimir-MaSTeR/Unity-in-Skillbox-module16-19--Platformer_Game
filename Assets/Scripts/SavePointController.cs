using System;
using GamePush;
using Texts;
using TMPro;
using UnityEngine;
public class SavePointController : MonoBehaviour {
    [SerializeField] private GameObject[] needToShowObject;
    [SerializeField] private GameObject[] needToFalseShowObject;

    [Space(20)]
    [Header("---------- КАНВАС ---------")]
    [SerializeField] private Canvas pressECanvas;

    [Space(20)]
    [Header("---------- ТЕКСТОВЫЕ ПОЛЯ ---------")]
    [SerializeField] private TextMeshProUGUI _text;

    private Language language;

    public static Action onTapSavePoint;


    private void Start() {
        pressECanvas.gameObject.SetActive(false);
        foreach(var item in needToShowObject) {
            item.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            pressECanvas.gameObject.SetActive(true);
            ChechLanguage();

            // if(Input.GetKeyDown(KeyCode.E)) {
            if(Input.GetKey(KeyCode.E)) {
                onTapSavePoint?.Invoke();
                foreach(var item in needToShowObject) {
                    item.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            // if(Input.GetKeyDown(KeyCode.E)) {
            if(Input.GetKey(KeyCode.E)) {
                onTapSavePoint?.Invoke();
                foreach(var item in needToShowObject) {
                    item.SetActive(true);
                }
            }
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
            Debug.Log($"Язык игры - Русский");
            if(null != _text) {
                _text.text = HistoryTextRu.SAVE_TEXT_RU;
            }
        } else if(Language.English == language) {
            Debug.Log($"Язык игры - Английский");
            if(null != _text) {
                _text.text = HistoryTextEng.SAVE_TEXT_ENG;
            }
        } else if(Language.Turkish == language) {
            Debug.Log($"Язык игры - Турецкий");
        } else if(Language.German == language) {
            Debug.Log($"Язык игры - Немецкий");
        } else if(Language.Spanish == language) {
            Debug.Log($"Язык игры - Испанский");
        }
    }
}
