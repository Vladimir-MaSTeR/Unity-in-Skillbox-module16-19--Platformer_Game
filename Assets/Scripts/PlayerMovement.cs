
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{ // ���� ����� �������� � �������


    [Header("Movement vars")]
    [SerializeField] private float spped = 3;
    [SerializeField] private float jumpForce = 6;
    [SerializeField] private bool isGrounded = false;

    [Header("Radius collider")]
    [SerializeField] private float jumpOffset;

    [Header("Settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Animator animator;

    private Rigidbody2D rigidBody;
    private bool isLadder = false;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() // ��������� ��� ���������� ������ ������ � ���� ������.
    {

        //��� ���������� ������ � ������� � 2�.
        //�� ������ ����, ������� ���� ������ ������ ��������� ��� ��� � ���������
        // � ��������� ���������� �� ���� �������� � ���������� �����
        // ���������� ����, ��� ����� �������� �� ���� ���� ground � �������� � ���� ����� ����� LayerMask
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundLayerMask);
        Debug.Log(isGrounded);
    }  


    public void Move(float horizontalDirection, float verticalDirection, bool isJumpButtonPresed)
    {
        if (isJumpButtonPresed)
        {
            Jump();
            animator.SetBool("isJump", true);
           
        } else
        {
            animator.SetBool("isJump", false);

        }

        if (horizontalDirection != 0)
        {
            animator.SetBool("isWalk", true);
            HorizontalMovement(horizontalDirection);
        } else
        {
            animator.SetBool("isWalk", false);
        }

        if (verticalDirection != 0)
        {
            VerticalMovemrnt(verticalDirection);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            
        }
    }

    private void HorizontalMovement(float horizontalDirection)
    {
        rigidBody.velocity = new Vector2(horizontalDirection * spped, rigidBody.velocity.y);
    }

    private void VerticalMovemrnt(float verticalDirection)
    {
        if (isLadder)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, verticalDirection * spped);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log("���������� ��������");
        if (collision.CompareTag("Ladder"))
        {
            Debug.Log("���������� ��������");
            isLadder = true;
        }
        else
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��������� �������� ��������");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
    }
}
