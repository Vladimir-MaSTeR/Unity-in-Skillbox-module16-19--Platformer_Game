using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("��������� ����")]
    [SerializeField] private Text damageSwordText;
    [SerializeField] private Text damageSpearText;
    [SerializeField] private Text valueSpearOnPlayerText;
    [SerializeField] private Text valueCoinText;

    [Header("��������� ���������")]
    [SerializeField] private int StartCoin = 200;
    [SerializeField] private int startSpearDamage = 5;
    [SerializeField] private int startvalueSpearDamage = 30;
    [SerializeField] private int startSwordDamage = 4;

    [Header("������ �� ������� ������")]
    [SerializeField] private Transform playerPosition;

    [Header("����")]
    [SerializeField] private AudioSource source;

    [Header("�����")]
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip spearDamageClip;
    [SerializeField] private AudioClip buyMagTruyClip;
    [SerializeField] private AudioClip buyMagfalseClip;
    [SerializeField] private AudioClip checkPointActivClip;



    private float resPositionAfterEndRoundX = 55.22f;
    private float resPositionAfterEndRoundY = -3.68f;

    private float resPositionSneilStartX = -39.88f;
    private float resPositionSneilStartY = 2.63f;

    private float resPositionBossStartX = -37.94f;
    private float resPositionBossStartY = -4.68f;


    private int currentDamageSwordText;
    private int currentDamageSpearText;
    private int currentvalueSpearOnPlayerText;

    private int currentCoin;

    private int startGameOneTap; // ���������� ���������� �� ��, ��� ���� ����������� � ������ ��� ��� ���. (0 = � ������ ���. 1 = �������� � ����� ��������� ����������)


   
    private void Start()
    {
        
        if (PlayerPrefs.HasKey("startGameTap"))
        {
            startGameOneTap = PlayerPrefs.GetInt("startGameTap");
            Debug.Log($"�������� startGameTap = {startGameOneTap}");
            PlayerPrefs.DeleteKey("startGameTap");

            if (PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY"))
            {
                PlayerPrefs.DeleteKey("PlayerPositionX");
                PlayerPrefs.DeleteKey("PlayerPositionY");
                
            }
        }
        
       

        Debug.Log($"�������� ��������� startGameOneTap = {startGameOneTap}");
        if (startGameOneTap == 0)
        {
            currentDamageSwordText = startSwordDamage;
            currentDamageSpearText = startSpearDamage;
            currentvalueSpearOnPlayerText = startvalueSpearDamage;
            currentCoin = StartCoin;

            if (PlayerPrefs.HasKey("startHistory"))
            {
                PlayerPrefs.DeleteKey("startHistory");
                Debug.Log("startHistory �������");
            }
            else
            {
                Debug.Log("startHistory  �� ������� � �����������");
            }

        } else
        {
            LoadGame();
        }
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
        MainCanvasController.onClickRestartButton += SaveGame;
        MagController.onEventClickExitMagButton += SaveGame;
        MainCanvasController.onClickRestartButton += ResstartLevel;
        MainCanvasController.onClickStartGameButton += CheckTapButtonsStartGameOneTap;
        Shooter.onSpearValue += GetCurrentvalueSpearOnPlayerText;
        ColdDamageDeallerOnPlayer.onSwordDamage += GetCurrentDamageSwordText;
        SavePointController.onTapSavePoint += SaveGameAndPlayer;
        MainCanvasController.onClicLoadLastSave += ResstartLevelAndStats;
        FinishStage.onfinishStage += EndRound;

        MagController.onEventClickSwordImageButton += buyInShopSwordDamage;
        MagController.onEventSpearDamageImageButton += buyInShopSpearDamage;
        MagController.onEventSpearImageButton += buyInShopSpear;
        MagController.onEventClickSneilLevelButton += StartSneilCnene;
        DragonLevelController.onEventStartDragonLevel += StartBossScene;
    }

    private void OnDisable()
    {
        DamageDealler.onSpearDamage -= GetCurrentDamageSpearText;
        DamageDealler.onCollisionWithEnemy -= PlaySpearDamageClip;
        Coin.onCoin -= PlusValueCurrentCoin;
        MainCanvasController.onClickRestartButton -= SaveGame;
        MagController.onEventClickExitMagButton -= SaveGame;
        MainCanvasController.onClickRestartButton -= ResstartLevel;
        MainCanvasController.onClickStartGameButton -= CheckTapButtonsStartGameOneTap;
        Shooter.onSpearValue -= GetCurrentvalueSpearOnPlayerText;
        ColdDamageDeallerOnPlayer.onSwordDamage -= GetCurrentDamageSwordText;
        SavePointController.onTapSavePoint -= SaveGameAndPlayer;
        MainCanvasController.onClicLoadLastSave -= ResstartLevelAndStats;
        FinishStage.onfinishStage -= EndRound;


        MagController.onEventClickSwordImageButton -= buyInShopSwordDamage;
        MagController.onEventSpearDamageImageButton -= buyInShopSpearDamage;
        MagController.onEventSpearImageButton -= buyInShopSpear;
        MagController.onEventClickSneilLevelButton -= StartSneilCnene;
        DragonLevelController.onEventStartDragonLevel -= StartBossScene;





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

    private void EndRound()
    {
        float xPosPlayer = resPositionAfterEndRoundX;
        float yPosPlayer = resPositionAfterEndRoundY;

        PlayerPrefs.SetFloat("PlayerPositionX", xPosPlayer);
        Debug.Log($"��������� ������� ������ �� x = {xPosPlayer}");

        PlayerPrefs.SetFloat("PlayerPositionY", yPosPlayer);
        Debug.Log($"��������� ������� ������ �� y = {yPosPlayer}");

        PlayerPrefs.Save();

        SaveGame();

        SceneManager.LoadScene(1);
    }

    private void StartSneilCnene()
    {
        float xPosPlayer = resPositionSneilStartX;
        float yPosPlayer = resPositionSneilStartY;

        PlayerPrefs.SetFloat("PlayerPositionX", xPosPlayer);
        Debug.Log($"��������� ������� ������ �� x = {xPosPlayer}");

        PlayerPrefs.SetFloat("PlayerPositionY", yPosPlayer);
        Debug.Log($"��������� ������� ������ �� y = {yPosPlayer}");

        PlayerPrefs.Save();

        SaveGame();
        SceneManager.LoadScene(2);
    }

    private void StartBossScene()
    {
        float xPosPlayer = resPositionBossStartX;
        float yPosPlayer = resPositionBossStartY;

        PlayerPrefs.SetFloat("PlayerPositionX", xPosPlayer);
        Debug.Log($"��������� ������� ������ �� x = {xPosPlayer}");

        PlayerPrefs.SetFloat("PlayerPositionY", yPosPlayer);
        Debug.Log($"��������� ������� ������ �� y = {yPosPlayer}");

        PlayerPrefs.Save();

        SaveGame();
        SceneManager.LoadScene(3);
    } 


    private void SaveGame()
    {
        startGameOneTap = 1;

        PlayerPrefs.SetInt("DamageSword", currentDamageSwordText);
        Debug.Log($"�������� DamageSword = {currentDamageSwordText}");

        PlayerPrefs.SetInt("DamageSpear", currentDamageSpearText);
        Debug.Log($"�������� DamageSpear = {currentDamageSpearText}");

        PlayerPrefs.SetInt("valueSpear", currentvalueSpearOnPlayerText);
        Debug.Log($"�������� valueSpear = {currentvalueSpearOnPlayerText}");

        PlayerPrefs.SetInt("coin", currentCoin);
        Debug.Log($"�������� coin = {currentCoin}");

        PlayerPrefs.SetInt("startGameTap", startGameOneTap);
        Debug.Log($"�������� startGameTap = {startGameOneTap}");

        PlayerPrefs.Save();
    }

    private void SaveGameAndPlayer()
    {
        source.PlayOneShot(checkPointActivClip); 
        float xPosPlayer = playerPosition.position.x;
        float yPosPlayer = playerPosition.position.y;

        PlayerPrefs.SetFloat("PlayerPositionX", xPosPlayer);
        Debug.Log($"��������� ������� ������ �� x = {xPosPlayer}");

        PlayerPrefs.SetFloat("PlayerPositionY", yPosPlayer);
        Debug.Log($"��������� ������� ������ �� y = {yPosPlayer}");

        PlayerPrefs.Save();

        SaveGame();

    }

    private void ResstartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResstartLevelAndStats()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LoadGame();
       // LoadGamePlayerPosition();
    }

    private void LoadGamePlayerPosition()
    {
        float xPosPlayer = playerPosition.position.x;
        float yPosPlayer = playerPosition.position.y;

        if (PlayerPrefs.HasKey("PlayerPositionX"))
        {
            xPosPlayer = PlayerPrefs.GetInt("PlayerPositionX");
            Debug.Log($"�������� PlayerPositionX = {xPosPlayer}");
        }

        if (PlayerPrefs.HasKey("PlayerPositionY"))
        {
            yPosPlayer = PlayerPrefs.GetInt("PlayerPositionY");
            Debug.Log($"�������� PlayerPositionY = {yPosPlayer}");
        }

        playerPosition.position = new Vector2(xPosPlayer, yPosPlayer);
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("DamageSword"))
        {
            currentDamageSwordText = PlayerPrefs.GetInt("DamageSword");
            Debug.Log($"�������� DamageSword = {currentDamageSwordText}");
        }

        if (PlayerPrefs.HasKey("DamageSpear"))
        {
            currentDamageSpearText = PlayerPrefs.GetInt("DamageSpear");
            Debug.Log($"�������� DamageSpear = {currentDamageSpearText}");
        }

        if (PlayerPrefs.HasKey("valueSpear"))
        {
            currentvalueSpearOnPlayerText = PlayerPrefs.GetInt("valueSpear");
            Debug.Log($"�������� valueSpear = {currentvalueSpearOnPlayerText}");
        }

        if (PlayerPrefs.HasKey("coin"))
        {
            currentCoin = PlayerPrefs.GetInt("coin");
            Debug.Log($"�������� coin = {currentCoin}");
        }
    }

    private void CheckTapButtonsStartGameOneTap()
    {
        startGameOneTap = 0;
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("startHistory");
    }

}
