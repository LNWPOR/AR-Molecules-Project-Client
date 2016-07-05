using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ElementButtonController : MonoBehaviour {

    private ElementData elementForButton;
    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;
    private Button elementButton;
    private ColorBlock startCB;
    
    void Awake()
    {
        InitButtonColor();
        InitButtonElementInfo();
    }
    void Start()
    {
        GetPeriodicTableController();    
    }

    void Update()
    {
        ChangeColorDefault();
    }

    private void InitButtonColor()
    {
        elementButton = gameObject.GetComponent<Button>();
        startCB = elementButton.colors;
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
            ColorBlock cb = elementButton.colors;
            cb.normalColor = startCB.normalColor;
        }
        if (elementPrefabInitiated != null && elementPrefabInitiated.name != gameObject.name)
        {
            ColorBlock cb = elementButton.colors;
            cb.normalColor = startCB.normalColor;
        }
    }

    public void OnClickElementButton()
    {
        ColorBlock cb = elementButton.colors;
        cb.normalColor = startCB.highlightedColor;

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
        AtomController newElementControllerScript = newElementPrefabInitiated.GetComponent<AtomController>();
        newElementControllerScript.canSpin = true;
        newElementPrefabInitiated.name = elementForButton.name;
        periodicTableControllerScript.SetElementPrefabInitiated(newElementPrefabInitiated);
        periodicTableControllerScript.SetElementDetailPanelText(elementForButton);
    }
}
