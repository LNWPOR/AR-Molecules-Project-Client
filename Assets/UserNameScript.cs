using UnityEngine;
using System.Collections;

public class UserNameScript : MonoBehaviour {

    public GameObject signoutPanel;
    

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
        
    }


    public void CallSignOutPopup()
    {
        signoutPanel.SetActive(true);
    }
}
