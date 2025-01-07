using UnityEngine;
public class NextLevel : MonoBehaviour {
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float cameraPositionX;


    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("вы вошли в зону тригера");

        if(collision.CompareTag("Damagebl")) {
            Debug.Log("Игрок вошел в зону тригера");

            cameraPosition.position = new Vector3(cameraPositionX, cameraPosition.position.y, cameraPosition.position.z);
        }
    }
}
