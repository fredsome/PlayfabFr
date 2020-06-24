using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameScript : MonoBehaviour
{

    [SerializeField] Text textCoins, textScore;
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

    public void Home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

    }
}
