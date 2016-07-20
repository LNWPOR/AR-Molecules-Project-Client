using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageBoxController : MonoBehaviour {

    public Button okButton;
    public Text messageText;
    public string nextSceneName;

    public Vector2 showPosition;
    public Vector2 hidePosition;
    
    void Awake()
    {
        nextSceneName = "";
        showPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
        hidePosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, 5000f);
        okButton.onClick.AddListener(() => OnClickOkButton());
    }

    void Start () {
        GetComponent<RectTransform>().anchoredPosition = hidePosition;
    }

    public void OnClickOkButton()
    {
        HideMessageBox();

        if (!nextSceneName.Equals(""))
        {
            string nextSceneNameTemp = nextSceneName;
            nextSceneName = "";
            SceneManager.LoadScene(nextSceneNameTemp);
        }
    }

    public void ShowMessageBox(string message)
    {
        messageText.text = message;
        GetComponent<RectTransform>().anchoredPosition = showPosition;
    }

    public void HideMessageBox()
    {
        messageText.text = "";
        GetComponent<RectTransform>().anchoredPosition = hidePosition;
    }
	
}
