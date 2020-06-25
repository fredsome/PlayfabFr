using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;

public class LeaderBoardScript : MonoBehaviour
{
    [SerializeField]
    GameObject Rank, Pseudo, Score;
    PlayFabManager playFabManager;
    // Start is called before the first frame update
   private void Awake()
    {
        playFabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
        playFabManager.LoadingMessage("Loading LeadearBoard");
       ReadLedearBoard();
    }

    // Update is called once per frame
   private void  ReadLedearBoard()
    {
        var request = new GetLeaderboardRequest() { StatisticName = "score", StartPosition = 0, MaxResultsCount = 10 };
        PlayFabClientAPI.GetLeaderboard(request,sucessLeaderBoard,failledLeaderBoard);
    }

    private void failledLeaderBoard(PlayFabError err)
    {
        playFabManager.LoadingMessage(err.ErrorMessage);
        playFabManager.LoadingHide();
    }

    private void sucessLeaderBoard(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard) {

            GameObject GoRank = Instantiate(Rank, this.transform);
            GoRank.GetComponent<Text>().text = (item.Position + 1).ToString();
            GameObject GoPseudo = Instantiate(Pseudo, this.transform);
            GoPseudo.GetComponent<Text>().text = item.DisplayName;
            GameObject GoScore = Instantiate(Score, this.transform);
            GoScore.GetComponent<Text>().text = (item.StatValue).ToString();
        }
        playFabManager.LoadingHide();
    }



    public void Home() {

        SceneManager.LoadScene("Menu");
    }
}
