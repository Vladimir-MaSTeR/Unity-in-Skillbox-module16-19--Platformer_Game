using GamePush;
using Texts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
public class GameManager : MonoBehaviour {
    [FormerlySerializedAs("damageSwordText")]
    [Header("---------- ТЕКСТОВЫЕ ПОЛЯ GAME INFO PANEL ----------")]
    [SerializeField] private TextMeshProUGUI countDamageSwordText;
    [SerializeField] private TextMeshProUGUI _damageSwordText;

    [Space(5)]
    [FormerlySerializedAs("damageSpearText")]
    [SerializeField] private TextMeshProUGUI CountDamageSpearText;
    [SerializeField] private TextMeshProUGUI _damageSpearText;

    [Space(5)]
    [FormerlySerializedAs("valueSpearOnPlayerText")]
    [SerializeField] private TextMeshProUGUI countValueSpearOnPlayerText;
    [SerializeField] private TextMeshProUGUI _valueSpearOnPlayerText;

    [Space(5)]
    [FormerlySerializedAs("valueCoinText")]
    [SerializeField] private TextMeshProUGUI countValueCoinText;
    [SerializeField] private TextMeshProUGUI _valueCoinText;

    [Space(5)]
    [SerializeField] private TextMeshProUGUI _pausedBattonText;

    [Space(20)]
    [Header("---------- СТАРТАВЫЕ ПАРАМЕТРЫ ----------")]
    [SerializeField] private int StartCoin = 200;
    [SerializeField] private int startSpearDamage = 5;
    [SerializeField] private int startvalueSpearDamage = 30;
    [SerializeField] private int startSwordDamage = 4;

    [Space(20)]
    [Header("---------- ССЫЛКА НА ПОЗИЦИЮ ИГРОКА ----------")]
    [SerializeField] private Transform playerPosition;

    [Space(20)]
    [Header("---------- ЗВУК ----------")]
    [SerializeField] private AudioSource source;

    [Space(20)]
    [Header("---------- КЛИПЫ ----------")]
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

    private int startGameOneTap; // переменная отвечающая за то, что игра запускается в первый раз или нет.
                                 // (0 = в первый раз. 1 = повторно и нужно подтянуть сохранения)
    private Language language;


    private void Start() {
        language = GP_Language.Current();
        if(null != _damageSwordText && null != _damageSpearText && null != _valueSpearOnPlayerText && null != _valueCoinText && null != _pausedBattonText) {
            language = GP_Language.Current();
            if(Language.Russian == language) {
                Debug.Log($"Язык игры - Русский");
                _damageSwordText.text = HistoryTextRu.SWORD_DAMAGE_TEXT_RU;
                _valueSpearOnPlayerText.text = HistoryTextRu.NUMBER_OF_COPIES_TEXT_RU;
                _damageSpearText.text = HistoryTextRu.DAMAGE_OF_COPIES_RU;
                _valueCoinText.text = HistoryTextRu.COIN_TEXT_RU;
                _pausedBattonText.text = HistoryTextRu.PAUSED_BATTON_RU;
            } else if(Language.English == language) {
                Debug.Log($"Язык игры - Английский");
                _damageSwordText.text = HistoryTextEng.SWORD_DAMAGE_TEXT_ENG;
                _valueSpearOnPlayerText.text = HistoryTextEng.NUMBER_OF_COPIES_TEXT_ENG;
                _damageSpearText.text = HistoryTextEng.DAMAGE_OF_COPIES_ENG;
                _valueCoinText.text = HistoryTextEng.COIN_TEXT_ENG;
                _pausedBattonText.text = HistoryTextEng.PAUSED_BATTON_ENG;
            } else if(Language.Turkish == language) {
                Debug.Log($"Язык игры - Турецкий");
            } else if(Language.German == language) {
                Debug.Log($"Язык игры - Немецкий");
            } else if(Language.Spanish == language) {
                Debug.Log($"Язык игры - Испанский");
            }
        }

        if(PlayerPrefs.HasKey("startGameTap")) {
            startGameOneTap = PlayerPrefs.GetInt("startGameTap");
            Debug.Log($"загрузил startGameTap = {startGameOneTap}");
            PlayerPrefs.DeleteKey("startGameTap");

            if(PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY")) {
                PlayerPrefs.DeleteKey("PlayerPositionX");
                PlayerPrefs.DeleteKey("PlayerPositionY");

            }
        }
        
        Debug.Log($"Значение пременной startGameOneTap = {startGameOneTap}");
        if(startGameOneTap == 0) {
            currentDamageSwordText = startSwordDamage;
            currentDamageSpearText = startSpearDamage;
            currentvalueSpearOnPlayerText = startvalueSpearDamage;
            currentCoin = StartCoin;

            if(PlayerPrefs.HasKey("startHistory")) {
                PlayerPrefs.DeleteKey("startHistory");
                Debug.Log("startHistory удалена");
            } else {
                Debug.Log("startHistory  не найдена в сохранениях");
            }
        } else {
            LoadGame();
        }
    }


