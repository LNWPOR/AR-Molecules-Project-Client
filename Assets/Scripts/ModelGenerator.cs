using UnityEngine;
using System.Collections;
using System;

public class ModelGenerator : MonoBehaviour {

    public GameObject[] elementPrefabs;
    public GameObject stickGroupPrefabs;

    public void GenerateAtom(string atomName, Vector3 atomPosition, Quaternion atomRotation)
    {
        GameObject atomPrefabForGenerate = Array.Find(elementPrefabs, s => s.name.Equals(atomName));
        if (atomPrefabForGenerate != null)
        {
            GameObject atomGenerated = Instantiate(atomPrefabForGenerate, atomPosition, atomRotation) as GameObject;
        }
    }

    public void GenerateStickGroup(string stickName, Vector3 stickPosition, Quaternion stickRotation)
    {
        GameObject stickPrefabGenerated = Instantiate(stickGroupPrefabs, stickPosition, stickRotation) as GameObject;
        Transform[] stickPrefabGeneratedChilds = stickPrefabGenerated.GetComponentsInChildren<Transform>();
        TurnOnStick(stickPrefabGeneratedChilds, stickName);
    }

    private void TurnOnStick(Transform[] stickPrefabGeneratedChilds,string stringName)
    {
        foreach (Transform stickPrefabGeneratedChild in stickPrefabGeneratedChilds)
        {
            if (stickPrefabGeneratedChild.gameObject.tag.Equals("Bond"))
            {
                if (stickPrefabGeneratedChild.gameObject.name.Equals(stringName))
                {
                    stickPrefabGeneratedChild.gameObject.SetActive(true);
                }
                else
                {
                    stickPrefabGeneratedChild.gameObject.SetActive(false);
                }
            }
        }
    }
}
