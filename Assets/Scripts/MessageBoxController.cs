using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageBoxController : MonoBehaviour {

    public Button okButton;
    public Text messageText;
    void Start () {
        okButton.onClick.AddListener(() => OnClickOkButton());
        gameObject.SetActive(false);
    }

    public void OnClickOkButton()
    {
        messageText.text = "";
        gameObject.SetActive(false);
    }
	
}
