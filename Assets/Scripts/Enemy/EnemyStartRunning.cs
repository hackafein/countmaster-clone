using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStartRunning : MonoBehaviour
{
    private bool check = true;
    public bool run = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {

            if(Vector3.Distance(transform.position, Enemy.instance.runTarget) > 0)
            transform.position = Vector3.MoveTowards(transform.position, Enemy.instance.runTarget, Time.deltaTime / 3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (check) { 
        if (other.tag == "PlayerClone")
        {
                check = false;
                if(PlayerController.instance.totalNumberOfPlayerClones > 1)
                {
                    if (Enemy.instance.totalNumberEnemies > 1)
                    {

                        other.transform.parent.GetChild(2).GetComponent<PlayerStartRunning>().run = true;
                        transform.parent.GetChild(1).GetComponent<EnemyStartRunning>().run = true;
                    }
                    
                }
            


            Destroy(other.gameObject);
            Enemy.instance.totalNumberEnemies -= 1;
            PlayerController.instance.totalNumberOfPlayerClones -= 1;
            Destroy(this.gameObject);

        }
    }
        
    }

}
