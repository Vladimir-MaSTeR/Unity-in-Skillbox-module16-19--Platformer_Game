
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{  // Класс отвечает за считывание нажатия кнопок.

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalConstants.HORIZONTAL_AXIS); //GetAxisRaw - возвращает 0 если движения нет, -1 или 1 если движение есть
        bool isJumpButtonPresed = Input.GetButtonDown(GlobalConstants.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPresed);
    }
}
