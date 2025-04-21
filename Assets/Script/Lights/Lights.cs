using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] private List<Light> _lightsToActivate;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")) 
        {
           
            foreach (Light light in _lightsToActivate)
            {
               
                light.enabled = true;
            }
        }
    }
}