using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PeriodicTableManager : MonoBehaviour {

    private static PeriodicTableManager _instance;
    public List<ElementData> periodicTableList;

    public static PeriodicTableManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("_PeriodicTableManager").AddComponent<PeriodicTableManager>();
            }

            return _instance;
        }
    }

    public void Awake()
    {
        InitPeriodicTable();
        //Debug.Log(periodicTableList[0]);
        //Debug.Log(periodicTableList[0].atomName +":"+ periodicTableList[0].groupNumber + ":" + periodicTableList[0].atomName + ":" + periodicTableList[0].mass + ":" + periodicTableList[0].en );
    }

    private void InitPeriodicTable()
    {
        periodicTableList = new List<ElementData>();
        //atomName,groupNumber,atomNumber,mass==-1,en=-1
        AddElementToPeriodicTableList("H", 1, 1, 1.008f, -1f);
        AddElementToPeriodicTableList("Li", 1, 3, 6.941f, 0.98f);
        AddElementToPeriodicTableList("Na", 1, 11, 22.990f, 0.93f);
        AddElementToPeriodicTableList("K", 1, 19, 39.098f, 0.82f);
        AddElementToPeriodicTableList("Rb", 1, 37, 84.468f, 0.79f);
        AddElementToPeriodicTableList("Cs", 1, 55, 132.905f, 0.70f);
        AddElementToPeriodicTableList("Fr", 1, 87, 223.020f, 0.70f);
        //-------------end of group 1A------------//
        AddElementToPeriodicTableList("Be", 2, 4, 9.012f, 1.57f);
        AddElementToPeriodicTableList("Mg", 2, 12, 24.305f, 1.31f);
        AddElementToPeriodicTableList("Ca", 2, 20, 40.078f, 1.00f);
        AddElementToPeriodicTableList("Sr", 2, 38, 87.62f, 0.95f);
        AddElementToPeriodicTableList("Ba", 2, 56, 137.327f, 0.89f);
        AddElementToPeriodicTableList("Ra", 2, 88, 226.025f, 0.90f);
        //-------------end of group 2A------------//
        AddElementToPeriodicTableList("B", 3, 5, 10.811f, 2.04f);
        AddElementToPeriodicTableList("Al", 3, 13, 26.982f, 1.61f);
        AddElementToPeriodicTableList("Ga", 3, 31, 69.732f, 1.81f);
        AddElementToPeriodicTableList("In", 3, 49, 114.818f, 1.78f);
        AddElementToPeriodicTableList("Tl", 3, 81, 204.383f, 2.04f);
        AddElementToPeriodicTableList("Uut", 3, 113, -1f, -1f);
        //-------------end of group 3A------------//
        AddElementToPeriodicTableList("C", 4, 6, 12.011f, 2.55f);
        AddElementToPeriodicTableList("Si", 4, 14, 28.086f, 1.90f);
        AddElementToPeriodicTableList("Ge", 4, 32, 72.61f, 2.01f);
        AddElementToPeriodicTableList("Sn", 4, 50, 118.71f, 1.96f);
        AddElementToPeriodicTableList("Pb", 4, 82, 207.2f, 2.33f);
        AddElementToPeriodicTableList("Fl", 4, 114, -1f, -1f);
        //-------------end of group 4A------------//
        AddElementToPeriodicTableList("N", 5, 7, 14.007f, 3.04f);
        AddElementToPeriodicTableList("P", 5, 15, 30.974f, 2.19f);
        AddElementToPeriodicTableList("As", 5, 33, 2.18f, 74.922f);
        AddElementToPeriodicTableList("Sb", 5, 51, 121.760f, 2.05f);
        AddElementToPeriodicTableList("Bi", 5, 83, 208.980f, 2.02f);
        AddElementToPeriodicTableList("Uup", 5, 115, -1, -1);
        //-------------end of group 5A------------//
        AddElementToPeriodicTableList("O", 6, 8, 15.999f, 3.44f);
        AddElementToPeriodicTableList("S", 6, 16, 32.066f, 2.58f);
        AddElementToPeriodicTableList("Se", 6, 34, 78.972f, 2.55f);
        AddElementToPeriodicTableList("Te", 6, 52, 127.6f, 2.10f);
        AddElementToPeriodicTableList("Po", 6, 84, 208.982f, 2.00f);
        AddElementToPeriodicTableList("Lv", 6, 116, -1, -1);
        //-------------end of group 6A------------//
        AddElementToPeriodicTableList("F", 7, 8, 15.999f, 3.44f);
        AddElementToPeriodicTableList("Cl", 7, 17, 35.453f, 3.16f);
        AddElementToPeriodicTableList("Br", 7, 35, 2.96f, 79.904f);
        AddElementToPeriodicTableList("I", 7, 53, 126.904f, 2.66f);
        AddElementToPeriodicTableList("At", 7, 85, 209.987f, 2.20f);
        AddElementToPeriodicTableList("Uus", 7, 117, -1f, -1f);
        //-------------end of group 7A------------//
    }

    private void AddElementToPeriodicTableList(string newName, int newGroupNumber, int newAtomNumber, float newMass, float newEn)
    {
        ElementData newElement = new ElementData(newName, newGroupNumber, newAtomNumber, newMass, newEn);
        periodicTableList.Add(newElement);
    }
}
