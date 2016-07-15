using UnityEngine;
using System.Collections;

public class PeriodicTableDeleteButton : MonoBehaviour {

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;

    public GameObject mainEditMolecule;

    void Awake()
    {
        GetPeriodicTableController();
    }

    private void GetPeriodicTableController()
    {
        periodicTableController = GameObject.Find("PeriodicTableController");
        periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
    }

    public void OnClickDeleteButton()
    {
        Destroy(periodicTableControllerScript.GetAtomTarget());
        periodicTableControllerScript.ClosePeriodicTable();
        TurnOnOnClickAllAtom();
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
}
