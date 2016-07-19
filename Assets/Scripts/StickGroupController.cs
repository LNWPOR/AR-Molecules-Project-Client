using UnityEngine;
using System.Collections;
public class StickGroupController : MonoBehaviour {

    private GameObject bondPanelParent;
    private GameObject bondPanel;

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
            }
        }
    }

    void OnMouseDown()
    {
        bondPanel.SetActive(true);
        gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.position.x,
                                                            gameObject.transform.parent.position.y,
                                                            gameObject.transform.parent.position.z + 100f);
    }

}
