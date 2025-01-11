using GamePush;
using Texts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    // Этот Класс работает с физикой
    
    [Header("Movement vars")]
    [SerializeField] private float spped = 3;
    [SerializeField] private float jumpForce = 6;
    [SerializeField] private bool isGrounded = false;

    [Space(10)]
    [Header("--------- WEAPONS ON PLAYER ---------")]
    //[SerializeField] private GameObject weapons;
    
    [Space(10)]
    [Header("--------- RADIUS COLLIDER ---------")]
    [SerializeField] private float jumpOffset;

    [Space(20)]
    [Header("--------- SETTINGS ---------")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Animator animator;
    [SerializeField] private Health healthScript;
    [SerializeField] private CheckEndAnim checkEndAnim;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject animObject;

    [Space(20)]
    [Header("--------- УПРАВЛЕНИЕ КАНВАСАМИ ---------")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Canvas dialogCanvas;
    // [SerializeField] private Text dialogText;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private float timeVisionDialogTextMax = 3;

    [SerializeField] private GameObject magPanel; // если эта панель активна значит мы в магазине и не дожны двигаться.
    
    [Space(20)]
    [Header("---------- ТЕКСТОВЫЕ ПОЛЯ PAUSE PANEL ----------")]
    [SerializeField] private TextMeshProUGUI _mainDeathPanelText;
    [SerializeField] private TextMeshProUGUI _restartButtonDeathPanelText;
    [SerializeField] private TextMeshProUGUI _mainMenuButtonDeathPanelText;

    [Space(20)]
    [Header("--------- УПРАВЛЕНИЕ ЗВУКАМИ ---------")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fire1Clip;
    [SerializeField] private AudioClip jumpClip;


    private Rigidbody2D rigidBody;
    private bool isLadder = false;
    private bool checkIsAlivePlayer;

    private bool checkDialogTriger = false;
    private float currentTimeVisionDialogText;

    private bool currentActiveMagPanel;
    private Language language;

    private void OnEnable() {
        DragonLevelController.onEventDragonLEvel += DialogCanvasInDragonStage;
    }

    private void OnDisable() {
        DragonLevelController.onEventDragonLEvel -= DialogCanvasInDragonStage;

    }


    private void Awake() {
        Time.timeScale = 1;
        rigidBody = GetComponent<Rigidbody2D>();
        checkIsAlivePlayer = healthScript.CheckIsAlive();
        deathPanel.SetActive(false);
        dialogCanvas.gameObject.SetActive(false);
        currentTimeVisionDialogText = timeVisionDialogTextMax;

        currentActiveMagPanel = magPanel.activeSelf;

        if(PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY")) {
            float x = PlayerPrefs.GetFloat("PlayerPositionX");
            float y = PlayerPrefs.GetFloat("PlayerPositionY");

            transform.position = new Vector2(x, y);
        }
    }

    private void FixedUpdate() // Стараться все обновления физики делать в этом методе.
    {

        checkIsAlivePlayer = healthScript.CheckIsAlive();

        if(!checkIsAlivePlayer) {
            animator.SetBool("isAlive", false);
            CheckEndAnimDeath();
        } else {
            animator.SetBool("isAlive", true);

            //Для корректной работы с тайлами в 2д.
            //Мы рисуем круг, который чуть больше нашего колайдера для ног у персонажа
            // и проверяем столкнулся ли этот коллайде с колайдером земле
            // используем слои, всю землю положили на свой слой ground и работаем с этим слоем через LayerMask
            Vector3 overlapCirclePosition = groundColliderTransform.position;
            isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundLayerMask);
        }

        dialogTimer();

    }

    private void Update() {
        currentActiveMagPanel = magPanel.activeSelf;
    }

    private void CheckEndAnimDeath() {
        if(checkEndAnim.GetEndAnim() == true) {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
            
            if(Language.Russian == language) {
                // buttonText.text = "начать игру";
                Debug.Log($"Язык игры - Русский");
                _mainDeathPanelText.text = HistoryTextRu.MAIN_DEATH_PANEL_TEXT_RU;
                _restartButtonDeathPanelText.text = HistoryTextRu.RESTART_BUTTON_DEATH_PANEL_TEXT_RU;
                _mainMenuButtonDeathPanelText.text = HistoryTextRu.MAIN_MENU_BUTTON_DEATH_PANEL_TEXT_RU;
            } else if(Language.English == language) {
                Debug.Log($"Язык игры - Английский");
                _mainDeathPanelText.text = HistoryTextEng.MAIN_DEATH_PANEL_TEXT_ENG;
                _restartButtonDeathPanelText.text = HistoryTextEng.RESTART_BUTTON_DEATH_PANEL_TEXT_ENG;
                _mainMenuButtonDeathPanelText.text = HistoryTextEng.MAIN_MENU_BUTTON_DEATH_PANEL_TEXT_ENG;
            } else if(Language.Turkish == language) {
                Debug.Log($"Язык игры - Турецкий");
            } else if(Language.German == language) {
                Debug.Log($"Язык игры - Немецкий");
            } else if(Language.Spanish == language) {
                Debug.Log($"Язык игры - Испанский");
            }
        }
    }


    public void Move(float horizontalDirection, float verticalDirection, bool isJumpButtonPresed, bool isFire1ButtonPresed, bool isFire2ButtonPresed) {

        if(isFire2ButtonPresed) {
            audioSource.PlayOneShot(fire1Clip);
        }

        if(!currentActiveMagPanel) {

            if(isFire1ButtonPresed) {
                animator.SetBool("isAttack", true);
                audioSource.PlayOneShot(fire1Clip);
            } else {
                animator.SetBool("isAttack", false);
            }

            if(isJumpButtonPresed) {
                Jump();
                animator.SetBool("isJump", true);

            } else {
                animator.SetBool("isJump", false);

            }

            if(horizontalDirection != 0) {
                animator.SetBool("isWalk", true);
                HorizontalMovement(horizontalDirection);
            } else {
                animator.SetBool("isWalk", false);
            }

            if(verticalDirection != 0) {
                VerticalMovemrnt(verticalDirection);
            }
        }
    }

    private void Jump() {
        if(isGrounded) {
            audioSource.PlayOneShot(jumpClip);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

        }
    }

    private void HorizontalMovement(float horizontalDirection) {
        float positionX = rigidBody.transform.position.x;

        if(horizontalDirection >= 0) {
            animObject.transform.rotation = new Quaternion(0, 0, 0, Quaternion.identity.w);
            //gameObject.transform.rotation = new Quaternion(0, 0, 0, Quaternion.identity.w);
            //spriteRenderer.flipX = false;
            //dialogText.rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
            rigidBody.velocity = new Vector2(horizontalDirection * spped, rigidBody.velocity.y);


        } else {
            animObject.transform.rotation = new Quaternion(0, 180, 0, Quaternion.identity.w);
            // gameObject.transform.rotation = new Quaternion(0, 180, 0, Quaternion.identity.w);
            //spriteRenderer.flipX = true;
            //dialogText.rectTransform.localRotation = Quaternion.Euler(0, 180, 0);
            rigidBody.velocity = new Vector2(horizontalDirection * spped, rigidBody.velocity.y);

        }

    }

    private void VerticalMovemrnt(float verticalDirection) {
        if(isLadder) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, verticalDirection * spped);
        }

    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(collision.CompareTag("Ladder")) {
            Debug.Log("Лестница");
            isLadder = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("DialogTriger")) {
            checkDialogTriger = true;
            dialogCanvas.gameObject.SetActive(true);
            dialogText.text = collision.GetComponent<DialogTrigerController>().getCurrentDialogText();
        }
    }

    private void DialogCanvasInDragonStage(string str) {
        checkDialogTriger = true;
        dialogCanvas.gameObject.SetActive(true);
        dialogText.text = str;
    }

    private void dialogTimer() {
        if(checkDialogTriger == true) {
            currentTimeVisionDialogText -= Time.deltaTime;
        }

        if(currentTimeVisionDialogText <= 0) {
            dialogCanvas.gameObject.SetActive(false);
            checkDialogTriger = false;
            currentTimeVisionDialogText = timeVisionDialogTextMax;
        }
    }


    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Ladder")) {
            isLadder = false;
        }
    }
}
