using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 30f;
    public Transform cam;

    Vector2 prevPos = Vector2.zero;
    float prevDistance = 0f;
    public float limitedY;
    public float limitedZ;
    public float limitedX;

    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnDrag()
    {
        int touchCount = Input.touchCount;

        if (touchCount == 1)
        {
            if (prevPos == Vector2.zero)
            {
                prevPos = Input.GetTouch(0).position;
                return;
            }
            Vector2 dir = (Input.GetTouch(0).position - prevPos).normalized;
            Vector3 vec = new Vector3(dir.y, 0, -dir.x);


            cam.position -= vec * moveSpeed * Time.deltaTime;
       
            prevPos = Input.GetTouch(0).position;
        }
        else if (touchCount == 2) {
            if (prevDistance == 0)
            {
                prevDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                return;
            }
            float curDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            float move = prevDistance - curDistance;

            Vector3 pos = cam.position;

            if (move < 0) pos.y -= moveSpeed * Time.deltaTime;
            else if (move > 0) pos.y += moveSpeed * Time.deltaTime;

            if (pos.y < 60 && pos.y > 35)
            {
                cam.position = pos;
                prevDistance = curDistance;
            }
        }
    }
    public void ExitDrag() {
        prevPos = Vector2.zero;
        prevDistance = 0f;
    }
}
