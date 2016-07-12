using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using SocketIO;

public class MainController : MonoBehaviour
{
    public GameObject imageTarget;
    public GameObject[] moleculePrefabs;
    private GameObject moleculePrefabsSelected;
    private GameObject moleculeInstantiate;
    public Button backBtn;
    public Text moleculeNameText;

    private GameObject mainManager;
    private MainManager mainManagerScript;

    public GameObject mainMolecule;


    private GameObject modelGenerator;
    private ModelGenerator modelGeneratorScript;

    private string moleculeName = "SO42-";

    void Awake()
    {
        GetMainManager();
        GetModelGenerator();
        backBtn.onClick.AddListener(() => OnClickBack());
    }

    private void GetModelGenerator()
    {
        modelGenerator = GameObject.Find("ModelGenerator");
        if (modelGenerator != null)
        {
            modelGeneratorScript = modelGenerator.GetComponent<ModelGenerator>();
        }
    }

    private void GetMainManager()
    {
        mainManager = GameObject.Find("MainManager");
        mainManagerScript = mainManager.GetComponent<MainManager>();
    }

    void Start()
    {
        InitMolecule();
        SetUIText();
        SetMainMolecule();
    }

    private void OnClickBack()
    {
        SceneManager.LoadScene("menu");
    }

    private void InitMolecule()
    {
        //moleculePrefabsSelected = Array.Find(moleculePrefabs, s => s.name.Equals(mainManagerScript.moleculeSelected.name));
        //moleculeInstantiate = Instantiate(moleculePrefabsSelected,
        //    new Vector3(transform.position.x, transform.position.y + 15f, transform.position.z),
        //    Quaternion.identity) as GameObject;
        //moleculeInstantiate.name = moleculePrefabsSelected.name;
        //moleculeInstantiate.transform.parent = imageTarget.transform;
    }

    private void SetUIText()
    {
        //moleculeNameText.text = moleculeInstantiate.name;
        //axeNameText.text = MainManager.Instance.axeName;
    }

    private void SetMainMolecule()
    {
        //Debug.Log(evt.data);
        //mainMolecule.name = editorManagerScript.AXEName;
        for (int i = 0; i < mainManagerScript.moleculeJSONSelected.GetField("moleculeObjectsList").Count; i++)
        {
            string moleculeObjectName = Converter.JsonToString(mainManagerScript.moleculeJSONSelected.GetField("moleculeObjectsList")[i].GetField("name").ToString());
            Vector3 moleculeObjectPosition = Converter.JsonToVecter3(Converter.JsonToString(mainManagerScript.moleculeJSONSelected.GetField("moleculeObjectsList")[i].GetField("position").ToString()));
            Quaternion moleculeObjectRotation = Converter.JsonToRotation(Converter.JsonToString(mainManagerScript.moleculeJSONSelected.GetField("moleculeObjectsList")[i].GetField("rotation").ToString()));

            if (Converter.JsonToString(mainManagerScript.moleculeJSONSelected.GetField("moleculeObjectsList")[i].GetField("tag").ToString()).Equals("Atom"))
            {
                //Debug.Log(moleculeObjectName + " : " + moleculeObjectPosition + " : " + moleculeObjectRotation);
                modelGeneratorScript.GenerateAtom(moleculeObjectName, moleculeObjectPosition, moleculeObjectRotation, mainMolecule);
            }
            else if (Converter.JsonToString(mainManagerScript.moleculeJSONSelected.GetField("moleculeObjectsList")[i].GetField("tag").ToString()).Equals("StickGroup"))
            {
                //Debug.Log(moleculeObjectName + " : " + moleculeObjectPosition + " : " + moleculeObjectRotation);
                modelGeneratorScript.GenerateStickGroup(moleculeObjectName, moleculeObjectPosition, moleculeObjectRotation, mainMolecule);
            }
        }
    }
}
