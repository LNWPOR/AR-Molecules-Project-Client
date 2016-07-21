using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class StickGroupController : MonoBehaviour {

    private GameObject bondPanelParent;
    private GameObject bondPanel;

    private Text username;
    private Button leftArrowButton;
    private Button rightArrowButton;
    private Button searchButton;
    private Button menuButton;

    private BondPanelController bondPanelControllerScript;
    private bool canClick = false;

    void Start () {
        GetBondPanel();
        GetSomeButtonAndUsername();
    }

    private void GetSomeButtonAndUsername()
    {
        username = GameObject.Find("Username").GetComponent<Text>();
        leftArrowButton = GameObject.Find("LeftArrowButton").GetComponent<Button>();
        rightArrowButton = GameObject.Find("RightArrowButton").GetComponent<Button>();
        searchButton = GameObject.Find("SearchButton").GetComponent<Button>();
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
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
        if (canClick && Input.touchCount.Equals(1))
        {
            bondPanel.SetActive(true);
            bondPanelControllerScript.currentEditStickGroup = gameObject;
            gameObject.transform.parent.gameObject.SetActive(false);
            SetButtonHideOrShow(false);
        }
    }

    private void SetButtonHideOrShow(bool setButton)
    {
        leftArrowButton.GetComponent<Button>().interactable = setButton;
        rightArrowButton.GetComponent<Button>().interactable = setButton;
        menuButton.GetComponent<Button>().interactable = setButton;
        searchButton.GetComponent<Button>().interactable = setButton;
        username.GetComponent<CapsuleCollider>().enabled = setButton;
    }

}
