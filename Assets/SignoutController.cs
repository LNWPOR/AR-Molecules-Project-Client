using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignoutController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowSignOutPopup()
    {
        gameObject.SetActive(true);
    }
}
