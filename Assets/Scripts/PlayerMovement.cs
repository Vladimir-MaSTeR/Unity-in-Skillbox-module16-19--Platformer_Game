
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject animObject;

    [Header("”правление  анвасами")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Canvas dialogCanvas;
    [SerializeField] private Text dialogText;
    [SerializeField] private float timeVisionDialogTextMax = 3;

    [SerializeField] private GameObject magPanel; // если эта панель активна значит мы в магазине и не дожны двигатьс€.

    [Header("”правление звуками")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip   fire1Clip;
    [SerializeField] private AudioClip   jumpClip;





    private Rigidbody2D rigidBody;
    private bool isLadder = false;
    private bool checkIsAlivePlayer;

    private bool checkDialogTriger = false;
    private float currentTimeVisionDialogText;

    private bool currentActiveMagPanel;


    private void Awake()
    {
        Time.timeScale = 1;
        rigidBody = GetComponent<Rigidbody2D>();
        checkIsAlivePlayer = healthScript.CheckIsAlive();
        deathPanel.SetActive(false);
        dialogCanvas.gameObject.SetActive(false);
        currentTimeVisionDialogText = timeVisionDialogTextMax;

        currentActiveMagPanel = magPanel.activeSelf;
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

        dialogTimer();

    }

    private void Update()
    {
        currentActiveMagPanel = magPanel.activeSelf;
    }

    private void CheckEndAnimDeath()
    {
        if (checkEndAnim.GetEndAnim() == true)
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }
    }


    public void Move(float horizontalDirection, float verticalDirection, bool isJumpButtonPresed, bool isFire1ButtonPresed, bool isFire2ButtonPresed)
    {

        if (isFire2ButtonPresed)
        {
            audioSource.PlayOneShot(fire1Clip);
        }

        if (!currentActiveMagPanel)
        {

            if (isFire1ButtonPresed)
            {
                animator.SetBool("isAttack", true);
                audioSource.PlayOneShot(fire1Clip);
            }
            else
            {
                animator.SetBool("isAttack", false);
            }

            if (isJumpButtonPresed)
            {
                Jump();
                animator.SetBool("isJump", true);

            }
            else
            {
                animator.SetBool("isJump", false);

            }

            if (horizontalDirection != 0)
            {
                animator.SetBool("isWalk", true);
                HorizontalMovement(horizontalDirection);
            }
            else
            {
                animator.SetBool("isWalk", false);
            }

            if (verticalDirection != 0)
            {
                VerticalMovemrnt(verticalDirection);
            }
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            audioSource.PlayOneShot(jumpClip);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            
        }
    }

    private void HorizontalMovement(float horizontalDirection)
    {
        float positionX = rigidBody.transform.position.x;

        if (horizontalDirection >= 0)
        {
            animObject.transform.rotation = new Quaternion(0, 0, 0, Quaternion.identity.w);
            //gameObject.transform.rotation = new Quaternion(0, 0, 0, Quaternion.identity.w);
            //spriteRenderer.flipX = false;
            //dialogText.rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
            rigidBody.velocity = new Vector2(horizontalDirection * spped, rigidBody.velocity.y);
            
            
        } else
        {
            animObject.transform.rotation = new Quaternion(0, 180, 0, Quaternion.identity.w);
           // gameObject.transform.rotation = new Quaternion(0, 180, 0, Quaternion.identity.w);
            //spriteRenderer.flipX = true;
            //dialogText.rectTransform.localRotation = Quaternion.Euler(0, 180, 0);
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

        if (collision.CompareTag("Ladder"))
        {
            Debug.Log("Ћестница");
            isLadder = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogTriger"))
        {
            checkDialogTriger = true;
            dialogCanvas.gameObject.SetActive(true);
            dialogText.text = collision.GetComponent<DialogTrigerController>().getCurrentDialogText();
        }
    }

    private void dialogTimer()
    {
        if (checkDialogTriger == true)
        {
            currentTimeVisionDialogText -= Time.deltaTime;
        }

        if (currentTimeVisionDialogText <= 0)
        {
            dialogCanvas.gameObject.SetActive(false);
            checkDialogTriger = false;
            currentTimeVisionDialogText = timeVisionDialogTextMax;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }
}
