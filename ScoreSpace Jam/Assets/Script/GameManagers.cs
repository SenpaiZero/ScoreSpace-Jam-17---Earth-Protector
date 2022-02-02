using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagers : MonoBehaviour
{
    [Header("Spawn Values")]
    public GameObject[] spawnPoints;
    public GameObject[] asteroids;
    float spawnCounter = 1;
    int enemyKilled;
    int comboCounter;
    int darkMatterCounter;
    int currentScore;
    bool isSpawn = true;
    bool isDecrease = true;

    [Header("UI")]
    public TextMeshProUGUI killedTxt;
    public TextMeshProUGUI comboTxt;
    public TextMeshProUGUI darkMatterTxt;
    public TextMeshProUGUI scoreTxt;
    
    
    // Start is called before the first frame update
    void Start()
    {
            PlayerPrefs.SetInt("currentKilled", 0);
            PlayerPrefs.SetInt("comboCounter", 0);
            PlayerPrefs.SetInt("darkMatter", 0);
            PlayerPrefs.SetInt("currentScore", 0);
            PlayerPrefs.SetFloat("fireRate", 0.7f);
            PlayerPrefs.SetFloat("bulletSpeed", 3f);
            PlayerPrefs.SetInt("shieldCount", 1);
            PlayerPrefs.SetFloat("enemySpeed", 1.5f);
            PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

        comboCounter = PlayerPrefs.GetInt("comboCounter");
        enemyKilled = PlayerPrefs.GetInt("currentKilled");
        darkMatterCounter = PlayerPrefs.GetInt("darkMatter");
        currentScore = PlayerPrefs.GetInt("currentScore");
        killedTxt.text = "KILLS: " + enemyKilled.ToString();
        comboTxt.text = "MULTIPLYIER: " + comboCounter.ToString();
        darkMatterTxt.text = darkMatterCounter.ToString() + " DARK MATTER";
        scoreTxt.text = "SCORE: " + currentScore.ToString();

        if(isSpawn == true) {
            StartCoroutine(spawnDelay());
            isSpawn = false;
        }

        if(isDecrease == true) {
            StartCoroutine(increaseSpawn());
            isDecrease = false;
        }
        
    }

    public void spawning() {
    }

    IEnumerator spawnDelay() {
        Debug.Log("Spawning");
        int rand = Random.Range(0, spawnPoints.Length);
        int rand2 = Random.Range(0, asteroids.Length);
        Instantiate(asteroids[rand2],spawnPoints[rand].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnCounter);
        isSpawn = true;
    }

    IEnumerator increaseSpawn() {
        if(spawnCounter > 0.3) {
            spawnCounter -= 0.01f;
            print("spawn: " + spawnCounter);
        }
        
        if(spawnCounter == 0.8f) {
            PlayerPrefs.SetFloat("enemySpeed", PlayerPrefs.GetFloat("enemySpeed") + 0.5f);
        }
        if(spawnCounter == 0.6f) {
            PlayerPrefs.SetFloat("enemySpeed", PlayerPrefs.GetFloat("enemySpeed") + 0.5f);
        }
        if(spawnCounter == 0.4f) {
            PlayerPrefs.SetFloat("enemySpeed", PlayerPrefs.GetFloat("enemySpeed") + 0.5f);
        }
        if(spawnCounter == 0.1f) {
            PlayerPrefs.SetFloat("enemySpeed", PlayerPrefs.GetFloat("enemySpeed") + 0.5f);
        }

        yield return new WaitForSeconds(1.5f);
        isDecrease = true;
    }


    

}
