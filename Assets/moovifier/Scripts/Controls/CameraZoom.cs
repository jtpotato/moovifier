using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Camera cam;
    Vector3 homePos;
    CameraState state;
    Vector3 mousePos;
    AnimationCurve animationCurve;
    [SerializeField] float zoomZCoordinate;
    [SerializeField] AppState appState;
    SoundPlayer soundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        homePos = transform.position;
        state = GetComponent<CameraState>();
        animationCurve = GetComponent<MVAnimationCurve>().globalAnimationCurve;
        soundPlayer = GetComponent<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (appState.lockMovement) return;
        if (state.isMoving) return;

        mousePos = Input.mousePosition;

        mousePos.z = state.isZoomed ? 5f : 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        // If click, set transform position and stuff.
        if (Input.GetMouseButtonDown(0) && !state.isMoving)
        {
            float speed = state.zoomSpeed;

            if (state.isZoomed) speed /= 2.5f;
            if (!state.isZoomed) soundPlayer.SoundEvent();

            state.isMoving = true;
            state.isZoomed = true;
            Vector3 targetPos = new Vector3(mousePos.x, mousePos.y, zoomZCoordinate);

            StartCoroutine(MovementHelper.SmoothVector3(transform.position, targetPos, speed, animationCurve,
            (Vector3 newPos) =>
            {
                transform.position = newPos;
            },
            () => state.isMoving = false));
        }

        // Return to home
        if (Input.GetKey(KeyCode.Escape) && state.isZoomed || Input.GetKeyDown(KeyCode.O))
        {
            state.isZoomed = false;
            state.isMoving = true;

            soundPlayer.SoundEvent();

            StartCoroutine(MovementHelper.SmoothVector3(transform.position, homePos, state.zoomSpeed, animationCurve,
            (Vector3 newPos) =>
            {
                transform.position = newPos;
            },
            () => state.isMoving = false));
        }
    }

    void OnDrawGizmos()
    {
        Vector3 targetPos = new Vector3(mousePos.x, mousePos.y, zoomZCoordinate);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPos, 0.5f);
    }
}
