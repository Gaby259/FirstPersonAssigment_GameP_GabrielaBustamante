using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AmbienceMusic : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.playOnAwake = false;
        _audio.loop = true;
        _audio.spatialBlend = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_audio.isPlaying)
            {
                Debug.Log("Player entered area, playing music.");
                _audio.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_audio.isPlaying)
            {
                Debug.Log("Player left area, stopping music.");
                _audio.Stop();
            }
        }
    }
    
}
