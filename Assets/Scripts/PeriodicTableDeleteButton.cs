using UnityEngine;
using System.Collections;

public class PeriodicTableDeleteButton : MonoBehaviour {

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;

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
        periodicTableControllerScript.TurnOnOnClickAllAtom();
    }
}
