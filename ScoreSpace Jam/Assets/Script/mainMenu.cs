using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject tutorialObj;
    public GameObject leaderboardObj;
    public GameObject filler;
    public GameObject exit;
    bool isTut = false;
    bool isLead = false;
    public AudioSource clickSfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTut == true) {
            if(Input.GetKeyDown(KeyCode.B)) {
            clickSfx.Play();
                isTut = false;
                isLead = false;
                filler.SetActive(true);
                tutorialObj.SetActive(false);
                exit.SetActive(false);
            }
        }
        if(isLead == true) {
            if(Input.GetKeyDown(KeyCode.B)) {
            clickSfx.Play();
                isTut = false;
                isLead = false;
                filler.SetActive(true);
                tutorialObj.SetActive(false);
                leaderboardObj.SetActive(false);
                exit.SetActive(false);
            }
        }
        
    }

    public void openTut() {
        clickSfx.Play();
        isTut = true;
        isLead = false;
        filler.SetActive(false);
        tutorialObj.SetActive(true);
        leaderboardObj.SetActive(false);
        exit.SetActive(true);
    }

    public void openLead() {
        clickSfx.Play();
        isLead = true;
        isTut = false;
        filler.SetActive(false);
        tutorialObj.SetActive(false);
        leaderboardObj.SetActive(true);
        exit.SetActive(true);
    }
    public void fight() {
        clickSfx.Play();
        StartCoroutine(fightDelay());
    }

    IEnumerator fightDelay() {
        GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionScript>().transitionSceneExit();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("BattleScene");
    }
}
