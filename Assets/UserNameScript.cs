using UnityEngine;
using System.Collections;

public class UserNameScript : MonoBehaviour {

    public GameObject signoutPanel;
    public GameObject mainEditMolecule;


    // Use this for initialization
    void Start () {
        signoutPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnMouseDown()
    {
        //Debug.Log("eiei");
        CallSignOutPopup();
        SetShowModel(false);

    }


    public void CallSignOutPopup()
    {
        signoutPanel.SetActive(true);
        
    }


    public void SetShowModel(bool isSet)
    {
        mainEditMolecule.SetActive(isSet);
    }
}
