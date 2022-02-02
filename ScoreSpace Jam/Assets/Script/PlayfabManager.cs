using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayfabManager : MonoBehaviour
{
    string myID;
    public TextMeshProUGUI txtID;

    public TextMeshProUGUI[] IDboard;
    public TextMeshProUGUI[] scoreBoard;
    public TextMeshProUGUI[] rankBoard;
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Update() {
        if(SceneManager.GetActiveScene().name == "Main Menu") {
            if(Input.GetKeyDown(KeyCode.R)) {
                getLeaderboard();
            }
        }
    }

    void Login() {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result) {
        Debug.Log("Sucess login/create account");
        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null) {
        name = result.InfoResultPayload.PlayerProfile.PlayerId;
        
        if(name != null)
        myID = name;
        if(SceneManager.GetActiveScene().name == "Main Menu") {
        txtID.text = "ID: " + name;
        }
        }
    }

    void OnError(PlayFabError error) {
        Debug.Log("Error while logging in/creating account");
        Debug.Log(error.GenerateErrorReport());
    }

    public void sendLeaderboard(int Score) {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "ScoreJamScore",
                    Value = Score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Successfull leaderboard update");
    }

    public void getLeaderboard() {
        var request = new GetLeaderboardRequest{
            StatisticName = "ScoreJamScore",
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result){
        foreach (var item in result.Leaderboard) {
            if(myID == item.PlayFabId) {
            //green
            rankBoard[item.Position].text = "<color=green>" + (item.Position + 1).ToString() + "</color>";
            IDboard[item.Position].text = "<color=green>" + item.PlayFabId.ToString() + "</color>";
            scoreBoard[item.Position].text = "<color=green>" + item.StatValue.ToString() + "</color>";
            }
            else {
            IDboard[item.Position].text = item.PlayFabId.ToString();
            scoreBoard[item.Position].text = item.StatValue.ToString();
            }
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }


}
