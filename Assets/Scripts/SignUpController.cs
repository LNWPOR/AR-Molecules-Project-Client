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

    void Awake()
    {
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
        if (Convert.ToInt32(evt.data.GetField("status").ToString()).Equals(1))
        {
            SceneManager.LoadScene("signin");
        }
        else if (Convert.ToInt32(evt.data.GetField("status").ToString()).Equals(0))
        {
            Debug.Log(Converter.JsonToString(evt.data.GetField("log").ToString()));
        }
    }
    private void OnClickCancel()
    {
        SceneManager.LoadScene("signin");
    }
}
