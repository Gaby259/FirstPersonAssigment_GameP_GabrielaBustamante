using UnityEngine;

public class PressurePlate : MonoBehaviour
{
   [SerializeField] ColorManager _colorManager;
    public int _pressurePlateID;
    public int _objectsOnPressurePlate = 0;

    void Awake()
    {
        if (_colorManager == null)
        {
            _colorManager = FindObjectOfType<ColorManager>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerPickUp>()!=null)
        {
            _objectsOnPressurePlate++;
            
            if (collision.gameObject.GetComponent<PlayerPickUp>().ReturnObjectID() == _pressurePlateID)
            {
                _colorManager?.IncreaseCorrectPlacements();//?means that if it is Null continue with next step and if its not DO THIS
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerPickUp>() != null) //If it is a box that has stopped colliding...
        {
            _objectsOnPressurePlate--; //...then reduce the number of colliding objects...
            
            if (collision.gameObject.GetComponent<PlayerPickUp>().ReturnObjectID() == _pressurePlateID) //...If the box that has stopped colliding is the correct box for this pad...
            {
                _colorManager?.DecreaseCorrectPlacements(); //...then decrease the number of corectly placed pads 
            }
        }
        
    }
}
