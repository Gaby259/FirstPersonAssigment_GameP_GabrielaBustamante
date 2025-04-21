using UnityEngine;
using UnityEngine.UIElements;

public class SightFocus : MonoBehaviour
{
    [SerializeField] private Transform _targetOrigin;
    [SerializeField] private Transform _pickUpLocation;
    [SerializeField] private float _targetDistace = 1000f;
    [SerializeField] private LayerMask _LayerMask;
    
  
    // Update is called once per frame
    private FPSController _fpsController;
    [Header("Gun")]
    [SerializeField] private Transform _shoot;
    
    void Awake()
    {
        _fpsController = gameObject.GetComponent<FPSController>();
    }
    void Update()
    {
       ColorChange();
       PlayerPickUp();
       PlayerShooting();
      
    }

     public void ColorChange()
    {
        Vector3 origin = _targetOrigin.position;
        Debug.DrawRay(origin, _targetOrigin.forward * _targetDistace, Color.red);
        if (Physics.Raycast(origin, _targetOrigin.forward, out RaycastHit hit, _targetDistace))
        {
            ColorSwap interactable = hit.collider.gameObject.GetComponent<ColorSwap>();
            if (interactable != null)
            {
                interactable.SwapColor();

            }
        }
    }
     

    public void PlayerPickUp()
    {
        Vector3 origin = _targetOrigin.position;
        Debug.DrawRay(origin, _targetOrigin.forward * _targetDistace, Color.red);
        if (Physics.Raycast(origin, _targetOrigin.forward, out RaycastHit hit, _targetDistace))
        {
            PlayerPickUp pickUp = hit.collider.gameObject.GetComponent<PlayerPickUp>();
            if (pickUp != null && _fpsController.IsPickUpKeyPressed())
            {
                _fpsController._pickUp = pickUp;
                pickUp.SetGrabPosition(_pickUpLocation);
            }
        }
    }
    private  void PlayerShooting()
    {
        Vector3 origin = _shoot.position;
        Debug.DrawRay(origin, _shoot.forward * _targetDistace, Color.red);
        if (Physics.Raycast(origin, _targetOrigin.forward, out RaycastHit hit, _targetDistace))
        {
            GravityGun shoot = hit.collider.gameObject.GetComponent<GravityGun>();
            if (shoot != null && _fpsController.IsPickUpKeyPressed())
            {
                _fpsController._equippedWeapon = shoot;
                shoot.Shoot();
            }
        }
    }
    
}