    private void Update() {
        countDamageSwordText.text = currentDamageSwordText.ToString();
        CountDamageSpearText.text = currentDamageSpearText.ToString();
        countValueSpearOnPlayerText.text = currentvalueSpearOnPlayerText.ToString();
        UpdateCoinText();
    }


    private void OnEnable() {
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

    private void OnDisable() {
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

    public void buyInShopSpear() {
        if(currentvalueSpearOnPlayerText < 100 && currentCoin >= 10) {
            currentvalueSpearOnPlayerText += 5;
            currentCoin -= 10;
            source.PlayOneShot(buyMagTruyClip);
        } else {
            source.PlayOneShot(buyMagfalseClip);
        }
    }

    public void buyInShopSpearDamage() {
        if(currentDamageSpearText < 100 && currentCoin >= 50) {
            currentDamageSpearText += 10;
            currentCoin -= 50;
            source.PlayOneShot(buyMagTruyClip);
        } else {
            source.PlayOneShot(buyMagfalseClip);
        }
    }

    public void buyInShopSwordDamage() {
        if(currentDamageSwordText < 100 && currentCoin >= 30) {
            currentDamageSwordText += 10;
            currentCoin -= 30;
            source.PlayOneShot(buyMagTruyClip);
        } else {
            source.PlayOneShot(buyMagfalseClip);
        }
    }


    public void PlaySpearDamageClip() {
        source.PlayOneShot(spearDamageClip);
    }

    public int GetCurrentCoin() {
        return this.currentCoin;
    }

    public void SetCurrentCoin(int value) {
        currentCoin = value;
    }

    public void PlusValueCurrentCoin(int value) {
        currentCoin += value;
        source.PlayOneShot(coinClip);
    }

    private void UpdateCoinText() {
        countValueCoinText.text = currentCoin.ToString();
    }

    public int GetCurrentDamageSwordText() {
        return this.currentDamageSwordText;
    }

    public void SetCurrentDamageSwordText(int value) {
        this.currentDamageSwordText = value;
    }

    public int GetCurrentDamageSpearText() {
        return this.currentDamageSpearText;
    }

    public void SetCurrentDamageSpearText(int value) {
        this.currentDamageSpearText = value;
    }

    public int GetCurrentvalueSpearOnPlayerText() {
        return this.currentvalueSpearOnPlayerText;
    }

    public void SetCurrentvalueSpearOnPlayerText(int value) {
        this.currentvalueSpearOnPlayerText = value;
    }

    private void EndRound() {
        float xPosPlayer = resPositionAfterEndRoundX;
        float yPosPlayer = resPositionAfterEndRoundY;

        PlayerPrefs.SetFloat("PlayerPositionX", xPosPlayer);
        Debug.Log($"Сохранена позиция изрока по x = {xPosPlayer}");

        PlayerPrefs.SetFloat("PlayerPositionY", yPosPlayer);
        Debug.Log($"Сохранена позиция изрока по y = {yPosPlayer}");

        PlayerPrefs.Save();

        SaveGame();

        SceneManager.LoadScene(2);
    }

    private void StartSneilCnene() {
        float xPosPlayer = resPositionSneilStartX;
        float yPosPlayer = resPositionSneilStartY;

        PlayerPrefs.SetFloat("PlayerPositionX", xPosPlayer);
        Debug.Log($"Сохранена позиция изрока по x = {xPosPlayer}");

        PlayerPrefs.SetFloat("PlayerPositionY", yPosPlayer);
        Debug.Log($"Сохранена позиция изрока по y = {yPosPlayer}");

        PlayerPrefs.Save();

        SaveGame();
        SceneManager.LoadScene(3);
    }

    private void StartBossScene() {
        float xPosPlayer = resPositionBossStartX;
        float yPosPlayer = resPositionBossStartY;

        PlayerPrefs.SetFloat("PlayerPositionX", xPosPlayer);
        Debug.Log($"Сохранена позиция изрока по x = {xPosPlayer}");

        PlayerPrefs.SetFloat("PlayerPositionY", yPosPlayer);
        Debug.Log($"Сохранена позиция изрока по y = {yPosPlayer}");

        PlayerPrefs.Save();

        SaveGame();
        SceneManager.LoadScene(4);
    }


    private void SaveGame() {
        startGameOneTap = 1;

        PlayerPrefs.SetInt("DamageSword", currentDamageSwordText);
        Debug.Log($"Сохранил DamageSword = {currentDamageSwordText}");

        PlayerPrefs.SetInt("DamageSpear", currentDamageSpearText);
        Debug.Log($"Сохранил DamageSpear = {currentDamageSpearText}");

        PlayerPrefs.SetInt("valueSpear", currentvalueSpearOnPlayerText);
        Debug.Log($"Сохранил valueSpear = {currentvalueSpearOnPlayerText}");

        PlayerPrefs.SetInt("coin", currentCoin);
        Debug.Log($"Сохранил coin = {currentCoin}");

        PlayerPrefs.SetInt("startGameTap", startGameOneTap);
        Debug.Log($"Сохранил startGameTap = {startGameOneTap}");

        PlayerPrefs.Save();
    }

    private void SaveGameAndPlayer() {
        source.PlayOneShot(checkPointActivClip);
        float xPosPlayer = playerPosition.position.x;
        float yPosPlayer = playerPosition.position.y;

        PlayerPrefs.SetFloat("PlayerPositionX", xPosPlayer);
        Debug.Log($"Сохранена позиция изрока по x = {xPosPlayer}");

        PlayerPrefs.SetFloat("PlayerPositionY", yPosPlayer);
        Debug.Log($"Сохранена позиция изрока по y = {yPosPlayer}");

        PlayerPrefs.Save();

        SaveGame();

    }

    private void ResstartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResstartLevelAndStats() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LoadGame();
        // LoadGamePlayerPosition();
    }

    private void LoadGamePlayerPosition() {
        float xPosPlayer = playerPosition.position.x;
        float yPosPlayer = playerPosition.position.y;

        if(PlayerPrefs.HasKey("PlayerPositionX")) {
            xPosPlayer = PlayerPrefs.GetInt("PlayerPositionX");
            Debug.Log($"загрузил PlayerPositionX = {xPosPlayer}");
        }

        if(PlayerPrefs.HasKey("PlayerPositionY")) {
            yPosPlayer = PlayerPrefs.GetInt("PlayerPositionY");
            Debug.Log($"загрузил PlayerPositionY = {yPosPlayer}");
        }

        playerPosition.position = new Vector2(xPosPlayer, yPosPlayer);
    }

    private void LoadGame() {
        if(PlayerPrefs.HasKey("DamageSword")) {
            currentDamageSwordText = PlayerPrefs.GetInt("DamageSword");
            Debug.Log($"загрузил DamageSword = {currentDamageSwordText}");
        }

        if(PlayerPrefs.HasKey("DamageSpear")) {
            currentDamageSpearText = PlayerPrefs.GetInt("DamageSpear");
            Debug.Log($"загрузил DamageSpear = {currentDamageSpearText}");
        }

        if(PlayerPrefs.HasKey("valueSpear")) {
            currentvalueSpearOnPlayerText = PlayerPrefs.GetInt("valueSpear");
            Debug.Log($"загрузил valueSpear = {currentvalueSpearOnPlayerText}");
        }

        if(PlayerPrefs.HasKey("coin")) {
            currentCoin = PlayerPrefs.GetInt("coin");
            Debug.Log($"загрузил coin = {currentCoin}");
        }
    }

    private void CheckTapButtonsStartGameOneTap() {
        startGameOneTap = 0;
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("startHistory");
    }
}
