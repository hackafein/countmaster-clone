using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Transform player;
    private float DistanceFactor = 0.02f;
    private float Radius = 0.5f;
    public GameObject playerClone;
    public bool fightStarted = false;
    public Vector3 runTarget;
    private Rigidbody playerRigidbody;

    public int numberOfPlayerClones;
    public int totalNumberOfPlayerClones;

    public float speed = 0.5f;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        totalNumberOfPlayerClones = transform.childCount - 1;
        player = gameObject.transform;

    }

    void Update()
    {
        if (fightStarted)
        {
            speed = 0;
            if (Enemy.instance.totalNumberEnemies == 0)
            {
                Debug.Log("You Won the Fight!");
                fightStarted = false;
                speed = 0.6f;
            }

            else if (totalNumberOfPlayerClones == 0)
            {
                Debug.Log("You Lost!");
            }
        }

        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y , speed);
    }

    public void FormatPlayerClones()
    {
        Debug.Log("5");
        for (int i = 1; i < player.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

            var NewPos = new Vector3(x, 0, z);

            player.transform.GetChild(i).DOLocalMove(NewPos, 0.5f).SetEase(Ease.OutBack);
        }
    }

    public void MakePlayerClone(int number)
    {
        Debug.Log("4");
        for (int i = totalNumberOfPlayerClones; i < number; i++)
        {
            Instantiate(playerClone, transform.position, Quaternion.identity, transform);
        }

        //numberOfPlayerClones = transform.childCount - 1;
        totalNumberOfPlayerClones = transform.childCount - 1;

        //CounterTxt.text = numberOfStickmans.ToString();
        FormatPlayerClones();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Award")
        {
     
            other.GetComponent<BoxCollider>().enabled = false;
            Award award = other.GetComponent<Award>();
            other.GetComponent<Award>().DetectAward();
      

            Transform gate = other.transform.parent;
            gate.DOLocalMoveY(-0.5f, 0.57f).OnComplete(() => {
                Destroy(gate.gameObject);

            });
        }
    }
}
