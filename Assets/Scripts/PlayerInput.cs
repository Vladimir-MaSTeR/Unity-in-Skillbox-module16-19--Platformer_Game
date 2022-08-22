
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{  // ����� �������� �� ���������� ������� ������.

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalConstants.HORIZONTAL_AXIS); //GetAxisRaw - ���������� 0 ���� �������� ���, -1 ��� 1 ���� �������� ����
        bool isJumpButtonPresed = Input.GetButtonDown(GlobalConstants.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPresed);
    }
}
