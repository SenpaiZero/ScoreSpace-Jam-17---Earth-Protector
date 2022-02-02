using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;

    private void Start() {
        score.text = "SCORE: " + PlayerPrefs.GetInt("currentScore").ToString();
        highScore.text ="HIGHSCORE: " + PlayerPrefs.GetInt("highScore").ToString();
    }
    public void retry() {
        StartCoroutine(RetryDelay());
    }

    public void mainMenu() {
        StartCoroutine(MainMenuDelay());
    }

    
    IEnumerator RetryDelay() {
        GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionScript>().transitionSceneExit();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("BattleScene");
        Debug.Log("asd");
    }

    IEnumerator MainMenuDelay() {
        GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionScript>().transitionSceneExit();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Main Menu");
    }
}
