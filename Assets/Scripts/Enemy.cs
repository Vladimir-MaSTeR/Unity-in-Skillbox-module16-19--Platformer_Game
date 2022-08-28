using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    [SerializeField] private Animator animator;
    [SerializeField] private Health healthScript;
    [SerializeField] private CheckEndAnim checkEndAnim;
    [SerializeField] private DetectedTriger detectedTriger;


    private bool checkIsAliveEnemy;


    private void Start()
    {
        checkIsAliveEnemy = healthScript.CheckIsAlive();
    }

    private void Update()
    {

        checkIsAliveEnemy = healthScript.CheckIsAlive();

        if (!checkIsAliveEnemy)
        {
            animator.SetBool("isAlive", false);
        }

        CheckEndAnimDeath();
        CheckPlayerDetected();
    }


    private void CheckEndAnimDeath()
    {
        if (checkEndAnim.GetEndAnim() == true)
        {
            enemy.SetActive(false);
        }
    }

   private void CheckPlayerDetected()
    {
        if (detectedTriger.getPlayerDetected() == true)
        {
            animator.SetBool("detected", true);
        } else
        {
            animator.SetBool("detected", false);
        }
    }

}
