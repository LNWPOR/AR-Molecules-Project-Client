using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MainManager : MonoBehaviour
{

    private static MainManager _instance;
    //public int axeNumber = 0;
    //public string axeName = "AX2E0";

    public MoleculeData moleculeSelected;
    public List<MoleculeData> moleculeList;

    public static MainManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("_MainManager").AddComponent<MainManager>();
            }

            return _instance;
        }
    }

    public void Start()
    {
        moleculeList = new List<MoleculeData>();
        AddMoleculeToList("BeCl2");
        AddMoleculeToList("SO3");
        AddMoleculeToList("CH4");
        AddMoleculeToList("PCl5");
        AddMoleculeToList("SF6");
		AddMoleculeToList("Cl2");
		AddMoleculeToList("SF4");
		AddMoleculeToList("XeF4");
		AddMoleculeToList("ClF5");
		AddMoleculeToList("IF7");
    }

    private void AddMoleculeToList(string newName)
    {
        MoleculeData molecule = new MoleculeData(newName);
        moleculeList.Add(molecule);
    }
}
