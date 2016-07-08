using UnityEngine;
using System.Collections;

public class TestController : MonoBehaviour {

    private GameObject modelGenerator;
    private ModelGenerator modelGeneratorScript;

    void Awake()
    {
        modelGenerator = GameObject.Find("ModelGenerator");
        modelGeneratorScript = modelGenerator.GetComponent<ModelGenerator>();
    }

	void Start () {
        Debug.Log(EditorManager.Instance.mainEditMolecule);
        Transform[] moleculeChilds = EditorManager.Instance.mainEditMolecule.GetComponentsInChildren<Transform>();
        foreach (Transform moleculeChild in moleculeChilds)
        {
            if (moleculeChild.gameObject.tag.Equals("Atom"))
            {
                modelGeneratorScript.GenerateAtom(moleculeChild.gameObject.name,moleculeChild.position,moleculeChild.rotation);
            }
            else if (moleculeChild.gameObject.tag.Equals("StickGroup"))
            {
                modelGeneratorScript.GenerateStickGroup(moleculeChild.gameObject.name, moleculeChild.position, moleculeChild.rotation);
            }
        }
	}
}
