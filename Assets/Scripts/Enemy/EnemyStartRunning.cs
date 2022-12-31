using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStartRunning : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.instance.run)
        {
            if(Vector3.Distance(transform.position, Enemy.instance.runTarget) > 0.02f)
            transform.position = Vector3.MoveTowards(transform.position, Enemy.instance.runTarget, Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerClone")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Enemy.instance.totalNumberEnemies -= 1;
        }
    }

}
