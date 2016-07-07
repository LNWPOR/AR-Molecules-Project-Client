using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EditorNextButton : MonoBehaviour
{
    private GameObject mainEditMolecule;

    public void OnClickNextButton()
    {
        mainEditMolecule = GameObject.Find(EditorManager.Instance.AXEName);
        EditorManager.Instance.SetMainEditMolecule(mainEditMolecule);
        //SceneManager.LoadScene("save");
    }
}
