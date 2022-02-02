using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class upgradeSystem : MonoBehaviour
{
    public GameObject[] shields;
    public TextMeshProUGUI shieldCostTxt;
    public TextMeshProUGUI fireRateCostTxt;
    public TextMeshProUGUI bulletSpeedCostTxt;
    int costShield = 15;
    int costFireRate = 5;
    int costbulletSpeed = 5;
    int darkMatterCount;
    public GameObject popupTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        darkMatterCount = PlayerPrefs.GetInt("darkMatter");
        //Upgrade fire rate
        //Cost 5
        if(Input.GetKeyDown(KeyCode.Q)) {
            if(darkMatterCount >= costFireRate) {
                if(PlayerPrefs.GetFloat("fireRate") > 0.2f) {
                    PlayerPrefs.SetFloat("fireRate", PlayerPrefs.GetFloat("fireRate") - 0.1f);
                    PlayerPrefs.SetInt("darkMatter", PlayerPrefs.GetInt("darkMatter") - costFireRate);
                    costFireRate += 5;
                    popupText("<color=orange>You Upgraded Fire Rate!</color>");
                    if(PlayerPrefs.GetFloat("fireRate") >= 0.3f) {
                        fireRateCostTxt.text = costFireRate.ToString();
                    }
                    else {
                        fireRateCostTxt.text = "MAXED";
                    }
                }
            }
        }
        //add shield up to 4
        //Cost 15
        if(Input.GetKeyDown(KeyCode.W)) {
            if(darkMatterCount >= costShield) {
                if(PlayerPrefs.GetInt("shieldCount") < 4) {
                    PlayerPrefs.SetInt("shieldCount", PlayerPrefs.GetInt("shieldCount") + 1);
                    PlayerPrefs.SetInt("darkMatter", PlayerPrefs.GetInt("darkMatter") - costShield);
                    costShield = (costShield * 4) + 5;
                    popupText("<color=blue>You Upgraded Shield Count!</color>");
                    if(PlayerPrefs.GetInt("shieldCount") <= 3) {
                        shieldCostTxt.text = costShield.ToString();
                    }
                    else {
                        shieldCostTxt.text = "MAXED";
                    }
                    shieldUp();
                }
            }
        }
        //increase bullet speed
        //Cost 5
        if(Input.GetKeyDown(KeyCode.E)) {
            if(darkMatterCount >= costbulletSpeed) {
                if(PlayerPrefs.GetFloat("bulletSpeed") < 7) {
                    PlayerPrefs.SetFloat("bulletSpeed", PlayerPrefs.GetFloat("bulletSpeed") + 1);
                    PlayerPrefs.SetInt("darkMatter", PlayerPrefs.GetInt("darkMatter") - costbulletSpeed);
                    costbulletSpeed += 5;
                    popupText("<color=red>You Upgraded Bullet Speed!</color>");
                    if(PlayerPrefs.GetFloat("bulletSpeed") <= 6) {
                        bulletSpeedCostTxt.text = costbulletSpeed.ToString();
                    }
                    else {
                        bulletSpeedCostTxt.text = "MAXED";
                    }
                }
            }
        }
        //Heal 1
        //Cost 15
        if(Input.GetKeyDown(KeyCode.R)) {
            gameObject.GetComponentInChildren<EarthManager>().healing();
        }

        // if(Input.GetKeyDown(KeyCode.Space)) {
        //     PlayerPrefs.SetInt("darkMatter", PlayerPrefs.GetInt("darkMatter") + 115);
        // }
        
    }
    
    void shieldUp() {
        if(PlayerPrefs.GetInt("shieldCount") == 2) {
            shields[1].SetActive(true);
        }
        if(PlayerPrefs.GetInt("shieldCount") == 3) {
            shields[2].SetActive(true);
        }
        if(PlayerPrefs.GetInt("shieldCount") == 4) {
            shields[3].SetActive(true);
        }
    }

    public void popupText(string txt) {
        GameObject clone = Instantiate(popupTxt, new Vector3(0,0,0), Quaternion.identity);
        clone.GetComponentInChildren<TextMeshProUGUI>().text = txt;
        Destroy(clone, 5f);
    }
}
