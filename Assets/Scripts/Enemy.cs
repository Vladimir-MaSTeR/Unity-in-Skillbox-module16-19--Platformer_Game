using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject coin;
    [SerializeField] private Transform pointInstantiateCoin;
    [SerializeField] private float speed;
    [SerializeField] private float timeToRevert;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Animator animator;
    [SerializeField] private Health healthScript;
    [SerializeField] private CheckEndAnim checkEndAnim;
    [SerializeField] private DetectedTriger detectedTriger;


    private bool checkIsAliveEnemy;
    private Rigidbody2D rigidBody;

    private const float IDLE_STATE = 0;
    private const float WALC_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState;
    private float currentTimeRevert;



    public static Action onDeathEnemy;



    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        checkIsAliveEnemy = healthScript.CheckIsAlive();
        currentState = WALC_STATE;   
        currentTimeRevert = 0;
    }

    private void Update()
    {

        checkIsAliveEnemy = healthScript.CheckIsAlive();

        if (!checkIsAliveEnemy)
        {
            animator.SetBool("isAlive", false);
        }

        CheckEndAnimDeath();
        checkCurentState();
        CheckPlayerDetected();


        // checkCurentState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Произошла колизия Монстра");

        if (collision.CompareTag("EnemyStoper"))
        {
            Debug.Log("Монстр задел тригер для разварота");

            currentState = IDLE_STATE;
        }
    }


    private void CheckEndAnimDeath()
    {
        if (checkEndAnim.GetEndAnim() == true)
        {
            Instantiate(coin, pointInstantiateCoin.position, Quaternion.identity);
            onDeathEnemy?.Invoke();
            enemy.SetActive(false);
        }
    }

   private void CheckPlayerDetected()
    {
        if (detectedTriger.getPlayerDetected() == true)
        {
            animator.SetBool("detected", true);
           // currentState = IDLE_STATE;
        } else
        {
            animator.SetBool("detected", false);
            //currentState = WALC_STATE;
        }
    }
  
    private void checkCurentState()
    {
        if (currentTimeRevert >= timeToRevert)
        {
            currentTimeRevert = 0;
            currentState = REVERT_STATE;
        }

        switch(currentState)
        {
            case IDLE_STATE:
                currentTimeRevert += Time.deltaTime;
                break;
            case WALC_STATE:
                rigidBody.velocity = Vector2.left * speed;
                break;
            case REVERT_STATE:
                spriteRenderer.flipX = !spriteRenderer.flipX;
                speed *= -1;
                currentState = WALC_STATE; ;
                break;
        }

        animator.SetFloat("Velocity", rigidBody.velocity.magnitude); 
    }

}
