using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EditorTestButton : MonoBehaviour {

    //private GameObject editorManager;
    //private EditorManager editorManagerScript;

    private GameObject editorController;
    private EditorController editorControllerScript;

    void Awake()
    {
        //GetEditorManager();
        GetEditorController();

    }

    void Start()
    {
        
    }

    void Update()
    {
        TurnOnTestButton();
    }

    private void TurnOnTestButton()
    {
        if (editorControllerScript.canTest)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void OnClickTestButton()
    {
        EditorManager.Instance.SetEditMoleculeJSON();
        SceneManager.LoadScene("test");
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
