using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayFabManager : MonoBehaviour
{
   public static PlayFabManager instance = null;
    Text txtMessage;
    GameObject panel;
    // Start is called before the first frame update

    public string Player_ID;
    [SerializeField]
    int LoadingTimeOut = 3;
    void Awake()
    {
        ////////////////////////////////////////////////////////////////////////
        ////Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        /////////////////////////////////////////////////////////////////////
        panel = transform.Find("CanvasLoading").Find("Panel").gameObject;
        txtMessage = panel.GetComponentInChildren<Text>();
    }

    
   public void Loadingshow()
    {
        if (!panel.activeInHierarchy) { panel.SetActive(true); }


    }
    public void LoadingHide() {
        StartCoroutine(Timer());
    
 
    }
    IEnumerator Timer() {
        yield return new WaitForSeconds(LoadingTimeOut);
        panel.SetActive(false);
    
    }
    public void LoadingMessage(string msg) {
        Loadingshow();
        txtMessage.text = msg;


    }


}
