using UnityEngine;
using System.Collections;

public class EditorController : MonoBehaviour {

    public GameObject mainEditMolecule;
    private GameObject modelGenerator;
    private ModelGenerator modelGeneratorScript;

    void Awake()
    {
        //DontDestroyOnLoad(EditorManager.Instance.gameObject);
        EditorManager.Instance.mainEditMolecule = mainEditMolecule;
        GetModelGenerator();
    }

    private void GetModelGenerator()
    {
        modelGenerator = GameObject.Find("ModelGenerator");
        if (modelGenerator != null)
        {
            modelGeneratorScript = modelGenerator.GetComponent<ModelGenerator>();
        }
    }

    void Start()
    {
        if (EditorManager.Instance.mainEditMoleculeJSON != null)
        {
            SetMainMolecule();
        }
    }

    private void SetMainMolecule()
    {
        for (int i = 0; i < EditorManager.Instance.mainEditMoleculeJSON.GetField("moleculeObjectsList").Count; i++)
        {
            string moleculeObjectName = Converter.JsonToString(EditorManager.Instance.mainEditMoleculeJSON.GetField("moleculeObjectsList")[i].GetField("name").ToString());
            Vector3 moleculeObjectPosition = Converter.JsonToVecter3(Converter.JsonToString(EditorManager.Instance.mainEditMoleculeJSON.GetField("moleculeObjectsList")[i].GetField("position").ToString()));
            Quaternion moleculeObjectRotation = Converter.JsonToRotation(Converter.JsonToString(EditorManager.Instance.mainEditMoleculeJSON.GetField("moleculeObjectsList")[i].GetField("rotation").ToString()));

            if (Converter.JsonToString(EditorManager.Instance.mainEditMoleculeJSON.GetField("moleculeObjectsList")[i].GetField("tag").ToString()).Equals("Atom"))
            {
                //Debug.Log(moleculeObjectName + " : " + moleculeObjectPosition + " : " + moleculeObjectRotation);
                modelGeneratorScript.GenerateAtom(moleculeObjectName, moleculeObjectPosition, moleculeObjectRotation, mainEditMolecule, true);
            }
            else if (Converter.JsonToString(EditorManager.Instance.mainEditMoleculeJSON.GetField("moleculeObjectsList")[i].GetField("tag").ToString()).Equals("StickGroup"))
            {
                //Debug.Log(moleculeObjectName + " : " + moleculeObjectPosition + " : " + moleculeObjectRotation);
                modelGeneratorScript.GenerateStickGroup(moleculeObjectName, moleculeObjectPosition, moleculeObjectRotation, mainEditMolecule);
            }
        }
    }
}
