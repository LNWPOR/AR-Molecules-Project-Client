using UnityEngine;
using System.Collections;

public class PeriodicTableCloseButton : MonoBehaviour {

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;
    private string AXEName;

    void Awake()
    {
        AXEName = "AX2E0";
        GetPeriodicTableController();
    }

    void Start () {
        
	}

    private void TurnOnOnClickAllAtom()
    {
        GameObject mainEditMolecule = GameObject.Find(AXEName);
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
