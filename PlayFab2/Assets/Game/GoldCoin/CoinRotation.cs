using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour {
    [SerializeField]
    float speed=300f;
    [SerializeField] UIGameScript uiGameSript;


    void Update () {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
	}


    private void OnTriggerStay(Collider other)
    {
        uiGameSript.Coins += 1;
    }

   

}
