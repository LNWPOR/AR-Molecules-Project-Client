using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PeriodicTableSubmitButton : MonoBehaviour {

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;

    void Start () {
        GetPeriodicTableController();
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
        GameObject mainEditMolecule = GameObject.Find("MainEditMolecule");
        newAtom.transform.parent = mainEditMolecule.transform;
        newAtom.name = elementPrefabInitiated.name;
        Destroy(atomTarget);
        periodicTableControllerScript.ClosePeriodicTable();
    }

    
}
