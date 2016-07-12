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

    private GameObject networkManager;
    private NetworkManager networkManagerScript;

    private GameObject modelGenerator;
    private ModelGenerator modelGeneratorScript;

    private string moleculeName = "SO42-";

    void Awake()
    {
        GetNetworkManager();
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
        SocketOn();
        InitMolecule();
        SetUIText();
        StartCoroutine(WaitToEmitGetMainEditMoleculeJSON(1f));

    }

    private IEnumerator WaitToEmitGetMainEditMoleculeJSON(float time)
    {
        float count = 0;
        while (count < time)
        {
            count += Time.deltaTime;
            // Debug.Log(Mathf.Floor(count));
            yield return new WaitForEndOfFrame();
        }

        JSONObject data = new JSONObject();
        data.AddField("name", moleculeName);
        networkManagerScript.Socket.Emit("GET_mainEditMoleculeJSON", data);
    }


    private void SocketOn()
    {
        networkManagerScript.Socket.On("GET_mainEditMoleculeJSON", SetMainMolecule);
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

    private void SetMainMolecule(SocketIOEvent evt)
    {
        //Debug.Log(evt.data);
        //mainMolecule.name = editorManagerScript.AXEName;
        for (int i = 0; i < evt.data.GetField("moleculeObjectsList").Count; i++)
        {
            string moleculeObjectName = Converter.JsonToString(evt.data.GetField("moleculeObjectsList")[i].GetField("name").ToString());
            Vector3 moleculeObjectPosition = Converter.JsonToVecter3(Converter.JsonToString(evt.data.GetField("moleculeObjectsList")[i].GetField("position").ToString()));
            Quaternion moleculeObjectRotation = Converter.JsonToRotation(Converter.JsonToString(evt.data.GetField("moleculeObjectsList")[i].GetField("rotation").ToString()));

            if (Converter.JsonToString(evt.data.GetField("moleculeObjectsList")[i].GetField("tag").ToString()).Equals("Atom"))
            {
                //Debug.Log(moleculeObjectName + " : " + moleculeObjectPosition + " : " + moleculeObjectRotation);
                modelGeneratorScript.GenerateAtom(moleculeObjectName, moleculeObjectPosition, moleculeObjectRotation, mainMolecule);
            }
            else if (Converter.JsonToString(evt.data.GetField("moleculeObjectsList")[i].GetField("tag").ToString()).Equals("StickGroup"))
            {
                //Debug.Log(moleculeObjectName + " : " + moleculeObjectPosition + " : " + moleculeObjectRotation);
                modelGeneratorScript.GenerateStickGroup(moleculeObjectName, moleculeObjectPosition, moleculeObjectRotation, mainMolecule);
            }
        }
    }

    private void GetNetworkManager()
    {
        networkManager = GameObject.Find("NetworkManager");
        networkManagerScript = networkManager.GetComponent<NetworkManager>();
    }
}
