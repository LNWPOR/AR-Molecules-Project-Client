using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ElementButtonController : MonoBehaviour {

    private ElementData elementForButton;
    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;
    // Use this for initialization
    void Start()
    {
        GetPeriodicTableController();
        InitButtonElementInfo();
    }

    void Update()
    {
        ChangeColorDefault();
    }

    private void GetPeriodicTableController()
    {
        periodicTableController = GameObject.Find("PeriodicTableController");
        periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
    }

    private void InitButtonElementInfo()
    {
        if (PeriodicTableManager.Instance.periodicTableList.Exists(x => x.name.Equals(gameObject.name)))
        {
            elementForButton = PeriodicTableManager.Instance.periodicTableList.Find(x => x.name.Equals(gameObject.name));
            Array.Find(gameObject.GetComponentsInChildren<Text>(), s => s.name.Equals("NameText")).text = elementForButton.name;
            Array.Find(gameObject.GetComponentsInChildren<Text>(), s => s.name.Equals("NumberText")).text = elementForButton.atomNumber.ToString();
        }
    }

    private void ChangeColorDefault()
    {
        GameObject elementPrefabInitiated = periodicTableControllerScript.getElementPrefabInitiated();
        if (elementPrefabInitiated == null)
        {
            gameObject.GetComponent<Button>().image.color = Color.white;
        }
        if (elementPrefabInitiated != null && elementPrefabInitiated.name != gameObject.name)
        {
            gameObject.GetComponent<Button>().image.color = Color.white;
        }
    }

    public void OnClickElementButton()
    {
        gameObject.GetComponent<Button>().image.color = Color.blue;

        GameObject elementPrefabInitiated = periodicTableControllerScript.getElementPrefabInitiated();
        GameObject elementPrefabSelected = Array.Find(periodicTableControllerScript.getElementPrefabs(), s => s.name.Equals(elementForButton.name));
        if (elementPrefabSelected != null)
        {
            if (elementPrefabInitiated == null)
            {
                InstantiatePrefabSelected(elementPrefabSelected, elementForButton);
                elementPrefabInitiated = periodicTableControllerScript.getElementPrefabInitiated();
            }
            if (!elementPrefabInitiated.name.Equals(elementForButton.name))
            {
                Destroy(elementPrefabInitiated);
                InstantiatePrefabSelected(elementPrefabSelected, elementForButton);
            }
        }
        else
        {
            //Debug.Log("cant find prefab");
        }
    }

    private void InstantiatePrefabSelected(GameObject elementPrefabSelected, ElementData elementForButton)
    {
        GameObject newElementPrefabInitiated = Instantiate(elementPrefabSelected,
                                                new Vector3(-1f, 3.5f, 0f),
                                                Quaternion.identity) as GameObject;
        newElementPrefabInitiated.name = elementForButton.name;
        periodicTableControllerScript.setElementPrefabInitiated(newElementPrefabInitiated);
        periodicTableControllerScript.SetElementDetailPanelText(elementForButton);
    }
}
