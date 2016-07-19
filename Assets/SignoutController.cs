using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignoutController : MonoBehaviour {

    public Button CancelButton;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
    }
}
