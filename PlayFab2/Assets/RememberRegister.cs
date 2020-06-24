using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RememberRegister : MonoBehaviour
{
    // Start is called before the first frame update
    Toggle rememberToggle;
    void Awake()
    {
        rememberToggle = GameObject.Find("Toggle").GetComponent<Toggle>();
        if (rememberToggle.isOn) {
            //On charge la valeur sovegarder au chargement
            gameObject.GetComponent<InputField>().text = PlayerPrefs.GetString(gameObject.name);
        }
    }

    // Update is called once per frame
   public void SaveChange ()
    {
        if (rememberToggle.isOn) {
            //On cree une clée
            PlayerPrefs.SetString(gameObject.name,transform.Find("Text").GetComponent<Text>().text);
        }
    }
}
