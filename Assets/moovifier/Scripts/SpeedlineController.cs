using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class SpeedlineController : MonoBehaviour
{
    [SerializeField] VisualEffect vfx;
    [SerializeField] int rate;
    CameraState state;
    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<CameraState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state.isMoving) {
            vfx.SetInt("rate", rate);
        }
        else {
            vfx.SetInt("rate", 0);
        }
    }
}
