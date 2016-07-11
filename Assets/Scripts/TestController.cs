using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestController : MonoBehaviour {
    public GameObject moleculeImageTarget;

    private GameObject editorManager;
    private EditorManager editorManagerScript;

    public GameObject mainMolecule;

    void Awake()
    {
        GetEditorManager();
    }

    void Start()
    {
        mainMolecule.name = editorManagerScript.AXEName;

        //Debug.Log(editorManagerScript.mainEditMoleculeJSON);
        
        //editorManagerScript.mainEditMolecule.transform.position = new Vector3(
        //    editorManagerScript.mainEditMolecule.transform.position.x,
        //    editorManagerScript.mainEditMolecule.transform.position.y + 15f,
        //    editorManagerScript.mainEditMolecule.transform.position.z);
        //editorManagerScript.mainEditMolecule.transform.parent = moleculeImageTarget.transform; 
    }

    public void OnClickBackButton()
    {
        //editorManagerScript.mainEditMolecule.transform.parent = null;
        //DontDestroyOnLoad(editorManagerScript.mainEditMolecule);
        SceneManager.LoadScene("lnwpor_test");
    }

    public void OnClickSearchButton()
    {
        SceneManager.LoadScene("menu");
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
