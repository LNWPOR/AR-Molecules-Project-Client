using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PeriodicTableController : MonoBehaviour {

    public Transform periodicTablePanel;
    //private Button[] elementButtons;

	// Use this for initialization
	void Start () {
        Transform[] groups = periodicTablePanel.GetComponentsInChildren<Transform>();
        for (int i = 0; i < groups.Length;i++)
        {
            Button[] elementButtons = groups[i].GetComponentsInChildren<Button>();
            for (int j = 0; j < elementButtons.Length;j++)
            {
                //Debug.Log(elementButtons[j].name);
                if (PeriodicTableManager.Instance.periodicTableList.Exists(x => x.name.Contains(elementButtons[j].name)))
                {
                    ElementData elementForButton = PeriodicTableManager.Instance.periodicTableList.Find(x => x.name.Contains(elementButtons[j].name));
                    Array.Find(elementButtons[j].GetComponentsInChildren<Text>(), s => s.name.Equals("NameText")).text = elementForButton.name;
                    Array.Find(elementButtons[j].GetComponentsInChildren<Text>(), s => s.name.Equals("NumberText")).text = elementForButton.atomNumber.ToString();
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
