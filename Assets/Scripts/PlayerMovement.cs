
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{ // Ётот  ласс работает с физикой


    [Header("Movement vars")]
    [SerializeField] private float spped = 3;
    [SerializeField] private float jumpForce = 6;
    [SerializeField] private bool isGrounded = false;

    [Header("Weapons on Player")]
    //[SerializeField] private GameObject weapons;

    [Header("Radius collider")]
    [SerializeField] private float jumpOffset;

    [Header("Settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Animator animator;
    [SerializeField] private Health healthScript;
    [SerializeField] private CheckEndAnim checkEndAnim;
    [SerializeField] private GameObject deathPanel;



    private Rigidbody2D rigidBody;
    private bool isLadder = false;
    private bool checkIsAlivePlayer;


    private void Awake()
    {
        Time.timeScale = 1;
        rigidBody = GetComponent<Rigidbody2D>();
        checkIsAlivePlayer = healthScript.CheckIsAlive();
        deathPanel.SetActive(false);
    }

    private void FixedUpdate() // —таратьс€ все обновлени€ физики делать в этом методе.
    {

        checkIsAlivePlayer = healthScript.CheckIsAlive();

        if (!checkIsAlivePlayer)
        {
            animator.SetBool("isAlive", false);
            CheckEndAnimDeath();
        } else
        {
            animator.SetBool("isAlive", true);

            //ƒл€ корректной работы с тайлами в 2д.
            //ћы рисуем круг, который чуть больше нашего колайдера дл€ ног у персонажа
            // и провер€ем столкнулс€ ли этот коллайде с колайдером земле
            // используем слои, всю землю положили на свой слой ground и работаем с этим слоем через LayerMask
            Vector3 overlapCirclePosition = groundColliderTransform.position;
            isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundLayerMask);
        }



    }  

    private void CheckEndAnimDeath()
    {
        if (checkEndAnim.GetEndAnim() == true)
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }
    }


    public void Move(float horizontalDirection, float verticalDirection, bool isJumpButtonPresed, bool isFire1ButtonPresed)
    {
        if (isFire1ButtonPresed)
        {
            animator.SetBool("isAttack", true);
        } else
        {
            animator.SetBool("isAttack", false);
        }

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
        float positionX = rigidBody.transform.position.x;

        if (horizontalDirection >= 0)
        {
            rigidBody.transform.rotation = new Quaternion(0, 0, 0, Quaternion.identity.w);
            rigidBody.velocity = new Vector2(horizontalDirection * spped, rigidBody.velocity.y);
            
            
        } else
        {
            rigidBody.transform.rotation = new Quaternion(0, 180, 0, Quaternion.identity.w);
            rigidBody.velocity = new Vector2(horizontalDirection * spped, rigidBody.velocity.y);
        
        }
            
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

        Debug.Log("ѕроисходит коллизи€");
        if (collision.CompareTag("Ladder"))
        {
            Debug.Log("ѕроисходит коллизи€");
            isLadder = true;
        }
        else
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ѕроизошла коллизи€ коллизи€");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
    }
}
