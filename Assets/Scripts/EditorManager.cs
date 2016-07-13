using UnityEngine;
using System.Collections;

public class EditorManager : MonoBehaviour {

    public string AXEName;
    public GameObject mainEditMolecule;
    public JSONObject mainEditMoleculeJSON;

    //private GameObject networkManager;
    //private NetworkManager networkManagerScript;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //GetNetworkManager();
        AXEName = "AX2E0";
    }

    public void SetMainEditMolecule()
    {
        mainEditMolecule = GameObject.Find(AXEName);
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
                atom.AddField("rotation", moleculeChild.localEulerAngles.x.ToString() + ","
                                        + moleculeChild.localEulerAngles.y.ToString() + ","
                                        + moleculeChild.localEulerAngles.z.ToString());
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
                        stick.AddField("tag", moleculeChild.gameObject.tag);
                        stick.AddField("position", moleculeChild.localPosition.x.ToString() + ","
                                                 + moleculeChild.localPosition.y.ToString() + ","
                                                 + moleculeChild.localPosition.z.ToString());
                        stick.AddField("rotation", moleculeChild.localEulerAngles.x.ToString() + ","
                                                 + moleculeChild.localEulerAngles.y.ToString() + ","
                                                 + moleculeChild.localEulerAngles.z.ToString());
                        moleculeObjectList.Add(stick);
                    }
                }
            }
            
        }

        JSONObject newEditMoleculeJSON = new JSONObject();
        //newEditMoleculeJSON.AddField("name", "SO42-");
        //newEditMoleculeJSON.AddField("ownerID", "12345678");
        //newEditMoleculeJSON.AddField("moleculeObjectsList", moleculeObjectList);
        mainEditMoleculeJSON = newEditMoleculeJSON;
        //networkManagerScript.Socket.Emit("ADD_MOLECULE", mainEditMoleculeJSON);
    }

    //private void GetNetworkManager()
    //{
    //    networkManager = GameObject.Find("NetworkManager");
    //    networkManagerScript = networkManager.GetComponent<NetworkManager>();
    //}
}
