using UnityEngine;
using System.Collections;
public class StickGroupController : MonoBehaviour {

    private GameObject bondPanelParent;
    private GameObject bondPanel;
    private BondPanelController bondPanelControllerScript;

    void Start () {
        GetBondPanel();
    }

    private void GetBondPanel()
    {
        bondPanelParent = GameObject.Find("BondPanelParent");
        Transform bondPanelParentChilds = bondPanelParent.GetComponentInChildren<Transform>();
        foreach (Transform bondPanelParentChild in bondPanelParentChilds)
        {
            if (bondPanelParentChild.gameObject.name.Equals("BondPanel"))
            {
                bondPanel = bondPanelParentChild.gameObject;
                bondPanelControllerScript = bondPanel.GetComponent<BondPanelController>();
            }
        }
    }

    void OnMouseDown()
    {
        bondPanel.SetActive(true);
        bondPanelControllerScript.currentEditStickGroup = gameObject;
        gameObject.transform.parent.gameObject.SetActive(false);
    }

}
