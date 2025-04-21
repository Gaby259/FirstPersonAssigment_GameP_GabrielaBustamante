using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{ 
    private Transform _grabPosition;
    private bool _isGrabbing=false;
    private Rigidbody _rb;
    public int _objectID;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_isGrabbing)
        {
            gameObject.transform.position = _grabPosition.position;
        }
    }

    public void SetGrabPosition(Transform grabPosition)
    {
        _grabPosition = grabPosition;
        _rb.isKinematic = true; //Stops the box to collide with other physics objects
        _isGrabbing = true;
    }

    public void Release()
    {
        _isGrabbing = false;
        _rb.isKinematic = false;
        _rb.useGravity = true; //the box will go down 
    }

    public int ReturnObjectID()
    {
        return _objectID;
    }
}
