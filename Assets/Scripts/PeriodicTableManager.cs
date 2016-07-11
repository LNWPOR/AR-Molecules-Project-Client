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
        //Debug.Log(periodicTableList[0].name +":"+ periodicTableList[0].groupNumber + ":" + periodicTableList[0].atomName + ":" + periodicTableList[0].mass + ":" + periodicTableList[0].en );
    }

    private void InitPeriodicTable()
    {
        periodicTableList = new List<ElementData>();
        //atomName,groupNumber,atomNumber,mass==-1,en=-1
        AddElementToPeriodicTableList("H", 1, "A", 1, 1.008f, -1f);
        AddElementToPeriodicTableList("Li", 1, "A", 3, 6.941f, 0.98f);
        AddElementToPeriodicTableList("Na", 1, "A", 11, 22.990f, 0.93f);
        AddElementToPeriodicTableList("K", 1, "A", 19, 39.098f, 0.82f);
        AddElementToPeriodicTableList("Rb", 1, "A", 37, 84.468f, 0.79f);
        AddElementToPeriodicTableList("Cs", 1, "A", 55, 132.905f, 0.70f);
        AddElementToPeriodicTableList("Fr", 1, "A", 87, 223.020f, 0.70f);
        //-------------end of group 1A------------//
        AddElementToPeriodicTableList("Be", 2, "A", 4, 9.012f, 1.57f);
        AddElementToPeriodicTableList("Mg", 2, "A", 12, 24.305f, 1.31f);
        AddElementToPeriodicTableList("Ca", 2, "A", 20, 40.078f, 1.00f);
        AddElementToPeriodicTableList("Sr", 2, "A", 38, 87.62f, 0.95f);
        AddElementToPeriodicTableList("Ba", 2, "A", 56, 137.327f, 0.89f);
        AddElementToPeriodicTableList("Ra", 2, "A", 88, 226.025f, 0.90f);
        //-------------end of group 2A------------//

        AddElementToPeriodicTableList("Sc", 3, "B", 21, 44.956f, -1f);
        AddElementToPeriodicTableList("Y", 3, "B", 39, 88.906f, -1f);
        //-------------end of group 3B------------//
        AddElementToPeriodicTableList("Ti", 4, "B", 22, 47.88f, -1f);
        AddElementToPeriodicTableList("Zr", 4, "B", 40, 91.22f, -1f);
        AddElementToPeriodicTableList("Hf", 4, "B", 72, 178.49f, -1f);
        AddElementToPeriodicTableList("Rf", 4, "B", 104, -1f, -1f);
        //-------------end of group 4B------------//
        AddElementToPeriodicTableList("V", 5, "B", 23, 50.942f, -1f);
        AddElementToPeriodicTableList("Nb", 5, "B", 41, 92.906f, -1f);
        AddElementToPeriodicTableList("Ta", 5, "B", 73, 180.948f, -1f);
        AddElementToPeriodicTableList("Db", 5, "B", 105, -1f, -1f);
        //-------------end of group 5B------------//
        AddElementToPeriodicTableList("Cr", 6, "B", 24, 51.996f, -1f);
        AddElementToPeriodicTableList("Mo", 6, "B", 42, 95.95f, -1f);
        AddElementToPeriodicTableList("W", 6, "B", 74, 181.85f, -1f);
        AddElementToPeriodicTableList("Sg", 6, "B", 106, -1f, -1f);
        //-------------end of group 6B------------//
        AddElementToPeriodicTableList("Mn", 7, "B", 25, 54.938f, -1f);
        AddElementToPeriodicTableList("Tc", 7, "B", 43, 98.907f, -1f);
        AddElementToPeriodicTableList("Re", 7, "B", 75, 186.207f, -1f);
        AddElementToPeriodicTableList("Bh", 7, "B", 107, -1f, -1f);
        //-------------end of group 7B------------//
        AddElementToPeriodicTableList("Fe", 8, "B1", 26, 55.933f, -1f);
        AddElementToPeriodicTableList("Ru", 8, "B1", 44, 101.07f, -1f);
        AddElementToPeriodicTableList("Os", 8, "B1", 76, 190.23f, -1f);
        AddElementToPeriodicTableList("Hs", 8, "B1", 108, -1f, -1f);
        //-------------end of group 8B1------------//
        AddElementToPeriodicTableList("Co", 8, "B2", 27, 58.933f, -1f);
        AddElementToPeriodicTableList("Rh", 8, "B2", 45, 102.906f, -1f);
        AddElementToPeriodicTableList("Ir", 8, "B2", 77, 192.22f, -1f);
        AddElementToPeriodicTableList("Mt", 8, "B2", 109, -1f, -1f);
        //-------------end of group 8B2------------//
        AddElementToPeriodicTableList("Ni", 8, "B3", 28, 58.693f, -1f);
        AddElementToPeriodicTableList("Pd", 8, "B3", 46, 106.42f, -1f);
        AddElementToPeriodicTableList("Pt", 8, "B3", 78, 195.08f, -1f);
        AddElementToPeriodicTableList("Ds", 8, "B3", 110, -1f, -1f);
        //-------------end of group 8B3------------//
        AddElementToPeriodicTableList("Cu", 1, "B", 29, 63.546f, -1f);
        AddElementToPeriodicTableList("Ag", 1, "B", 47, 107.868f, -1f);
        AddElementToPeriodicTableList("Au", 1, "B", 79, 196.967f, -1f);
        AddElementToPeriodicTableList("Rg", 1, "B", 111, -1f, -1f);
        //-------------end of group 1B------------//
        AddElementToPeriodicTableList("Zn", 2, "B", 30, 65.39f, -1f);
        AddElementToPeriodicTableList("Cd", 2, "B", 48, 112.411f, -1f);
        AddElementToPeriodicTableList("Hg", 2, "B", 80, 200.59f, -1f);
        AddElementToPeriodicTableList("Cn", 2, "B", 112, -1f, -1f);
        //-------------end of group 2B------------//

        AddElementToPeriodicTableList("B", 3, "A", 5, 10.811f, 2.04f);
        AddElementToPeriodicTableList("Al", 3, "A", 13, 26.982f, 1.61f);
        AddElementToPeriodicTableList("Ga", 3, "A", 31, 69.732f, 1.81f);
        AddElementToPeriodicTableList("In", 3, "A", 49, 114.818f, 1.78f);
        AddElementToPeriodicTableList("Tl", 3, "A", 81, 204.383f, 2.04f);
        AddElementToPeriodicTableList("Uut", 3, "A", 113, -1f, -1f);
        //-------------end of group 3A------------//
        AddElementToPeriodicTableList("C", 4, "A", 6, 12.011f, 2.55f);
        AddElementToPeriodicTableList("Si", 4, "A", 14, 28.086f, 1.90f);
        AddElementToPeriodicTableList("Ge", 4, "A", 32, 72.61f, 2.01f);
        AddElementToPeriodicTableList("Sn", 4, "A", 50, 118.71f, 1.96f);
        AddElementToPeriodicTableList("Pb", 4, "A", 82, 207.2f, 2.33f);
        AddElementToPeriodicTableList("Fl", 4, "A", 114, -1f, -1f);
        //-------------end of group 4A------------//
        AddElementToPeriodicTableList("N", 5, "A", 7, 14.007f, 3.04f);
        AddElementToPeriodicTableList("P", 5, "A", 15, 30.974f, 2.19f);
        AddElementToPeriodicTableList("As", 5, "A", 33, 2.18f, 74.922f);
        AddElementToPeriodicTableList("Sb", 5, "A", 51, 121.760f, 2.05f);
        AddElementToPeriodicTableList("Bi", 5, "A", 83, 208.980f, 2.02f);
        AddElementToPeriodicTableList("Uup", 5, "A", 115, -1, -1);
        //-------------end of group 5A------------//
        AddElementToPeriodicTableList("O", 6, "A", 8, 15.999f, 3.44f);
        AddElementToPeriodicTableList("S", 6, "A", 16, 32.066f, 2.58f);
        AddElementToPeriodicTableList("Se", 6, "A", 34, 78.972f, 2.55f);
        AddElementToPeriodicTableList("Te", 6, "A", 52, 127.6f, 2.10f);
        AddElementToPeriodicTableList("Po", 6, "A", 84, 208.982f, 2.00f);
        AddElementToPeriodicTableList("Lv", 6, "A", 116, -1, -1);
        //-------------end of group 6A------------//
        AddElementToPeriodicTableList("F", 7, "A", 8, 15.999f, 3.44f);
        AddElementToPeriodicTableList("Cl", 7, "A", 17, 35.453f, 3.16f);
        AddElementToPeriodicTableList("Br", 7, "A", 35, 2.96f, 79.904f);
        AddElementToPeriodicTableList("I", 7, "A", 53, 126.904f, 2.66f);
        AddElementToPeriodicTableList("At", 7, "A", 85, 209.987f, 2.20f);
        AddElementToPeriodicTableList("Uus", 7, "A", 117, -1f, -1f);
        //-------------end of group 7A------------//
        AddElementToPeriodicTableList("He", 8, "A", 2, 4.003f, -1f);
        AddElementToPeriodicTableList("Ne", 8, "A", 10, 20.180f, -1f);
        AddElementToPeriodicTableList("Ar", 8, "A", 18, 39.948f, -1f);
        AddElementToPeriodicTableList("Kr", 8, "A", 36, 84.80f, -1f);
        AddElementToPeriodicTableList("Xe", 8, "A", 54, 131.29f, -1f);
        AddElementToPeriodicTableList("Rn", 8, "A", 86, 222.018f, -1f);
        AddElementToPeriodicTableList("Uuo", 8, "A", 118, -1f, -1f);
    }

    private void AddElementToPeriodicTableList(string newName, int newGroupNumber, string newGroupType, int newAtomNumber, float newMass, float newEn)
    {
        ElementData newElement = new ElementData(newName, newGroupType, newGroupNumber, newAtomNumber, newMass, newEn);
        periodicTableList.Add(newElement);
    }
}
