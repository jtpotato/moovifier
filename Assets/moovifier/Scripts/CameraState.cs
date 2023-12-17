using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState : MonoBehaviour
{
    public float rotationSpeed = 15f;
    public float moveSpeed = 1f;
    public float rotationMagnitude = 30f;
    bool _isZoomed = false;

    public bool isZoomed {
        get {
            return _isZoomed;
        }
        set {
            _isZoomed = value;
        }
    }

    bool _isMoving = false;
    public bool isMoving {
        get {
            return _isMoving;
        }
        set {
            _isMoving = value;
        }
    }

    bool _isRotating = false;
    public bool isRotating {
        get {
            return _isRotating;
        }
        set {
            _isRotating = value;
        }
    }

    bool _isRotated = false;
    public bool isRotated {
        get {
            return _isRotated;
        }
        set {
            _isRotated = value;
        }
    }
}
