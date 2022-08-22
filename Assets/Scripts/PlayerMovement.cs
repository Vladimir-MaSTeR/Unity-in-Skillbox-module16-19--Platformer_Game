
using UnityEngine;
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


    public void Move(float direction, bool isJumpButtonPresed)
    {
        if (isJumpButtonPresed)
        {
            Jump();
            animator.SetBool("isJump", true);
           
        } else
        {
            animator.SetBool("isJump", false);

        }

        if (direction != 0)
        {
            animator.SetBool("isWalk", true);
            HorizontalMovement(direction);
        } else
        {
            animator.SetBool("isWalk", false);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            
        }
    }

    private void HorizontalMovement(float direction)
    {
        rigidBody.velocity = new Vector2(direction * spped, rigidBody.velocity.y);
    }

}
