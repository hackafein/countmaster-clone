using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartRunning : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (PlayerController.instance.run)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.runTarget) > 0.02f)
                transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.runTarget, Time.deltaTime);
        }
    }

}
