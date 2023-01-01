using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerClone")
        {
            Destroy(other.gameObject);
            PlayerController.instance.totalNumberOfPlayerClones -= 1;
            PlayerController.instance.FormatPlayerClones();
        }
        else if(other.tag == "Player")
        {
            if(PlayerController.instance.totalNumberOfPlayerClones == 0)
            {
                Debug.Log("You Lost!");
            }
        }
    }
}
