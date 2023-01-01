using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject level;
private void OnTriggerEnter(Collider other)
    {
         if(other.tag == "Player")
        {
        PlayerController.instance.speed=0f;
        UIManager.instance.OnSuccessGame();
        }
}
}
