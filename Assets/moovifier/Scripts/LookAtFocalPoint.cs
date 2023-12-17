using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFocalPoint : MonoBehaviour
{
    [SerializeField] Transform focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(focalPoint);
    }
}
