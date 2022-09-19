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
    [SerializeField] private int startSpearDamage = 5;
    [SerializeField] private int startvalueSpearDamage = 30;
    [SerializeField] private int startSwordDamage = 4;

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
        currentDamageSwordText = startSwordDamage;
        currentDamageSpearText = startSpearDamage;
        currentvalueSpearOnPlayerText = startvalueSpearDamage;
        currentCoin = StartCoin;
    }

    private void Update()
    {

        LoadGame();
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
        MainCanvasController.onClickRestartButton += SaveGame;

        MagController.onEventClickSwordImageButton += buyInShopSwordDamage;
        MagController.onEventSpearDamageImageButton += buyInShopSpearDamage;
        MagController.onEventSpearImageButton += buyInShopSpear;
    }

    private void OnDisable()
    {
        DamageDealler.onSpearDamage -= GetCurrentDamageSpearText;
        DamageDealler.onCollisionWithEnemy -= PlaySpearDamageClip;
        Coin.onCoin -= PlusValueCurrentCoin;
        MainCanvasController.onClickRestartButton -= SaveGame;


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


    private void SaveGame()
    {
        PlayerPrefs.SetInt("DamageSword", currentDamageSwordText);
        PlayerPrefs.SetInt("DamageSpear", currentDamageSpearText);
        PlayerPrefs.SetInt("valueSpear", currentvalueSpearOnPlayerText);
        PlayerPrefs.SetInt("coin", currentCoin);
        PlayerPrefs.Save();
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("DamageSword"))
        {
            currentDamageSwordText = PlayerPrefs.GetInt("DamageSword");
        }

        if (PlayerPrefs.HasKey("DamageSpear"))
        {
            currentDamageSpearText = PlayerPrefs.GetInt("DamageSpear");
        }

        if (PlayerPrefs.HasKey("valueSpear"))
        {
            currentvalueSpearOnPlayerText = PlayerPrefs.GetInt("valueSpear");
        }

        if (PlayerPrefs.HasKey("coin"))
        {
            currentCoin = PlayerPrefs.GetInt("coin");
        }
    }


}
