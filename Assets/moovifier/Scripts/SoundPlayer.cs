using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] zoomSounds;

    public void SoundEvent()
    {
        // decide if a sound should be played 50% chance
        if (Random.Range(0, 2) == 0) return;

        int index = Random.Range(0, zoomSounds.Length);
        AudioSource.PlayClipAtPoint(zoomSounds[index], transform.position);
    }
}
