using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawnPoints;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject waveInfoObject;
    [SerializeField]
    private GameObject waveEndAnimationObject;
    [SerializeField]
    private Vector2 rangeSpawn = new Vector2(1, 1);

    private Text _waveInfoText;

    private bool _waveEnded = true;

    //[SerializeField]
    //private float spawnEvery = 15f;
   

   // private float spawnEveryTimer = 0f;
    private int _wave = 0;
    private List<GameObject> _enemies;

    private Animator _waveEndAnimationAnimator;

	// Use this for initialization
	void Start () {
        Audio.PlayBGM(Audio.BGM_GAME);
        _enemies = new List<GameObject>();
        waveInfoObject.SetActive(false);
        _waveInfoText = waveInfoObject.GetComponent<Text>();

        waveEndAnimationObject.SetActive(false);
        _waveEndAnimationAnimator = waveEndAnimationObject.GetComponent<Animator>();
        _waveEndAnimationAnimator.Stop();

        StartWave();
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (spawnEveryTimer < spawnEvery) {
            spawnEveryTimer += Time.deltaTime;
        } else {
            spawnEveryTimer = 0;
            SpawnEnemiesRandom();
        }
        */

        if (!_waveEnded) {
            if (_enemies.Count == 0)
            {
                EndWave();
                _waveEnded = true;
            }
        }
	}

    private void SpawnEnemiesRandom() {
        SpawnEnemy(Random.Range(rangeSpawn.x, rangeSpawn.y));
    }

    private void SpawnEnemy(float number) {

        for (int i = 0; i < number; i++) {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject spawnPoint = spawnPoints[spawnIndex];
            GameObject e = Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity) as GameObject;
            e.GetComponent<Enemy>().SetEnemyList(_enemies);
            _enemies.Add(e);
        }
    }

    private void StartWave() {

        rangeSpawn.x += _wave / 4;
        rangeSpawn.y += _wave / 2;

        waveInfoObject.SetActive(true);
        //Display stats example: 2 enemies incoming
        _waveInfoText.text = Constants.WAVE_START + " " + ++_wave;
        Constants.StoreCurrentWave(_wave);
        StartCoroutine(SpawnEnemiesWave(3f));
    }

    public void EndWave() {
        waveInfoObject.SetActive(true);
        _waveInfoText.text = Constants.WAVE_END + " " + _wave;
        //Display score then


        waveEndAnimationObject.SetActive(true);
        _waveEndAnimationAnimator.Play("Win");
        StartCoroutine(WrapUpEndWave(2f));

        Audio.PlaySND2(Audio.SND_CLAP);
    }

    private IEnumerator WrapUpEndWave(float secondsDelay) {
        yield return new WaitForSeconds(secondsDelay);
        _waveEndAnimationAnimator.Stop();
        Disable(waveInfoObject);
        Disable(waveEndAnimationObject);
        StartWave();
    }

    private IEnumerator SpawnEnemiesWave(float secondsDelay) {
        yield return new WaitForSeconds(secondsDelay);

        Disable(waveInfoObject);
        SpawnEnemiesRandom();

        _waveEnded = false;
    }

    private void Disable(GameObject gameObject) {
        gameObject.SetActive(false);
    }
}
