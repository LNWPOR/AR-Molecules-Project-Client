using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SocketIO;
using System;

public class SaveSceneButton : MonoBehaviour
{
    public Button saveButton;
    public Button cancelButton;
    public InputField nameInputField;
    private bool isEmpty;
    public Text userNameText;

    void Start()
    {
        SocketOn();
        isEmpty = true;
        userNameText.text = UserManager.Instance.userData.username;
    }

    private void SocketOn()
    {
        if (!NetworkManager.Instance.saveSceneButtonSocketIsOn)
        {
            NetworkManager.Instance.Socket.On("SAVED", OnSaved);
            NetworkManager.Instance.saveSceneButtonSocketIsOn = true;
        }
    }

    void Update()
    {
        CheckInputFieldNotEmpty();
    }
    public void CheckInputFieldNotEmpty()
    {
        if(nameInputField.text.Length != 0)
        {
            isEmpty = false;
            Debug.Log("have a molecule name");
        }
    }

    public void OnClickSaveButton()
    {
        if (!isEmpty)
        {
            EditorManager.Instance.mainEditMoleculeJSON.AddField("name", nameInputField.text);
            EditorManager.Instance.mainEditMoleculeJSON.AddField("ownerID", UserManager.Instance.userData.id);
            NetworkManager.Instance.Socket.Emit("ADD_MOLECULE", EditorManager.Instance.mainEditMoleculeJSON);
        }
        else if(isEmpty)
        {
            nameInputField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "<b>  Please fill Molecule name!</b>";
            nameInputField.GetComponent<InputField>().placeholder.color = new Color(230F, 255F, 0F);
            Debug.Log("empty");
        }
    }

    public void OnClickCancelButton()
    {
        SceneManager.LoadScene("Editor");
    }


    private void OnSaved(SocketIOEvent evt)
    {
        if (Convert.ToInt32(evt.data.GetField("status").ToString()).Equals(1))
        {
            SceneManager.LoadScene("Test");
        }
        else if (Convert.ToInt32(evt.data.GetField("status").ToString()).Equals(0))
        {
            Debug.Log(Converter.JsonToString(evt.data.GetField("log").ToString()));
        }
    }
}
