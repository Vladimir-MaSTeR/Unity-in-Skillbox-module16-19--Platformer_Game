using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishStage : MonoBehaviour {

    public static Action onfinishStage;
    public static Action onfinishStageSneil;

    private int startHistory = 1;


    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag("Player") && Input.GetKey(KeyCode.E)) {
            if(SceneManager.GetActiveScene().buildIndex == 2) {
                onfinishStageSneil?.Invoke();

                if(PlayerPrefs.HasKey("startHistory")) {
                    startHistory = PlayerPrefs.GetInt("startHistory");
                    Debug.Log($"загрузил переменную startHistory из памяти = {startHistory}");


                    PlayerPrefs.SetInt("startHistory", ++startHistory);
                    PlayerPrefs.Save();
                } else {
                    Debug.Log($"Переменная startHistory не найдена в памяти и будет равна = {startHistory}");
                    PlayerPrefs.SetInt("startHistory", startHistory);
                    PlayerPrefs.Save();
                }
            }

            onfinishStage?.Invoke();
        }
    }


}
