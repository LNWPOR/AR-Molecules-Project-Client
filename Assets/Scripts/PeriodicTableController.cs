using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PeriodicTableController : MonoBehaviour
{
    public GameObject mainEditMolecule;
    public Transform periodicTablePanel;
    public Button searchButton;
    public Button menuButton;
    public Button testButton;
    public Button nextButton;
    public Button leftArrowButton;
    public Button rightArrowButton;
    private Animator anim;
    private bool periodicTablePanelIsShow = false;

    public Canvas editorCanvas;
    public GameObject[] elementPrefabs;
    public GameObject elementPrefabInitiated;
    public Transform elementDetailPanel;

    private GameObject atomTarget;
    
    public GameObject mainCamera;
    private Vector3 initCameraPosition;
    private Vector3 currentCameraPosition;

    void Awake()
    {
        initCameraPosition = mainCamera.transform.position;
        currentCameraPosition = mainCamera.transform.position;
    }

    void Start()
    {
        elementPrefabInitiated = null;
        InitAnim();
    }

    public GameObject GetAtomTarget()
    {
        return atomTarget;
    }
    public void SetAtomTarget(GameObject newAtomTarget)
    {
        atomTarget = newAtomTarget;
    }

    private void InitAnim()
    {
        //Time.timeScale = 1;
        anim = periodicTablePanel.GetComponent<Animator>();
        anim.enabled = false;
    }

    public GameObject[] getElementPrefabs()
    {
        return elementPrefabs;
    }

    public GameObject getElementPrefabInitiated()
    {
        return elementPrefabInitiated;
    }

    public void SetElementPrefabInitiated(GameObject newElementPrefabInitiated)
    {
        elementPrefabInitiated = newElementPrefabInitiated;
    }

    void Update()
    {
    }

    public void SetElementDetailPanelText(ElementData elementForButton)
    {
        Text[] elementDetailPanelText = elementDetailPanel.GetComponentsInChildren<Text>();
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomNameText")).text     = " Name : " + elementForButton.name;
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomNumberText")).text   = " Number : " + elementForButton.atomNumber.ToString();
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomMassText")).text     = " Mass : " + elementForButton.mass.ToString();
        if (elementForButton.en.Equals(-1))
        {
            Array.Find(elementDetailPanelText, s => s.name.Equals("AtomEnText")).text = " En : NaN";
        }
        else
        {
            Array.Find(elementDetailPanelText, s => s.name.Equals("AtomEnText")).text = " En : " + elementForButton.en.ToString();
        }
    }

    public void ClosePeriodicTable()
    {
        if (elementPrefabInitiated != null)
        {
            Destroy(elementPrefabInitiated);
        }
        ResetElementDetailPanelText();
        PlayAnimClosePeriodicTable();

        mainCamera.transform.position = currentCameraPosition;
    }

    public void OpenPeriodicTable()
    {
        ResetElementDetailPanelText();
        PlayAnimOpenPeriodicTable();

        currentCameraPosition = mainCamera.transform.position;
        mainCamera.transform.position = initCameraPosition;
    }

    private void PlayAnimClosePeriodicTable()
    {
        periodicTablePanelIsShow = false;
        anim.Play("PeriodicTableSlideOut");
        SetShowObject(true);
        //Time.timeScale = 1;
    }

    private void PlayAnimOpenPeriodicTable()
    {
        anim.enabled = true;
        anim.Play("PeriodicTableSlideIn");
        periodicTablePanelIsShow = true;
        SetShowObject(false);
        //Time.timeScale = 0;
    }

    private void ResetElementDetailPanelText()
    {
        Text[] elementDetailPanelText = elementDetailPanel.GetComponentsInChildren<Text>();
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomNameText")).text = "";
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomNumberText")).text = "";
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomMassText")).text = "";
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomEnText")).text = "";
    }


    public void SetShowObject(bool isShow)
    {
        SetButtonHideOrShow(isShow);
        SetMoleculeHideOrShow(isShow);
    }

    private void SetButtonHideOrShow(bool setButton)
    {
        menuButton.gameObject.SetActive(setButton);
        searchButton.gameObject.SetActive(setButton);
        testButton.gameObject.SetActive(setButton);
        nextButton.gameObject.SetActive(setButton);
        leftArrowButton.gameObject.SetActive(setButton);
        rightArrowButton.gameObject.SetActive(setButton);
    }

    private void SetMoleculeHideOrShow(bool setMolecule)
    {
        mainEditMolecule.SetActive(setMolecule);
    }

    public void TurnOnOnClickAllAtom()
    {
        Transform[] atoms = mainEditMolecule.GetComponentsInChildren<Transform>();

        foreach (Transform atom in atoms)
        {
            if (atom.tag.Equals("Atom"))
            {
                AtomController atomControllerScript = atom.GetComponent<AtomController>();
                atomControllerScript.canClick = true;
            }

        }
    }
}
