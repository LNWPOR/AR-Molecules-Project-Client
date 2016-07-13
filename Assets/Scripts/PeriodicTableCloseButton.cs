using UnityEngine;
using System.Collections;

public class PeriodicTableCloseButton : MonoBehaviour {

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;

    private GameObject editorManager;
    private EditorManager editorManagerScript;

    public GameObject mainEditMolecule;

    void Awake()
    {
        GetPeriodicTableController();
        GetEditorManager();
    }

    void Start () {
        
	}

    public void GetEditorManager()
    {
        editorManager = GameObject.Find("EditorManager");
        if (editorManager != null)
        {
            editorManagerScript = editorManager.GetComponent<EditorManager>();
        }
    }

    private void TurnOnOnClickAllAtom()
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

    public void OnClickCloseButton()
    {
        periodicTableControllerScript.ClosePeriodicTable();
        TurnOnOnClickAllAtom();
    }

    private void GetPeriodicTableController()
    {
        periodicTableController = GameObject.Find("PeriodicTableController");
        periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
    }

}
