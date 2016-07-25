using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestController : MonoBehaviour {

    //private GameObject editorManager;
    //private EditorManager editorManagerScript;

    public GameObject mainMolecule;

    private GameObject modelGenerator;
    private ModelGenerator modelGeneratorScript;

    void Awake()
    {
        //GetEditorManager();
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
        SetMainMolecule();
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
                modelGeneratorScript.GenerateAtom(moleculeObjectName, moleculeObjectPosition, moleculeObjectRotation, mainMolecule, false, true);
            }
            else if (Converter.JsonToString(EditorManager.Instance.mainEditMoleculeJSON.GetField("moleculeObjectsList")[i].GetField("tag").ToString()).Equals("StickGroup"))
            {
                //Debug.Log(moleculeObjectName + " : " + moleculeObjectPosition + " : " + moleculeObjectRotation);
                modelGeneratorScript.GenerateStickGroup(moleculeObjectName, moleculeObjectPosition, moleculeObjectRotation, mainMolecule);
            }
        }

        mainMolecule.transform.position = new Vector3(0f, 12.5f, 0f);
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("lnwpor_test");
    }

    public void OnClickSearchButton()
    {
        SceneManager.LoadScene("menu");
    }

    //public void GetEditorManager()
    //{
    //    editorManager = GameObject.Find("EditorManager");
    //    if (editorManager != null)
    //    {
    //        editorManagerScript = editorManager.GetComponent<EditorManager>();
    //    }
    //}
}
