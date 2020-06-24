using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class NewsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var request = new GetTitleNewsRequest();
        PlayFabClientAPI.GetTitleNews(request, SuccessTitleNews, FailledTitleNews);


    }

    private void FailledTitleNews(PlayFabError err)
    {
        GetComponent<Text>().text = "Bienvenue.....";
    }

    private void SuccessTitleNews(GetTitleNewsResult result)
    {
        foreach (var item in result.News) {
            GetComponent<Text>().text = item.Title +":" + item.Body;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
