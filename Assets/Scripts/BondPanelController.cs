using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BondPanelController : MonoBehaviour {

    public Button closeButton;
    // Use this for initialization

    void Start () {
        GetComponent<CanvasGroup>().alpha = 0f; 
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickCloseButton()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
    }
}
