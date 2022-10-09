using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointInstantiate;
    [SerializeField] private float fireSpeed = 15;
    //[SerializeField] private int valueBulet = 10;


    //------EVENTS---------
    public static Func<int> onSpearValue;

    private int currentValueBuletInPlayer;

    public void Shoot(float derection)
    {
        currentValueBuletInPlayer = (int)(onSpearValue?.Invoke());
        Debug.Log($"Кооличество копий = {currentValueBuletInPlayer}");

        if (currentValueBuletInPlayer > 0)
        {
            GameObject currentBullet = Instantiate(bullet, pointInstantiate.position, Quaternion.identity);

            Rigidbody2D currentBulletVeloscity = currentBullet.GetComponent<Rigidbody2D>();

            if (derection >= 0)
            {
                currentBulletVeloscity.velocity = new Vector2(fireSpeed * 1, currentBulletVeloscity.velocity.y);
            }
            else
            {
                currentBulletVeloscity.gameObject.transform.rotation = new Quaternion(0, 0, 180, Quaternion.identity.w);
                currentBulletVeloscity.velocity = new Vector2(fireSpeed * -1, currentBulletVeloscity.velocity.y);

            }
        } 
    }

    public int GetCurrentValueBuletInPlayer()
    {
        return currentValueBuletInPlayer;
    }

    public void SetCurrentValueBuletInPlayer(int curentValue)
    {
        if (currentValueBuletInPlayer > 0)
        {
            currentValueBuletInPlayer = curentValue;
        }
    }

}
