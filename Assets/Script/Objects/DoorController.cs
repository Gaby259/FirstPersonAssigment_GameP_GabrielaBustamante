using System;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField]  private ColorManager _colorManager;
    
    [Header("Audio")]
    [SerializeField] private AudioClip _explotionAudio;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
private void Start()
    {
        if (_colorManager != null)
        {
           _colorManager.completeEvent.AddListener(OpenDoor);
        }
        else
        {
            Debug.LogWarning("No DoorManager found");
        }
    }

    public void OpenDoor()
    {
        if (door != null && _audioSource != null)
        {
            Destroy(door);
            _audioSource.PlayOneShot(_explotionAudio);
        }
    }

    private void OnDestroy()
    {
        _colorManager.completeEvent.RemoveListener(OpenDoor);
    }
}
