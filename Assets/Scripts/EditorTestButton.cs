using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EditorTestButton : MonoBehaviour {

    public void OnClickTestButton()
    {
        EditorManager.Instance.SetMainEditMolecule();
        SceneManager.LoadScene("test");
    }

}
