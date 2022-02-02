using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EarthManager : MonoBehaviour
{
    [Header("Earth Health")]
    static float Health = 10f;
    float currentHp;
    public Image hpImg;
    [Space]
    public Sprite[] earthStages;
    SpriteRenderer sprite;
    bool isChange = false;
    public GameObject hitObj;
    int costHeal = 10;
    public TextMeshProUGUI healCostTxt;
    public GameObject gameOverObj;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("currentHP", Health);
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime, Space.World);
        health();
        earthDestroy();
    }
    
    public void health() {
        hpImg.fillAmount = PlayerPrefs.GetFloat("currentHP") / Health;
    }

    public void gameOver() {
        if(PlayerPrefs.GetFloat("currentHP") <= 0) {
            if(PlayerPrefs.GetInt("highScore") < PlayerPrefs.GetInt("currentScore")) {
                PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("currentScore"));
                
                gameObject.GetComponentInParent<PlayfabManager>().sendLeaderboard(PlayerPrefs.GetInt("highScore"));
            }
            
            gameObject.GetComponentInParent<PlayfabManager>().sendLeaderboard(PlayerPrefs.GetInt("highScore"));
            gameOverObj.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public void earthDestroy() {
    if(isChange == true) {
        if(PlayerPrefs.GetFloat("currentHP") == 10) {
            sprite.sprite = earthStages[0];
        }
        else if(PlayerPrefs.GetFloat("currentHP") == 7) {
            sprite.sprite = earthStages[1];
        }
        else if(PlayerPrefs.GetFloat("currentHP") == 4) {
            sprite.sprite = earthStages[2];
        }
        else if(PlayerPrefs.GetFloat("currentHP") == 1) {
            sprite.sprite = earthStages[3];
        }
        else if(PlayerPrefs.GetFloat("currentHP") <= 0) {
            gameOver();
        }
        isChange = false;
    }
    }
    public void healing() {
            if(PlayerPrefs.GetInt("darkMatter") >= costHeal) {
                if(PlayerPrefs.GetFloat("currentHP") < 10) {
                    PlayerPrefs.SetFloat("currentHP", PlayerPrefs.GetFloat("currentHP") + 1);
                    PlayerPrefs.SetInt("darkMatter", PlayerPrefs.GetInt("darkMatter") - costHeal);
                    costHeal += 10;
                    gameObject.GetComponentInParent<upgradeSystem>().popupText("<color=green>+1 Health!</color>");
                    healCostTxt.text = costHeal.ToString();
                    isChange = true;
                }
            }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy") {
            Instantiate(hitObj, other.transform.position, Quaternion.identity);
            PlayerPrefs.SetFloat("currentHP", PlayerPrefs.GetFloat("currentHP") - 1);
            PlayerPrefs.SetInt("comboCounter", 0);
            Destroy(other.gameObject);
            print("Current Health is " + currentHp);
            isChange = true;
            gameOver();
        }
    }

}
