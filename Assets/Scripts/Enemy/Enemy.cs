using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public GameObject enemyClone;
    public Vector3 runTarget;
    private int numberOfEnemyClones;
    [SerializeField] private int cloneAmount;
    private float DistanceFactor = 0.02f;
    private float Radius = 0.5f;
    private bool checkTrigger = true;
    public bool run = false;

    public int totalNumberEnemies;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeEnemyClone(cloneAmount);
        totalNumberEnemies = cloneAmount + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FormatEnemyClones()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

            var NewPos = new Vector3(x, 0, z);

            transform.transform.GetChild(i).DOLocalMove(NewPos, 0.5f).SetEase(Ease.OutBack);
        }
    }
    public void MakeEnemyClone(int number)
    {
        for (int i = numberOfEnemyClones; i < number; i++)
        {
            Instantiate(enemyClone, transform.position, Quaternion.identity, transform);
        }

        numberOfEnemyClones = transform.childCount - 1;
        FormatEnemyClones();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (checkTrigger)
        {
            if (other.tag == "PlayerClone" || other.tag == "Player")
            {
                PlayerController.instance.runTarget = other.transform.position;
                runTarget = other.transform.position;
                checkTrigger = false;
                run = true;
                PlayerController.instance.run = true;
            }
        }
    }
}
