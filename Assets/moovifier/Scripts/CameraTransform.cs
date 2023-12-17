using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    Camera cam;
    Vector3 homePos;
    CameraState state;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        homePos = transform.position;
        state = GetComponent<CameraState>();
    }

    Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;

        mousePos.z = 15f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        // If click, set transform position and stuff.
        if (Input.GetMouseButtonDown(0) && !state.isMoving)
        {
            if (state.isZoomed)
            {
                state.isZoomed = false;
                state.isMoving = true;
                StartCoroutine(MovementHelper.SmoothVector3(transform.position, homePos, state.moveSpeed,
                (Vector3 newPos) => {
                    transform.position = newPos;
                },
                () => state.isMoving = false));
            }
            else
            {
                state.isMoving = true;
                state.isZoomed = true;
                StartCoroutine(MovementHelper.SmoothVector3(transform.position, mousePos, state.moveSpeed, (Vector3 newPos) => {
                    transform.position = newPos;
                },
                () => state.isMoving = false));
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mousePos, 0.5f);
    }
}
