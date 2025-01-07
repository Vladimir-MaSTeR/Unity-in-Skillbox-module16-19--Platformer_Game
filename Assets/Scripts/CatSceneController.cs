using UnityEngine;
public class CatSceneController : MonoBehaviour {
    [SerializeField] private GameObject catSceneTriger;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject catScene;
    [SerializeField] private GameObject camera2;
    [SerializeField] private GameObject camera3;


    private void Start() {
        catScene.SetActive(false);
        catSceneTriger.SetActive(true);
    }

    private void Update() {
        if(catScene.activeSelf) {
            if(camera2.activeSelf == false && camera3.activeSelf == false) {
                catScene.SetActive(false);
                camera.SetActive(true);

                catSceneTriger.SetActive(false);
                player.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            player.SetActive(false);
            camera.SetActive(false);
            catScene.SetActive(true);

        }
    }
}
