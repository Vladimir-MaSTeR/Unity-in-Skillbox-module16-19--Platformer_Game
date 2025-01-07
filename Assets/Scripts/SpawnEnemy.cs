using UnityEngine;
public class SpawnEnemy : MonoBehaviour {
    [SerializeField] private Transform[] respawnPoint;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject objectVisible;
    [SerializeField] private int valueCreateEnemyOneWave;
    [SerializeField] private int valueCreateEnemyTwoWave;


    private int currentValueEnemyOneWave = 0;
    private int currentValueEnemyTwoWave = 0;
    private int numberWave = 0;
    private int numberWaveRandom = 1;


    // Start is called before the first frame update
    void Start() {
        currentValueEnemyOneWave = 0;
        currentValueEnemyTwoWave = 0;
        numberWave = 0;
        numberWaveRandom = 1;
    }


    private void OnEnable() {
        Enemy.onDeathEnemy += RespawnEnemy;
        EnemyTrigerCont.onStartEnemyTriger += PlusNumberWave;
    }

    private void OnDisable() {
        Enemy.onDeathEnemy -= RespawnEnemy;
        EnemyTrigerCont.onStartEnemyTriger -= PlusNumberWave;

    }

    public void RespawnEnemy() {
        if(numberWave == 0) {
            if(currentValueEnemyOneWave < valueCreateEnemyOneWave) {
                Instantiate(enemy, respawnPoint[numberWave].position, Quaternion.identity);
                currentValueEnemyOneWave++;
            }
        } else {
            //Debug.Log($"респавн врага на позиции = {numberWaveRandom}");
            if(currentValueEnemyTwoWave < valueCreateEnemyTwoWave) {

                numberWaveRandom = WaveRandom(numberWaveRandom);
                Debug.Log($"респавн врага на позиции = {numberWaveRandom}");

                Instantiate(enemy, respawnPoint[numberWaveRandom].position, Quaternion.identity);
                currentValueEnemyTwoWave++;
            }

            if(currentValueEnemyTwoWave >= valueCreateEnemyTwoWave) {
                objectVisible.SetActive(false);
            }
        }
    }

    private void PlusNumberWave() {
        numberWave++;
        Debug.Log($"значение переменной numberWave = {numberWave}");

    }

    private int WaveRandom(int value) {
        int currentValue = 1;

        if(value == 1) {
            currentValue = 2;
        } else {
            currentValue = 1;
        }

        return currentValue;
    }
}
