using UnityEngine;
public class LeverController : MonoBehaviour {
    [SerializeField] private Transform leverGameObjectTransform;
    [SerializeField] private GameObject[] needToShowObject;
    [SerializeField] private GameObject[] needToFalseShowObject;


    private void Start() {
        foreach(var item in needToShowObject) {
            item.SetActive(false);
        }
    }


    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag("Player") && Input.GetKey(KeyCode.E)) {

            leverGameObjectTransform.rotation = new Quaternion(0, 0, 0, Quaternion.identity.w);

            foreach(var item in needToShowObject) {
                item.SetActive(true);
            }

            foreach(var item in needToFalseShowObject) {
                item.SetActive(false);
            }
        }
    }
}
