using UnityEngine;
using System.Collections;

public class AtomController : MonoBehaviour
{

    private Vector3 rotateCenter;
    public bool canSpin;
    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;
    public bool canClick;

    void Awake()
    {
        rotateCenter = new Vector3(transform.position.x - 1f,
                                   transform.position.y,
                                   transform.position.z);
        canSpin = false;
        canClick = true;
        GetPeriodicTableController();
    }
    void Start()
    {
        
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
        GameObject mainEditMolecule = GameObject.Find(EditorManager.Instance.AXEName);
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
        periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
    }
}
