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

    public Text userNameText;
    //private GameObject userManager;
    //private UserManager userManagerScript;

    //private GameObject editorManager;
    //private EditorManager editorManagerScript;

    //private GameObject networkManager;
    //private NetworkManager networkManagerScript;

    void Awake()
    {
        //GetNetworkManager();
        //GetUserManager();
        //GetEditorManager();
    }

    //private void GetNetworkManager()
    //{
    //    networkManager = GameObject.Find("NetworkManager");
    //    networkManagerScript = networkManager.GetComponent<NetworkManager>();
    //}

    void Start()
    {
        isEmpty = true;
        userNameText.text = UserManager.Instance.userData.username;
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
            EditorManager.Instance.mainEditMoleculeJSON.AddField("name", nameInputField.text);
            EditorManager.Instance.mainEditMoleculeJSON.AddField("ownerID", UserManager.Instance.userData.id);
            NetworkManager.Instance.Socket.Emit("ADD_MOLECULE", EditorManager.Instance.mainEditMoleculeJSON);
            SceneManager.LoadScene("Test");
        }
    }

    public void OnClickCancelButton()  // may not use
    {
        SceneManager.LoadScene("Editor");
    }

    //private void GetUserManager()
    //{
    //    userManager = GameObject.Find("UserManager");
    //    userManagerScript = userManager.GetComponent<UserManager>();
    //}

    //public void GetEditorManager()
    //{
    //    editorManager = GameObject.Find("EditorManager");
    //    if (editorManager != null)
    //    {
    //        editorManagerScript = editorManager.GetComponent<EditorManager>();
    //    }
    //}
}
