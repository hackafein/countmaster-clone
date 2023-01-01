using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSwipeDirection : MonoBehaviour
{
    [SerializeField] float swiperStopTolerance;
    [SerializeField] float endPointSpeed;
    Vector3 startPoint;
    Vector3 endPoint;
    float inputSpeed;
    Camera cam;
    Rigidbody rb;
    Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        endPoint = Vector3.zero;
        cam = Camera.main;
    }

    private void Update()
    {
        velocity = rb.velocity;

        if (!PlayerController.instance.fightStarted)
        {
            velocity.x = CalculateDirection().x * 20;
        }

        else
        {
            velocity.x = 0;
        }

        rb.velocity = velocity;
    }

    public Vector3 CalculateDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            endPoint = startPoint;
        }

        if (Input.GetMouseButton(0))
        {
            startPoint = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            inputSpeed = GetSwipeSpeed(startPoint.x, endPoint.x);
            endPoint = Vector3.Lerp(endPoint, startPoint, endPointSpeed * Time.deltaTime);
            return new Vector3(inputSpeed, 0, 0);
        }

        return Vector3.zero;
    }
    float GetSwipeSpeed(float startPoint, float endPoint)
    {
        float inputSpeed = startPoint - endPoint;
        if (Mathf.Abs(inputSpeed) > swiperStopTolerance)
        {
            return inputSpeed;
        }
        else
        {
            return 0;
        }
    }
}
