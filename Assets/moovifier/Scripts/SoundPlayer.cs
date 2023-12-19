using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] zoomSounds;

    public void SoundEvent()
    {
        int index = Random.Range(0, zoomSounds.Length);
        AudioSource.PlayClipAtPoint(zoomSounds[index], transform.position);
    }
}
