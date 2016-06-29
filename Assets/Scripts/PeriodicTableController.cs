using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PeriodicTableController : MonoBehaviour {

    public Transform periodicTablePanel;
    public GameObject[] elementPrefabs;
    private GameObject elementPrefabInitiated;

    void Start () {
        initElementButton();
    }

    private void initElementButton()
    {
        Transform[] groups = periodicTablePanel.GetComponentsInChildren<Transform>();
        for (int i = 0; i < groups.Length; i++)
        {
            Button[] elementButtons = groups[i].GetComponentsInChildren<Button>();
            for (int j = 0; j < elementButtons.Length; j++)
            {
                //Debug.Log(elementButtons[j].name);
                if (PeriodicTableManager.Instance.periodicTableList.Exists(x => x.name.Equals(elementButtons[j].name)))
                {
                    ElementData elementForButton = PeriodicTableManager.Instance.periodicTableList.Find(x => x.name.Equals(elementButtons[j].name));
                    Array.Find(elementButtons[j].GetComponentsInChildren<Text>(), s => s.name.Equals("NameText")).text = elementForButton.name;
                    Array.Find(elementButtons[j].GetComponentsInChildren<Text>(), s => s.name.Equals("NumberText")).text = elementForButton.atomNumber.ToString();
                    elementButtons[j].onClick.AddListener(() => OnClickElementBtn(elementForButton));
                }
            }
        }
    }

    private void OnClickElementBtn(ElementData elementForButton)
    {
        //Debug.Log(elementForButton.name);
        GameObject elementPrefabSelected = Array.Find(elementPrefabs, s => s.name.Equals(elementForButton.name));
        if (elementPrefabSelected != null)
        {
            if (elementPrefabInitiated == null)
            {
                InstantiatePrefabSelected(elementPrefabSelected, elementForButton);
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
        elementPrefabInitiated = Instantiate(elementPrefabSelected,
                                                new Vector3(-2f, 3.5f, 0f),
                                                Quaternion.identity) as GameObject;
        elementPrefabInitiated.name = elementForButton.name;
    }
}
