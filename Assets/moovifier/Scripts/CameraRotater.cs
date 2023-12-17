using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    CameraState state;
    Quaternion homeRotation;
    AnimationCurve animationCurve;
    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<CameraState>();
        homeRotation = transform.rotation;
        animationCurve = GetComponent<MVAnimationCurve>().globalAnimationCurve;
    }

    // Update is called once per frame
    void Update()
    {
        if (state.isMoving && state.isRotated) {
            state.isRotated = false;
            state.isRotating = true;
            StartCoroutine(
                MovementHelper.SmoothQuaternion(transform.rotation, homeRotation, state.rotationSpeed, animationCurve,
                (Quaternion newRotation) =>
                {
                    transform.rotation = newRotation;
                },
                () =>
                {
                    state.isRotating = false;
                })
            );
        }

        // only allow rotation if zoomed
        if (state.isZoomed)
        {
            if (!state.isRotated && !state.isRotating)
            {
                state.isRotating = true;
                state.isRotated = true;
                Vector3 destinationRotation = new(0f, 0f, 0f);

                if (Input.GetKey(KeyCode.LeftArrow))
                    destinationRotation = transform.rotation.eulerAngles + new Vector3(0f, state.rotationMagnitude, 0f);
                if (Input.GetKey(KeyCode.RightArrow))
                    destinationRotation = transform.rotation.eulerAngles + new Vector3(0f, -state.rotationMagnitude, 0f);
                if (Input.GetKey(KeyCode.UpArrow))
                    destinationRotation = transform.rotation.eulerAngles + new Vector3(state.rotationMagnitude, 0f, 0f);
                if (Input.GetKey(KeyCode.DownArrow))
                    destinationRotation = transform.rotation.eulerAngles + new Vector3(-state.rotationMagnitude, 0f, 0f);

                StartCoroutine(
                    MovementHelper.SmoothQuaternion(homeRotation, Quaternion.Euler(destinationRotation), state.rotationSpeed, animationCurve,
                    (Quaternion newRotation) =>
                    {
                        transform.rotation = newRotation;
                    },
                    () =>
                    {
                        state.isRotating = false;
                    })
                );
            }

            // Return to position
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && !state.isRotating && state.isRotated)
            {
                state.isRotated = false;
                state.isRotating = true;
                StartCoroutine(
                    MovementHelper.SmoothQuaternion(transform.rotation, homeRotation, state.rotationSpeed, animationCurve,
                    (Quaternion newRotation) =>
                    {
                        transform.rotation = newRotation;
                    },
                    () =>
                    {
                        state.isRotating = false;
                    })
                );
            }
        }
    }
}
