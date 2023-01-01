using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartRunning : MonoBehaviour
{

    public bool run = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (run)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.runTarget) > 0)
                transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.runTarget, Time.deltaTime / 3);
        }
    }

}
