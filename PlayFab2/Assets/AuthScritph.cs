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
    }

    private void Loginfailled(PlayFabError err)
    {
        playfabManager.LoadingMessage(err.ErrorMessage);
        playfabManager.LoadingHide();
    }
}
