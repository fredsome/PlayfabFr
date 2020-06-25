using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum TypePlayer { orange, vert, rouge}
public class CarControleur : MonoBehaviour
{

    [SerializeField] float normalSpeed = 4f, currentSpeed;
    [SerializeField] bool canJump = false;
    [SerializeField] Texture orangeTex, verText, rougeTex;
    // Start is called before the first frame update
    public TypePlayer myTypePlayer;
    void Awake()
    {
        // player Manaher
        switch (myTypePlayer) {

            case TypePlayer.orange:
                currentSpeed = normalSpeed;
                canJump = false;
                GetComponent<MeshRenderer>().material.mainTexture = orangeTex;
                break;
            case TypePlayer.vert:
                currentSpeed = normalSpeed*2;
                canJump = false;
                GetComponent<MeshRenderer>().material.mainTexture = verText;
                break;
            case TypePlayer.rouge:
                currentSpeed = normalSpeed*2;
                canJump = true;
                GetComponent<MeshRenderer>().material.mainTexture = rougeTex;
                break;
        }



    }

    // Update is called once per frame
   private void Update()
    {
        transform.Translate(Vector3.forward *Time.deltaTime * currentSpeed * Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up * Time.deltaTime * normalSpeed * 30 * Input.GetAxis("Horizontal"));
    }

  



}
