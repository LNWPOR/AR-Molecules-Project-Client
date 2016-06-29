using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PeriodicTableController : MonoBehaviour
{
    public Transform periodicTablePanel;
    public GameObject[] elementPrefabs;
    public GameObject elementPrefabInitiated;

    void Start()
    {
        elementPrefabInitiated = null;
    }

    public GameObject[] getElementPrefabs()
    {
        return elementPrefabs;
    }

    public GameObject getElementPrefabInitiated()
    {
        return elementPrefabInitiated;
    }

    public void setElementPrefabInitiated(GameObject newElementPrefabInitiated)
    {
        elementPrefabInitiated = newElementPrefabInitiated;
    }


    
}
