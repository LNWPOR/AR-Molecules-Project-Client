using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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

    void Awake()
    {
        GetMainManager();
        backBtn.onClick.AddListener(() => OnClickBack());
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
    }

    private void OnClickBack()
    {
        SceneManager.LoadScene("menu");
    }

    private void InitMolecule()
    {
        moleculePrefabsSelected = Array.Find(moleculePrefabs, s => s.name.Equals(mainManagerScript.moleculeSelected.name));
        moleculeInstantiate = Instantiate(moleculePrefabsSelected,
            new Vector3(transform.position.x, transform.position.y + 15f, transform.position.z),
            Quaternion.identity) as GameObject;
        moleculeInstantiate.name = moleculePrefabsSelected.name;
        moleculeInstantiate.transform.parent = imageTarget.transform;
    }

    private void SetUIText()
    {
        moleculeNameText.text = moleculeInstantiate.name;
        //axeNameText.text = MainManager.Instance.axeName;
    }
}
