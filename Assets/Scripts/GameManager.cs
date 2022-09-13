using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Текстовые поля")]
    [SerializeField] private Text damageSwordText;
    [SerializeField] private Text damageSpearText;
    [SerializeField] private Text valueSpearOnPlayerText;
    [SerializeField] private Text valueCoinText;

    [Header("Стартавые параметры")]
    [SerializeField] private int StartCoin = 200;
    [SerializeField] private int startSpearDamage = 4;

    [Header("Звук")]
    [SerializeField] private AudioSource source;

    [Header("Клипы")]
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip spearDamageClip;
    [SerializeField] private AudioClip buyMagTruyClip;
    [SerializeField] private AudioClip buyMagfalseClip;



    private int currentDamageSwordText;
    private int currentDamageSpearText;
    private int currentvalueSpearOnPlayerText;

    private int currentCoin;

    private void Start()
    {
        currentDamageSpearText = startSpearDamage;
        currentCoin = StartCoin;
    }

    private void Update()
    {


        damageSwordText.text = currentDamageSwordText.ToString();
        damageSpearText.text = currentDamageSpearText.ToString();
        valueSpearOnPlayerText.text = currentvalueSpearOnPlayerText.ToString();
        UpdateCoinText();



    }


    private void OnEnable()
    {
        DamageDealler.onSpearDamage += GetCurrentDamageSpearText;
        DamageDealler.onCollisionWithEnemy += PlaySpearDamageClip;
        Coin.onCoin += PlusValueCurrentCoin;

        MagController.onEventClickSwordImageButton += buyInShopSwordDamage;
        MagController.onEventSpearDamageImageButton += buyInShopSpearDamage;
        MagController.onEventSpearImageButton += buyInShopSpear;
    }

    private void OnDisable()
    {
        DamageDealler.onSpearDamage -= GetCurrentDamageSpearText;
        DamageDealler.onCollisionWithEnemy -= PlaySpearDamageClip;
        Coin.onCoin -= PlusValueCurrentCoin;

        MagController.onEventClickSwordImageButton -= buyInShopSwordDamage;
        MagController.onEventSpearDamageImageButton -= buyInShopSpearDamage;
        MagController.onEventSpearImageButton -= buyInShopSpear;




    }

    public void buyInShopSpear()
    {
        if (currentvalueSpearOnPlayerText < 100 && currentCoin >= 10)
        {
            currentvalueSpearOnPlayerText += 5;
            currentCoin -= 10;
            source.PlayOneShot(buyMagTruyClip);
        } else
        {
            source.PlayOneShot(buyMagfalseClip);
        }
    }

    public void buyInShopSpearDamage()
    {
        if (currentDamageSpearText < 100 && currentCoin >= 50)
        {
            currentDamageSpearText += 10;
            currentCoin -= 50;
            source.PlayOneShot(buyMagTruyClip);
        } else
        {
            source.PlayOneShot(buyMagfalseClip);
        }

    }

    public void buyInShopSwordDamage() 
    {
        if (currentDamageSwordText < 100 && currentCoin >= 30)
        {
            currentDamageSwordText += 10;
            currentCoin -= 30;
            source.PlayOneShot(buyMagTruyClip);
        }
        else
        {
            source.PlayOneShot(buyMagfalseClip);
        }
    }

   

    public void PlaySpearDamageClip()
    {
        source.PlayOneShot(spearDamageClip);
    }

    public int GetCurrentCoin()
    {
        return this.currentCoin;
    }

    public void SetCurrentCoin(int value)
    {
        currentCoin = value;
    }

    public void PlusValueCurrentCoin(int value)
    {
        currentCoin += value;
        source.PlayOneShot(coinClip);
    }

    private void UpdateCoinText()
    {
        valueCoinText.text = currentCoin.ToString();
    }


    public int GetCurrentDamageSwordText()
    {
        return this.currentDamageSwordText;
    }

    public void SetCurrentDamageSwordText(int value)
    {
        this.currentDamageSwordText = value;
    }

    public int GetCurrentDamageSpearText()
    {
        return this.currentDamageSpearText;
    }

    public void SetCurrentDamageSpearText(int value)
    {
        this.currentDamageSpearText = value;
    }

    public int GetCurrentvalueSpearOnPlayerText()
    {
        return this.currentvalueSpearOnPlayerText;
    }

    public void SetCurrentvalueSpearOnPlayerText(int value)
    {
        this.currentvalueSpearOnPlayerText = value;
    }
}
