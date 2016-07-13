using UnityEngine;
using System.Collections;

public class AtomController : MonoBehaviour
{

    private Vector3 rotateCenter;
    public bool canSpin;
    public bool canClick;

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;

    private GameObject editorManager;
    private EditorManager editorManagerScript;


    void Awake()
    {
        rotateCenter = new Vector3(transform.position.x - 1f,
                                   transform.position.y,
                                   transform.position.z);
        canSpin = false;
        canClick = true;
        GetPeriodicTableController();
        GetEditorManager();
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
        if (canClick)
        {
            TurnOffOnClickAllAtom();
            periodicTableControllerScript.OpenPeriodicTable();
            periodicTableControllerScript.SetAtomTarget(gameObject);
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
