using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorManager : MonoBehaviour 
{
    public static ColorManager instance;
    [SerializeField] private List <GameObject> _pressurePlate;
    [SerializeField] private List <GameObject> _object;
    [SerializeField] private List <Color> _correspondingColors;
    [SerializeField] int totalCorrectPlacementsNeed;
    [SerializeField] int currentCorrectPlacements; 
    public UnityEvent completeEvent; //The event you want to call when all boxes are placed. This can be anything. 
    //Before we got and instace for the class, so the doors were trying to use just one colormanagment
    void Start()
    {
        totalCorrectPlacementsNeed = _pressurePlate.Count;
        AssignColorsToListObject(_object);
        AssignColorsToListObject(_pressurePlate);
    }
    

    void AssignColorsToListObject(List <GameObject> _object)
    {
        for (int i = 0; i < _object.Count; i++)
        {
            _object[i].GetComponent<Renderer>().material.color = _correspondingColors[i];
        }
        
        
    }
    public void IncreaseCorrectPlacements()
    {
        currentCorrectPlacements++;
        Debug.Log(currentCorrectPlacements);
        if(currentCorrectPlacements == totalCorrectPlacementsNeed)
        {
            Debug.Log("ALL BOXES PLACED CORRECTLY");
            completeEvent.Invoke();
        }
    }
    public void DecreaseCorrectPlacements()
    {
        currentCorrectPlacements--;
    }
}
