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
        periodicTableControllerScript.ClosePeriodicTable();
    }

    
}
