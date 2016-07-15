using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EditorNextButton : MonoBehaviour
{
    // private GameObject editorManager;
    //private EditorManager editorManagerScript;

    private GameObject editorController;
    private EditorController editorControllerScript;

    void Awake()
    {
        // GetEditorManager();
        GetEditorController();
    }

    public void OnClickNextButton()
    {
        EditorManager.Instance.SetEditMoleculeJSON();
        SceneManager.LoadScene("save");
    }

    void Update()
    {
        TurnOnSaveButton();
    }

    private void TurnOnSaveButton()
    {
        if (editorControllerScript.canSave)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    private void GetEditorController()
    {
        editorController = GameObject.Find("EditorController");
        if (editorController != null)
        {
            editorControllerScript = editorController.GetComponent<EditorController>();
        }
    }

    //public void GetEditorManager()
    //{
    //    editorManager = GameObject.Find("EditorManager");
    //    if (editorManager != null)
    //    {
    //        editorManagerScript = editorManager.GetComponent<EditorManager>();
    //    }
    //}
}
