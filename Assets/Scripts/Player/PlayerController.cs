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

    public int numberOfPlayerClones;
    public int totalNumberOfPlayerClones;
    // Start is called before the first frame update
    public float speed = 10.0f;
    private Rigidbody rb;
    private float screenWidth;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        totalNumberOfPlayerClones = transform.childCount - 1;
        player = gameObject.transform;
        rb = GetComponent<Rigidbody>();

        // Calculate the width of the screen in world coordinates
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        screenWidth = widthOrtho * 2;
    }

    // Update is called once per frame
    void Update()
    {


        
        Vector3 position = transform.position;
        position.z += speed * Time.deltaTime;

        // Check if the player is touching the screen
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Set the target position for the player
            Vector3 targetPosition = transform.position;
            targetPosition.x += touch.deltaPosition.x * 500000f;

            // Move the player towards the target position
            rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime));;
        }


        // Limit the player's position to the edges of the screen
        float leftEdge = -screenWidth / 2;
        float rightEdge = screenWidth / 2;
        position.x = Mathf.Clamp(position.x, leftEdge, rightEdge);
        transform.position = position;

        if (fightStarted)
        {
            if(Enemy.instance.totalNumberEnemies == 0)
            {
                Debug.Log("You Won the Fight!");
                fightStarted = false;
            }
            else if(totalNumberOfPlayerClones == 0)
            {
                Debug.Log("You Lost!");
            }
        }
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
            gate.DOLocalMoveY(-0.5f, 0.57f).OnComplete(()=> {
                Destroy(gate.gameObject);

            });
        }
    }
}
