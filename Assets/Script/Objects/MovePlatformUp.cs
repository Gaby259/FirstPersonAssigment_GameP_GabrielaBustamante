using UnityEngine;

public class MovePlatformUp : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _length = 10f;
    [SerializeField] private float _offset = 0f;

    [SerializeField] private GameObject _platform; // La plataforma que se moverá

    private Vector3 _startPosition;
    private bool _isActivated = false;
    private bool _hasStopped = false;
    

    private void Start()
    {
        if (_platform != null)
        {
            _startPosition = _platform.transform.position;
        }
        else
        {
            Debug.LogError("No se asignó la plataforma en el inspector.");
        }
    }

    private void Update()
    {
        if (_isActivated && _platform != null)
        {
           MoveUp();
        }
        else if(_hasStopped)
        {
            StopMovingPlatform();
        }
    }
    public void MoveUp()
    {
            float move = Mathf.PingPong(Time.time * _speed, _length) + _offset;
            Vector3 newPosition = _startPosition + new Vector3(0, move, 0);
            _platform.transform.position = newPosition;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ActivateObject"))
        {
            Debug.Log("Objeto activador detectado.");
            _isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ActivateObject"))
        {
            _isActivated = false;
            _hasStopped = true;
            
        }
    }

    private void StopMovingPlatform()
    {
        Vector3 newPosition = _startPosition + new Vector3(0, 0, 0);
        _platform.transform.position = newPosition;
    }
}
