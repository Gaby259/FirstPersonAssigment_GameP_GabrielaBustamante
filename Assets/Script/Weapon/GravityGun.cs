using UnityEngine;

public class GravityGun : MonoBehaviour
{
    [SerializeField] protected Projectiile _projectile;
    [SerializeField] protected float _shotSpeed = 20f;
    [SerializeField] protected Transform _shotOrigin;
    
    [Header("Audio")]
    [SerializeField] private AudioClip _shootAudio;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public virtual void Shoot()
    {
        
        Projectiile projectile = Instantiate(_projectile,_shotOrigin.position,_shotOrigin.rotation);
        projectile.Fire(_shotOrigin.forward,_shotSpeed);
        //Audio Play
        if (_audioSource != null)
        {
            _audioSource.PlayOneShot(_shootAudio);
        }
    }
}
