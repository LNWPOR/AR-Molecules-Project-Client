using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EditorTestButton : MonoBehaviour {

    private GameObject editorManager;
    private EditorManager editorManagerScript;

    void Awake()
    {
        GetEditorManager();
    }

    public void OnClickTestButton()
    {
        editorManagerScript.SetMainEditMolecule();
        editorManagerScript.SetEditMoleculeJSON();
        SceneManager.LoadScene("test");
    }

    public void GetEditorManager()
    {
        editorManager = GameObject.Find("EditorManager");
        if (editorManager != null)
        {
            editorManagerScript = editorManager.GetComponent<EditorManager>();
        }
    }
}
