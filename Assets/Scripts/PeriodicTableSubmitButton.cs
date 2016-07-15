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
        newAtom.transform.parent = periodicTableControllerScript.mainEditMolecule.transform;
        newAtom.name = elementPrefabInitiated.name;
        Destroy(atomTarget);
        periodicTableControllerScript.ClosePeriodicTable();
        periodicTableControllerScript.TurnOnOnClickAllAtom();
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
