using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class AuthScritph : MonoBehaviour
{

    [SerializeField]
    // Start is called before the first frame update

    InputField ifEmail, ifPassword, ifDisplayName;
  
    [SerializeField]
    PlayFabManager playfabManager;
    public void RegisterPlayer()
    {
        playfabManager.LoadingMessage("Connection en cour....");
        var request = new RegisterPlayFabUserRequest() {
            Email = ifEmail.text,
            Password =ifPassword.text,
            DisplayName =ifDisplayName.text,
            Username = ifDisplayName.text
       
        };
        PlayFab.PlayFabClientAPI.RegisterPlayFabUser(request,Success,Failed);

        
    }

    private void Failed(PlayFabError err)
    {
        playfabManager.LoadingMessage(err.ErrorMessage);
        playfabManager.LoadingHide();
    }

    private void Success(RegisterPlayFabUserResult success)
    {

        playfabManager.LoadingMessage("Initialize Stgatistics...");
        InitStat();
    }

    private void InitStat() {
        var request = new UpdatePlayerStatisticsRequest() { 
        Statistics = new List<StatisticUpdate> { new StatisticUpdate {StatisticName="score", Value =0} }
        
        
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,InitStatSuccess,InitStatFailled);
    
    }

    private void InitStatFailled(PlayFabError err)
    {
        playfabManager.LoadingMessage(err.ErrorMessage);
        playfabManager.LoadingHide();
    }

    private void InitStatSuccess(UpdatePlayerStatisticsResult result)
    {
        playfabManager.LoadingMessage("Register Succefull");
        playfabManager.LoadingHide();
    }

    // Update is called once per frame
    public void LoginPlayer()
    {
        playfabManager.LoadingMessage("Connecting server ...");
        var request = new LoginWithEmailAddressRequest()
        {
            Password = ifPassword.text,
            Email = ifEmail.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, Loginfailled);



    }

    private void LoginSuccess(LoginResult succes)
    {
        playfabManager.LoadingMessage("Login SuccessFull");
        playfabManager.Player_ID = succes.PlayFabId;
        playfabManager.LoadingHide();
    
        //Get Display
        GetPlayerName();

    }

    private void Loginfailled(PlayFabError err)
    {
        playfabManager.LoadingMessage(err.ErrorMessage);
        playfabManager.LoadingHide();
    }

    void GetPlayerName() {
        playfabManager.LoadingMessage("Login Player DisplayName");
        var request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request,InfoSucess,InfosFailled);
    
    
    }

    private void InfosFailled(PlayFabError err)
    {
        playfabManager.LoadingMessage(err.ErrorMessage);
        playfabManager.LoadingHide();
    }

    private void InfoSucess(GetAccountInfoResult result)
    {
       playfabManager.DisplayName= result.AccountInfo.Username;
        //read statistics
        readStatScore();


    }
    private void readStatScore() {
        playfabManager.LoadingMessage("Login Player Statistics");
        var request = new GetPlayerStatisticsRequest();
        PlayFabClientAPI.GetPlayerStatistics(request, suceesStats,failledstats);
    }

    private void failledstats(PlayFabError err)
    {
        playfabManager.LoadingMessage(err.ErrorMessage);
        playfabManager.LoadingHide();
    }

    private void suceesStats(GetPlayerStatisticsResult result)
    {
        playfabManager.Player_Score = result.Statistics[0].Value;
        playfabManager.LoadingMessage("Login stats successful");
        playfabManager.LoadingHide();
        getBalance();
    }


    void getBalance(){
        var request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request,Inventorysuccess,InventoryFailled);
    
    }

    private void InventoryFailled(PlayFabError err)
    {
        playfabManager.LoadingMessage(err.ErrorMessage);
        playfabManager.LoadingHide();
    }

    private void Inventorysuccess(GetUserInventoryResult result)
    {
        foreach (var item in result.VirtualCurrency) {
            if (item.Key == "CO") {
                playfabManager.Player_Coins = item.Value;
            
            }
        
        }
        playfabManager.LoadingMessage("Loading successfull");
        playfabManager.LoadingHide();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
