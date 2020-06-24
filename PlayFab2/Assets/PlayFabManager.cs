using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayFabManager : MonoBehaviour
{

    Text txtMessage;
    GameObject panel;
    // Start is called before the first frame update

    public string Player_ID;
    [SerializeField]
    int LoadingTimeOut;
    void Awake()
    {
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
