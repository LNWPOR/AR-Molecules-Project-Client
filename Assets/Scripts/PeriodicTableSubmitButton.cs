using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PeriodicTableSubmitButton : MonoBehaviour {

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;

    private GameObject editorManager;
    private EditorManager editorManagerScript;

    void Awake()
    {
        GetPeriodicTableController();
        GetEditorManager();
    }
	
	void Update () {
        TurnOnSubmitButton();   
    }

    private void TurnOnOnClickAllAtom()
    {
        GameObject mainEditMolecule = GameObject.Find(editorManagerScript.AXEName);
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

    private void GetPeriodicTableController()
    {
        periodicTableController = GameObject.Find("PeriodicTableController");
        periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
    }

    private void TurnOnSubmitButton()
    {
        GameObject elementPrefabInitiated = periodicTableControllerScript.getElementPrefabInitiated();
        if (elementPrefabInitiated == null)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        if (elementPrefabInitiated != null)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void OnClickSubmitButton()
    {
        GameObject atomTarget = periodicTableControllerScript.GetAtomTarget();
        GameObject elementPrefabInitiated = periodicTableControllerScript.getElementPrefabInitiated();
        GameObject newAtom = Instantiate(elementPrefabInitiated,atomTarget.transform.position,Quaternion.identity) as GameObject;
        AtomController newAtomControllerScript = newAtom.GetComponent<AtomController>();
        newAtomControllerScript.DestroyElectron();
        newAtomControllerScript.canSpin = false;
        GameObject mainEditMolecule = GameObject.Find(editorManagerScript.AXEName);
        newAtom.transform.parent = mainEditMolecule.transform;
        newAtom.name = elementPrefabInitiated.name;
        Destroy(atomTarget);
        periodicTableControllerScript.ClosePeriodicTable();
        TurnOnOnClickAllAtom();
    }

    public void GetEditorManager()
    {
        editorManager = GameObject.Find("EditorManager");
        if (editorManager != null)
        {
            editorManagerScript = editorManager.GetComponent<EditorManager>();
        }
    }

}
