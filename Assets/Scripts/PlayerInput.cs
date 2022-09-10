
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{  // ����� �������� �� ���������� ������� ������.


    [SerializeField] private GameManager gameManagerScript;

    private PlayerMovement playerMovement;
    private Shooter shooter;
    

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();      
    }

    private void Start()
    {
        gameManagerScript.SetCurrentvalueSpearOnPlayerText(shooter.GetCurrentValueBuletInPlayer());
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
            shooter.SetCurrentValueBuletInPlayer(shooter.GetCurrentValueBuletInPlayer() - 1);

            gameManagerScript.SetCurrentvalueSpearOnPlayerText(shooter.GetCurrentValueBuletInPlayer());

        }

        playerMovement.Move(horizontalDirection, verticalDirection, isJumpButtonPresed, isFire1ButtonPresed);
    }
}
