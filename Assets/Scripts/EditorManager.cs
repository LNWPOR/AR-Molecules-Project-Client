using UnityEngine;
using System.Collections;

public class EditorManager : MonoBehaviour {

    public string AXEName;
    public GameObject mainEditMolecule;
    public JSONObject mainEditMoleculeJSON;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        AXEName = "AX2E0";
    }

    public void SetMainEditMolecule()
    {
        mainEditMolecule = GameObject.Find(AXEName);
        //GameObject currentMainEditMolecule = GameObject.Find(AXEName);
        //if (currentMainEditMolecule != null)
        //{
        //    Transform[] currentMainEditMoleculeChilds = currentMainEditMolecule.GetComponentsInChildren<Transform>();
        //    mainEditMolecule = new GameObject();
        //    foreach (Transform currentMainEditMoleculeChild in currentMainEditMoleculeChilds)
        //    {
        //        //Debug.Log(currentMainEditMoleculeChild);
        //        if (currentMainEditMoleculeChild.tag.Equals("Molecule"))
        //        {
        //            mainEditMolecule.name = currentMainEditMoleculeChild.name;
        //            mainEditMolecule.transform.position = currentMainEditMoleculeChild.transform.position;
        //            mainEditMolecule.transform.rotation = currentMainEditMoleculeChild.transform.rotation;
        //        }
        //        else if (currentMainEditMoleculeChild.tag.Equals("Atom"))
        //        {
        //            GameObject newAtom = new GameObject();
        //            newAtom.name = currentMainEditMoleculeChild.name;
        //            newAtom.transform.parent = mainEditMolecule.transform;
        //            newAtom.transform.localPosition = currentMainEditMoleculeChild.transform.localPosition;
        //            newAtom.transform.localRotation = currentMainEditMoleculeChild.transform.localRotation;
        //        }
        //        else if (currentMainEditMoleculeChild.tag.Equals("StickGroup"))
        //        {
        //            GameObject newStickGroup = new GameObject();
        //            newStickGroup.name = currentMainEditMoleculeChild.name;
        //            newStickGroup.transform.parent = mainEditMolecule.transform;
        //            newStickGroup.transform.localPosition = currentMainEditMoleculeChild.transform.localPosition;
        //            newStickGroup.transform.localRotation = currentMainEditMoleculeChild.transform.localRotation;
        //        }
        //    }

        //}
    }

    public void SetEditMoleculeJSON()
    {
        JSONObject moleculeObjectList = new JSONObject();
        Transform[] moleculeChilds = mainEditMolecule.GetComponentsInChildren<Transform>();
        foreach (Transform moleculeChild in moleculeChilds)
        {
            if (moleculeChild.gameObject.tag.Equals("Atom"))
            {
                JSONObject atom = new JSONObject();
                atom.AddField("name", moleculeChild.gameObject.name);
                atom.AddField("tag", moleculeChild.gameObject.tag);
                atom.AddField("position", moleculeChild.localPosition.x.ToString() + ","
                                        + moleculeChild.localPosition.y.ToString() + ","
                                        + moleculeChild.localPosition.z.ToString());
                atom.AddField("rotation", moleculeChild.localRotation.x.ToString() + ","
                                        + moleculeChild.localRotation.y.ToString() + ","
                                        + moleculeChild.localRotation.z.ToString());
                moleculeObjectList.Add(atom);
                
            }
            else if (moleculeChild.gameObject.tag.Equals("StickGroup"))
            {
                JSONObject stickGroup = new JSONObject();
                Transform[] stickGroupChilds = moleculeChild.gameObject.GetComponentsInChildren<Transform>();
                foreach (Transform stickGroupChild in stickGroupChilds)
                {
                    if (stickGroupChild.gameObject.tag.Equals("Bond") && stickGroupChild.gameObject.activeInHierarchy)
                    {
                        JSONObject stick = new JSONObject();
                        stick.AddField("name", stickGroupChild.gameObject.name);
                        stick.AddField("tag", stickGroupChild.gameObject.tag);
                        stick.AddField("position", moleculeChild.localPosition.x.ToString() + ","
                                                 + moleculeChild.localPosition.y.ToString() + ","
                                                 + moleculeChild.localPosition.z.ToString());
                        stick.AddField("rotation", moleculeChild.localRotation.x.ToString() + ","
                                                 + moleculeChild.localRotation.y.ToString() + ","
                                                 + moleculeChild.localRotation.z.ToString());
                        moleculeObjectList.Add(stick);
                    }
                }
            }
            
        }

        JSONObject newEditMoleculeJSON = new JSONObject();
        //newEditMoleculeJSON.AddField("name", "SO42-");
        //newEditMoleculeJSON.AddField("ownerID", "12345678");
        //newEditMoleculeJSON.AddField("description", "Awesome");
        newEditMoleculeJSON.AddField("moleculeObjectsList", moleculeObjectList);

        mainEditMoleculeJSON = newEditMoleculeJSON;
        //NetworkManager.Instance.Socket.Emit("ADD_MOLECULE",  editMoleculeJSON);
    }
}
