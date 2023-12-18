using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFocalPoint : MonoBehaviour
{
    [SerializeField] Transform focalPoint;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(focalPoint);
    }
}
