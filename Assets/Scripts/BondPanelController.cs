using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BondPanelController : MonoBehaviour {

    public Button closeButton;
    public Button singleBondButton;
    public Button doubleBondButton;
    public Button trippleBondButton;
    public Button lonePairButton;
    public Button delButton;
    public GameObject currentEditStickGroup;

    void Awake()
    {
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(() => OnClickCloseButton());
        singleBondButton.onClick.AddListener(() => SetStickGroup("Stick1"));
        doubleBondButton.onClick.AddListener(() => SetStickGroup("Stick2"));
        trippleBondButton.onClick.AddListener(() => SetStickGroup("Stick3"));
        lonePairButton.onClick.AddListener(() => SetStickGroup("Electron2"));
        delButton.onClick.AddListener(() => SetStickGroup("del"));
    }

    public void OnClickCloseButton()
    {
        CloseBondPanel();
    }
    
    public void SetStickGroup(string stickActiveName)
    {
        Transform[] stickGroupChilds = currentEditStickGroup.GetComponentsInChildren<Transform>(true);
        if (stickActiveName.Equals("del"))
        {
            Destroy(currentEditStickGroup);
        }
        else
        {
            foreach (Transform stickGroupChild in stickGroupChilds)
            {
                if (stickGroupChild.gameObject.tag.Equals("Bond") || stickGroupChild.gameObject.tag.Equals("Lone"))
                {
                    if (stickGroupChild.gameObject.name.Equals(stickActiveName))
                    {
                        stickGroupChild.gameObject.SetActive(true);
                    }
                    else
                    {
                        stickGroupChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        CloseBondPanel();
    }

    private void CloseBondPanel()
    {
        gameObject.SetActive(false);
        currentEditStickGroup.transform.parent.gameObject.SetActive(true);
    }

}
