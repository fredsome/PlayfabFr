using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using System;

public class UIGameScript : MonoBehaviour
{

    [SerializeField] Text textCoins, textScore;
    PlayFabManager playfabManager;
    // Start is called before the first frame update
    private int coins;
    public int Coins {
        get { return coins; }
        set { coins = value;
            textCoins.text = coins.ToString();
        }
    }
    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score= value;
            textScore.text = score.ToString();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.anyKey) {

            Score++;
        }
    }
    private void Awake()
    {
        playfabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
        Score = playfabManager.Player_Score;
    }
    private void UpdatePlayFabManagerInfo() {
        playfabManager.Player_Score = Score;
    
    }
    public void Home()
    {
        //Update score
        playfabManager.LoadingMessage("Updating Data...");
        UpdatePlayFabManagerInfo();
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate> { 
                new StatisticUpdate { StatisticName = "score", Value = Score }
            
            }


        };
        PlayFabClientAPI.UpdatePlayerStatistics(request ,sucessUpdate,failledUpdate);
    
       
       
    }

    private void failledUpdate(PlayFabError err)
    {
        playfabManager.LoadingMessage(err.ErrorMessage);
        playfabManager.LoadingHide();

    }

    private void sucessUpdate(UpdatePlayerStatisticsResult result)
    {
        playfabManager.LoadingHide();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
