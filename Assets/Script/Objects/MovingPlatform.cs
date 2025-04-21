using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _length = 10f;
    [SerializeField] private float _offset = -5f; // how much its going to move
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        float move = Mathf.PingPong(Time.time * _speed, _length) + _offset;
        Vector3 newPosition = _startPosition + new Vector3(move, 0, 0);
        transform.position = newPosition;
    }
    
}
