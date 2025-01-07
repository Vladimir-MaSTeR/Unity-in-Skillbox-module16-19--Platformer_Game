using UnityEngine;
public class RessEnemiInTime : MonoBehaviour {
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _ressPointPosition;
    [SerializeField] private float _ressTime = 20;

    private float currentTime = 0;
    private bool enemyDeath = false;


    private void OnEnable() {
        CheckEndAnim.enemyDeath += CheckDeathEnemy;
    }

    private void OnDisable() {
        CheckEndAnim.enemyDeath -= CheckDeathEnemy;

    }

    // Start is called before the first frame update
    void Start() {
        currentTime = _ressTime;
        enemyDeath = false;
    }

    // Update is called once per frame
    void Update() {
        if(enemyDeath == true) {
            currentTime -= Time.deltaTime;
        }

        if(currentTime <= 0 && enemyDeath == true) {
            Instantiate(_enemy, _ressPointPosition.position, Quaternion.identity);
            enemyDeath = false;
            currentTime = _ressTime;
        }
    }


    private void CheckDeathEnemy() {
        enemyDeath = !enemyDeath;
    }
}
