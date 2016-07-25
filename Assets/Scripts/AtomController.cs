using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AtomController : MonoBehaviour
{

    private Vector3 rotateCenter;
    public bool canSpin;
    public bool canClick;
    public bool canShowPanel;

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;

    private GameObject editorManager;
    private EditorManager editorManagerScript;

    private GameObject periodicTableManager;
    private PeriodicTableManager periodicTableManagerScript;

    public ElementData elementDetail;

    void Awake()
    {
        

        rotateCenter = new Vector3(transform.position.x - 1f,
                                   transform.position.y,
                                   transform.position.z);
        canSpin = false;
        canClick = true;
        canShowPanel = false;

        GerPeriodicTableManager();
        GetPeriodicTableController();
        GetEditorManager();
    }

    void Start()
    {
        InitElementInfo();
    }


    private void InitElementInfo()
    {
        if (periodicTableManagerScript.periodicTableList.Exists(x => x.name.Equals(gameObject.name)))
        {
            elementDetail = periodicTableManagerScript.periodicTableList.Find(x => x.name.Equals(gameObject.name));
        }
    }


    private void GerPeriodicTableManager()
    {
        periodicTableManager = GameObject.Find("PeriodicTableManager");
        if (periodicTableManager != null)
        {
            periodicTableManagerScript = periodicTableManager.GetComponent<PeriodicTableManager>();
        }
    }

    public void GetEditorManager()
    {
        editorManager = GameObject.Find("EditorManager");
        if (editorManager != null)
        {
            editorManagerScript = editorManager.GetComponent<EditorManager>();
        }
    }

    void Update()
    {
        CheckSpinAtom(canSpin);
    }

    void OnMouseDown()
    {
        if (canClick && Input.touchCount.Equals(1))
        {
            TurnOffOnClickAllAtom();
            periodicTableControllerScript.OpenPeriodicTable();
            periodicTableControllerScript.SetAtomTarget(gameObject);
        }

        if (canShowPanel && Input.touchCount.Equals(1))
        {
            GameObject detailPanel = GameObject.Find("DetailPanel");
            Array.Find(detailPanel.GetComponentsInChildren<Text>(), s => s.name.Equals("AtomNameText")).text = " Name : " + elementDetail.name;
            Array.Find(detailPanel.GetComponentsInChildren<Text>(), s => s.name.Equals("AtomNumberText")).text = " Number : " + elementDetail.atomNumber.ToString();
            Array.Find(detailPanel.GetComponentsInChildren<Text>(), s => s.name.Equals("AtomMassText")).text = " Mass : " + elementDetail.mass.ToString();

            if (elementDetail.en.Equals(-1))
            {
                Array.Find(detailPanel.GetComponentsInChildren<Text>(), s => s.name.Equals("AtomEnText")).text = " En : NaN";
            }
            else
            {
                Array.Find(detailPanel.GetComponentsInChildren<Text>(), s => s.name.Equals("AtomEnText")).text = " En : " + elementDetail.en.ToString();
            }
        }
    }

    private void TurnOffOnClickAllAtom()
    {
        GameObject mainEditMolecule = GameObject.Find("MainMolecule");
        Transform[] atoms = mainEditMolecule.GetComponentsInChildren<Transform>();

        foreach (Transform atom in atoms)
        {
            if (atom.tag.Equals("Atom"))
            {
                AtomController atomControllerScript = atom.GetComponent<AtomController>();
                atomControllerScript.canClick = false;
            }

        }
    }

    private void CheckSpinAtom(bool canSpin)
    {
        if (canSpin)
        {      
            transform.RotateAround(rotateCenter, Vector3.up, 200 * Time.deltaTime);
        }
    }

    public void DestroyElectron()
    {
        Transform[] electrons = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform electron in electrons)
        {
            if (electron.tag.Equals("Electron"))
            {
                Destroy(electron.gameObject);
            }
        } 
    }

    private void GetPeriodicTableController()
    {
        periodicTableController = GameObject.Find("PeriodicTableController");
        if (periodicTableController != null)
        {
            periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
        }
    }
}
