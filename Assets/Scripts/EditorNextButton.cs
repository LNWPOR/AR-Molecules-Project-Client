using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EditorNextButton : MonoBehaviour
{
    public void OnClickNextButton()
    {
        EditorManager.Instance.SetMainEditMolecule();
        EditorManager.Instance.SetEditMoleculeJSON();
        //SceneManager.LoadScene("save");
    }
}
