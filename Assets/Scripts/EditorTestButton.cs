using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EditorTestButton : MonoBehaviour {

    public void OnClickTestButton()
    {
        EditorManager.Instance.SetMainEditMolecule();
        Debug.Log(EditorManager.Instance.mainEditMolecule);
        SceneManager.LoadScene("test");
    }

}
