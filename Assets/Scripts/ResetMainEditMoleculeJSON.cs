using UnityEngine;
using System.Collections;

public class ResetMainEditMoleculeJSON : MonoBehaviour {

	public void ResetJSON()
    {
        if (EditorManager.Instance.mainEditMoleculeJSON != null)
        {
            EditorManager.Instance.mainEditMoleculeJSON = null;
        }
    }
}
