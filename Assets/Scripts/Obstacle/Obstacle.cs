using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerClone")
        {
            Debug.Log("ÇARPTI YOK ETTIM");
            Destroy(other.gameObject);
            PlayerController.instance.totalNumberOfPlayerClones -= 1;
            Debug.Log("TOTAL ADAM "+PlayerController.instance.totalNumberOfPlayerClones );
            PlayerController.instance.FormatPlayerClones();
        }
        else if(other.tag == "Player")
        {
            if(PlayerController.instance.totalNumberOfPlayerClones == 0)
            {
                PlayerController.instance.speed=0f;
                Debug.Log("You Lost!");
                UIManager.instance.OnFailedGame();
            }
        }
    }
    private void OnTriggerStay(Collider other){
       if(other.tag == "Player")
        {
            if(PlayerController.instance.totalNumberOfPlayerClones == 0)
            {
                PlayerController.instance.speed=0f;
                Debug.Log("You Lost!");
                UIManager.instance.OnFailedGame();
            }
        }
    }
}
