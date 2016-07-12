using UnityEngine;
using System.Collections;
using System;

public class ModelGenerator : MonoBehaviour {

    public GameObject[] elementPrefabs;
    public GameObject stickGroupPrefabs;

    public void GenerateAtom(string atomName, Vector3 atomPosition, Quaternion atomRotation, GameObject mainMolecule)
    {
        //Debug.Log(atomName + ":" + atomPosition + ":" + atomRotation + ":" + mainMolecule);
        GameObject atomPrefabForGenerate = Array.Find(elementPrefabs, s => s.name.Equals(atomName));
        if (atomPrefabForGenerate != null)
        {
            GameObject atomGenerated = Instantiate(atomPrefabForGenerate, atomPosition, atomRotation) as GameObject;
            atomGenerated.name = atomName;
            atomGenerated.transform.parent = mainMolecule.transform;
            AtomController atomGeneratedScript = atomGenerated.GetComponent<AtomController>();
            atomGeneratedScript.canClick = false;
            atomGeneratedScript.DestroyElectron();
        }
    }

    public void GenerateStickGroup(string stickName, Vector3 stickPosition, Quaternion stickRotation, GameObject mainMolecule)
    {
        //Debug.Log(stickName + ":" + stickPosition + ":" + stickRotation + ":" + mainMolecule);
        GameObject stickPrefabGenerated = Instantiate(stickGroupPrefabs, stickPosition, stickRotation) as GameObject;
        stickPrefabGenerated.name = "StickGroup";
        Transform[] stickPrefabGeneratedChilds = stickPrefabGenerated.GetComponentsInChildren<Transform>();
        TurnOnStick(stickPrefabGeneratedChilds, stickName);
        stickPrefabGenerated.transform.parent = mainMolecule.transform;
    }

    private void TurnOnStick(Transform[] stickPrefabGeneratedChilds,string stickName)
    {
        foreach (Transform stickPrefabGeneratedChild in stickPrefabGeneratedChilds)
        {
            
            if (stickPrefabGeneratedChild.gameObject.tag.Equals("Bond"))
            {
                if (stickPrefabGeneratedChild.gameObject.name.Equals(stickName))
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
