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
    public void RegisterPlayer()
    {
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
        Debug.Log(err.ErrorMessage);
    }

    private void Success(RegisterPlayFabUserResult success)
    {
        Debug.Log("Enregistrement Reussit");
        Debug.Log("ID :"+ success.PlayFabId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
