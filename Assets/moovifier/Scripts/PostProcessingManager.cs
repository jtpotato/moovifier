using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    private DepthOfField depthOfField;
    private Volume volume;
    [SerializeField] Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<DepthOfField>(out depthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs(cameraTransform.position.z) + 7;
        depthOfField.focusDistance.value = distance;
        Debug.Log(depthOfField.focusDistance.value);
    }
}
