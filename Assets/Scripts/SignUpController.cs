using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SocketIO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class SignUpController : MonoBehaviour
{
    public InputField usernameInputField;
    public InputField passwordInputField;
    public Button signUpBtn;
    public Button cancelBtn;

    public GameObject messageBoxPanel;
    private MessageBoxController messageBoxControllerScript;

    void Awake()
    {
        messageBoxControllerScript = messageBoxPanel.GetComponent<MessageBoxController>();
    }

    void Start()
    {
        SocketOn();
        signUpBtn.onClick.AddListener(() => OnClickSingUp());
        cancelBtn.onClick.AddListener(() => OnClickCancel());
    }

    private void SocketOn()
    {
        if (!NetworkManager.Instance.signUpSceneSocketIsOn)
        {
            NetworkManager.Instance.Socket.On("SIGNUP_READY", OnSignUpReady);
            NetworkManager.Instance.signUpSceneSocketIsOn = true;
        }
    }

    private void OnClickSingUp()
    {
        if (usernameInputField.text.Equals("") || passwordInputField.text.Equals(""))
        {
            Debug.Log("Please fill username & password");
            messageBoxControllerScript.ShowMessageBox("Please fill username & password");
        }
        else
        {
            JSONObject data = new JSONObject();
            data.AddField("username", usernameInputField.text);
            data.AddField("password", passwordInputField.text);
            NetworkManager.Instance.Socket.Emit("SIGNUP", data);
        }
        
    }

    private void OnSignUpReady(SocketIOEvent evt)
    {
        messageBoxPanel = GameObject.Find("MessageBoxPanel");
        messageBoxControllerScript = messageBoxPanel.GetComponent<MessageBoxController>();

        if (Convert.ToInt32(evt.data.GetField("status").ToString()).Equals(1))
        {
            messageBoxControllerScript.nextSceneName = "signin";
            messageBoxControllerScript.ShowMessageBox(Converter.JsonToString(evt.data.GetField("log").ToString()));
            
            //StartCoroutine(WaitMessageSuccessSignUp(1f));
        }
        else if (Convert.ToInt32(evt.data.GetField("status").ToString()).Equals(0))
        {
            Debug.Log(Converter.JsonToString(evt.data.GetField("log").ToString()));
            messageBoxControllerScript.ShowMessageBox(Converter.JsonToString(evt.data.GetField("log").ToString()));
        }
    }
    private void OnClickCancel()
    {
        SceneManager.LoadScene("signin");
    }

    //private IEnumerator WaitMessageSuccessSignUp(float time)
    //{
    //    float count = 0;
    //    while (count < time)
    //    {
    //        count += Time.deltaTime;
    //        // Debug.Log(Mathf.Floor(count));
    //        yield return new WaitForEndOfFrame();
    //    }
    //    SceneManager.LoadScene("signin");
    //}
}
