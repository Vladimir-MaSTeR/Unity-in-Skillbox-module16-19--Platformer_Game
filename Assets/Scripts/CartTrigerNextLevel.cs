using UnityEngine;
public class CartTrigerNextLevel : MonoBehaviour {

    [SerializeField]
    private Transform cameraPosition;

    [SerializeField]
    private float cameraPositionX;


    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("������ ����� � ���� �������");

        if(collision.CompareTag("Cart")) {
            Debug.Log("������ �������� �� ������");

            cameraPosition.position = new Vector3(cameraPositionX, cameraPosition.position.y, cameraPosition.position.z);
        }
    }
}
