using UnityEngine;
using System.Collections;
public class StickGroupController : MonoBehaviour {

    private GameObject bondPanelParent;
    private GameObject bondPanel;
    private BondPanelController bondPanelControllerScript;
    private bool canClick = false;

    void Start () {
        GetBondPanel();
    }

    private void GetBondPanel()
    {
        bondPanelParent = GameObject.Find("BondPanelParent");
        if (bondPanelParent != null)
        {
            canClick = true;
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
    }

    void OnMouseDown()
    {
        if (canClick)
        {
            Debug.Log("stickgroup is clicked");
            bondPanel.SetActive(true);
            bondPanelControllerScript.currentEditStickGroup = gameObject;
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if(!canClick)
        {
            Debug.Log("CanClick = false");
        }
        Debug.Log("gg");
    }

}
