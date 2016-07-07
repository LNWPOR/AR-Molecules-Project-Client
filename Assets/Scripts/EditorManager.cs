using UnityEngine;
using System.Collections;

public class EditorManager : MonoBehaviour {

    public string AXEName;
    public GameObject mainEditMolecule;
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

    public void SetMainEditMolecule(GameObject newMainEditMolecule)
    {
        mainEditMolecule = newMainEditMolecule;

        //JSONObject data = new JSONObject();
        //data.AddField("position", mainEditMolecule.transform.position.x.ToString() + "," + mainEditMolecule.transform.position.y.ToString());
        //data.AddField("rotation", mainEditMolecule.transform.rotation.x.ToString() + ","
        //                         + mainEditMolecule.transform.rotation.y.ToString() + ","
        //                         + mainEditMolecule.transform.rotation.z.ToString());
    }
}
