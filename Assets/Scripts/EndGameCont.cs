using UnityEngine;
public class EndGameCont : MonoBehaviour {
    [SerializeField] private GameObject _dragon;
    [SerializeField] private GameObject _endGamePanel;


    void Start() {
        _endGamePanel.SetActive(false);
    }

    void Update() {
        if(_dragon.activeSelf == false) {
            Time.timeScale = 0;
            _endGamePanel.SetActive(true);
        }
    }
}
