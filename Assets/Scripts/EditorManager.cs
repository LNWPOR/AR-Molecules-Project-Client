using UnityEngine;
using System.Collections;

public class EditorManager : MonoBehaviour {

    public string AXEName;
    public GameObject mainEditMolecule;
    public JSONObject editMoleculeJSON;

    private static EditorManager _instance; 
    public static EditorManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("_EditorManager").AddComponent<EditorManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        AXEName = "AX2E0";
    }

    public void SetMainEditMolecule()
    {
        mainEditMolecule = GameObject.Find(EditorManager.Instance.AXEName);
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

        editMoleculeJSON = newEditMoleculeJSON;
        //NetworkManager.Instance.Socket.Emit("ADD_MOLECULE",  editMoleculeJSON);
    }
}
