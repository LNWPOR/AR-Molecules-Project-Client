using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveSceneButton : MonoBehaviour
{

    public Button saveButton;
    public Button cancelButton;
    public InputField nameInputField;
    private bool isEmpty;
    // Use this for initialization
    void Start()
    {
        isEmpty = true;
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
    // Update is called once per frame
    public void OnClickSaveButton()
    {
        if (!isEmpty)
        {
            SceneManager.LoadScene("Test");
        }
    }

    public void OnClickCancelButton()  // may not use
    {
        SceneManager.LoadScene("Edit");
    }
}
