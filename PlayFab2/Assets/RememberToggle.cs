using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RememberToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("Toggle") > 0)
        {

            GetComponent<Toggle>().isOn = true;
        }
        else {

            GetComponent<Toggle>().isOn = false;
        }
    }

    // Update is called once per frame
    public void SaveChange()
    {
        if (GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("Toggle", 1);


        }
        else { 
        PlayerPrefs.SetInt("Toggle", 0);
        }
    }
}
