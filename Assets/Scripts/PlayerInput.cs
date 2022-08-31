
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{  // ����� �������� �� ���������� ������� ������.

    private PlayerMovement playerMovement;
    private Shooter shooter;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }


    private void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalConstants.HORIZONTAL_AXIS); //GetAxisRaw - ���������� 0 ���� �������� ���, -1 ��� 1 ���� �������� ����
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
