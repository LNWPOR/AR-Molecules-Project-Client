using UnityEngine;
using System.Collections;

public class PeriodicTableCloseButton : MonoBehaviour {

    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;

    void Start () {
        GetPeriodicTableController();
	}
	
	public void OnClickCloseButton()
    {
        periodicTableControllerScript.ClosePeriodicTable();
    }

    private void GetPeriodicTableController()
    {
        periodicTableController = GameObject.Find("PeriodicTableController");
        periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
    }

}
