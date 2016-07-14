using UnityEngine;
using System.Collections;

public class AXEButton : MonoBehaviour {

	public GameObject mainEditMolecule;
    public Transform axePrefab;

    private GameObject hamburgerButton;
    private HamburgerButton hamburgerButtonScript;

    private bool hide = true;


    void Start () {
        GetHamburgerButton();
    }

    private void GetHamburgerButton()
    {
        hamburgerButton = GameObject.Find("MenuButton"); // Fine (Object in hierarchy)
        if (hamburgerButton != null)
        {
            hamburgerButtonScript = hamburgerButton.GetComponent<HamburgerButton>();
        }
    }

    public void OnClickAXEButton()
    {
        DestroyMainEditMoleculeChilds();
        AddMainEditMoleculeChilds();
        hamburgerButtonScript.PopUpPanelSlide(hide);
    }

    private void DestroyMainEditMoleculeChilds()
    {
        Transform[] mainEditMoleculeChilds = mainEditMolecule.GetComponentsInChildren<Transform>();
        foreach (Transform mainEditMoleculeChild in mainEditMoleculeChilds)
        {
            if (mainEditMoleculeChild.gameObject.tag.Equals("Atom") || mainEditMoleculeChild.gameObject.tag.Equals("StickGroup"))
            {
                Destroy(mainEditMoleculeChild.gameObject);
            }
        }
    }

    private void AddMainEditMoleculeChilds()
    {
        Transform[] axePrefabChilds = axePrefab.GetComponentsInChildren<Transform>();
        foreach (Transform axePrefabChild in axePrefabChilds)
        {
            if (axePrefabChild.gameObject.tag.Equals("Atom") || axePrefabChild.gameObject.tag.Equals("StickGroup"))
            {
                GameObject axePrefabChildGenerated = Instantiate(
                    axePrefabChild.gameObject,
                    axePrefabChild.transform.position,
                    Quaternion.Euler(new Vector3(axePrefabChild.eulerAngles.x,
                                                 axePrefabChild.eulerAngles.y,
                                                 axePrefabChild.eulerAngles.z))) as GameObject;
                axePrefabChildGenerated.transform.parent = mainEditMolecule.transform;
                axePrefabChildGenerated.name = axePrefabChild.gameObject.name;
            }
        }
    }
   
}
