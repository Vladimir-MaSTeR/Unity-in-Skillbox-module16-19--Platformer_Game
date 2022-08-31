
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{  // Класс отвечает за считывание нажатия кнопок.

    private PlayerMovement playerMovement;
    private Shooter shooter;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }


    private void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalConstants.HORIZONTAL_AXIS); //GetAxisRaw - возвращает 0 если движения нет, -1 или 1 если движение есть
        float verticalDirection = Input.GetAxis(GlobalConstants.VERTICAL_AXIS); 
        bool isJumpButtonPresed = Input.GetButtonDown(GlobalConstants.JUMP);
        bool isFire1ButtonPresed = Input.GetButtonDown(GlobalConstants.FIRE_1);


        if (Input.GetButtonDown(GlobalConstants.FIRE_2))
        {
            shooter.Shoot(horizontalDirection);
        }

        playerMovement.Move(horizontalDirection, verticalDirection, isJumpButtonPresed, isFire1ButtonPresed);
    }
}
