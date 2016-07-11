using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EditorNextButton : MonoBehaviour
{
    private GameObject editorManager;
    private EditorManager editorManagerScript;

    void Awake()
    {
        GetEditorManager();
    }

    public void OnClickNextButton()
    {
        editorManagerScript.SetMainEditMolecule();
        editorManagerScript.SetEditMoleculeJSON();
        SceneManager.LoadScene("save");
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
