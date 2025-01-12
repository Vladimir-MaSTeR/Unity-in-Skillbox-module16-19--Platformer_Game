using System;
using GamePush;
using UnityEngine;
public class DragonLevelController : MonoBehaviour {
    [Header("Звук")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dorClip;

    [Header("Необходимый урон для входа к боссу")]
    [SerializeField] private int requiredDamage = 80;

    private string str1Ru = "Пока рано. Нужно зайти к Орсику";
    private string str1Eng = "Not yet. I need to go to Orsik's";

    private string str2Ru = "Надо подкачаться в подвале Орсика. Думаю урона больше 80 хватит...";
    private string str2Eng = "We need to pump up in Orsik's basement. I think more than 80 damage is enough...";

    private Language language;

    private int endSneilLevel = 0;
    private string currentDialogText = "";

    private int currentDamageSword = 0;
    private int currentDamageSpear = 0;

    //---EVENT---
    public static Action<String> onEventDragonLEvel;
    public static Action onEventStartDragonLevel;


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            if(Input.GetKeyDown(KeyCode.E)) {
                LaodDamageAndHistorySave();
                Debug.Log($"endSneilLevel = {endSneilLevel}");


                if(endSneilLevel == 0) {
                    language = GP_Language.Current();
                    if(Language.Russian == language) {
                        onEventDragonLEvel?.Invoke(str1Ru);
                    } else {
                        onEventDragonLEvel?.Invoke(str1Eng);
                    }

                } else {
                    language = GP_Language.Current();
                    if(Language.Russian == language) {
                        onEventDragonLEvel?.Invoke(str2Ru);
                    } else {
                        onEventDragonLEvel?.Invoke(str2Eng);
                    }
                }

                if(endSneilLevel > 0 && currentDamageSword >= requiredDamage || endSneilLevel > 0 && currentDamageSpear >= requiredDamage) {
                    audioSource.PlayOneShot(dorClip);
                    onEventStartDragonLevel?.Invoke();
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            if(Input.GetKey(KeyCode.E)) {

                LaodDamageAndHistorySave();
                Debug.Log($"endSneilLevel = {endSneilLevel}");


                if(endSneilLevel == 0) {
                    language = GP_Language.Current();
                    if(Language.Russian == language) {
                        onEventDragonLEvel?.Invoke(str1Ru);
                    } else {
                        onEventDragonLEvel?.Invoke(str1Eng);
                    }

                } else {
                    language = GP_Language.Current();
                    if(Language.Russian == language) {
                        onEventDragonLEvel?.Invoke(str2Ru);
                    } else {
                        onEventDragonLEvel?.Invoke(str2Eng);
                    }
                }

                if(endSneilLevel > 0 && currentDamageSword >= requiredDamage || endSneilLevel > 0 && currentDamageSpear >= requiredDamage) {
                    audioSource.PlayOneShot(dorClip);
                    onEventStartDragonLevel?.Invoke();
                }
            }
        }
    }


    private void LaodDamageAndHistorySave() {
        if(PlayerPrefs.HasKey("DamageSword")) {
            currentDamageSword = PlayerPrefs.GetInt("DamageSword");
            Debug.Log($"загрузил DamageSword = {currentDamageSword}");
        }

        if(PlayerPrefs.HasKey("DamageSpear")) {
            currentDamageSpear = PlayerPrefs.GetInt("DamageSpear");
            Debug.Log($"загрузил DamageSpear = {currentDamageSpear}");
        }

        if(PlayerPrefs.HasKey("startHistory")) {
            endSneilLevel = PlayerPrefs.GetInt("startHistory");
            Debug.Log($"загрузил startHistory = {endSneilLevel}");
        } else {
            endSneilLevel = 0;
        }
    }
}
