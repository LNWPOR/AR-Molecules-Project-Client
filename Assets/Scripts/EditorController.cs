using UnityEngine;
using System.Collections;

public class EditorController : MonoBehaviour {

	void Awake()
    {
        DontDestroyOnLoad(EditorManager.Instance.gameObject);
        EditorManager.Instance.mainEditMolecule = GameObject.Find("MainMolecule");
    }
}
