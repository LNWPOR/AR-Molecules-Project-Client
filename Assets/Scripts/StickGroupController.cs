using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class StickGroupController : MonoBehaviour {

    private GameObject bondPanelParent;
    private GameObject bondPanel;
    private Text username;
    private BondPanelController bondPanelControllerScript;
    private bool canClick = false;

    void Start () {
        GetBondPanel();
        GetUsername();
    }

    private void GetUsername()
    {
        username = GameObject.Find("Username").GetComponent<Text>();
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
            bondPanel.SetActive(true);
            bondPanelControllerScript.currentEditStickGroup = gameObject;
            gameObject.transform.parent.gameObject.SetActive(false);
            username.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

}
