using UnityEngine;
using System.Collections;

public class ElementData : MonoBehaviour {
    public string name;
    public int groupNumber;
    public string groupType;
    public int atomNumber;
    public float mass;
    public float en;

    public ElementData(string newName, string newGroupType, int newGroupNumber, int newAtomNumber, float newMass, float newEn)
    {
        name = newName;
        groupType = newGroupType;
        groupNumber = newGroupNumber;
        atomNumber = newAtomNumber;
        mass = newMass;
        en = newEn;
    }
}
