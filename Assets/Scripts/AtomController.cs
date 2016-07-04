using UnityEngine;
using System.Collections;

public class AtomController : MonoBehaviour
{

    private Vector3 rotateCenter;
    public bool canSpin = false;
    private GameObject periodicTableController;
    private PeriodicTableController periodicTableControllerScript;
    void Awake()
    {
        GetPeriodicTableController();
    }
    // Use this for initialization
    void Start()
    {
        rotateCenter = new Vector3(transform.position.x - 1f,
                                   transform.position.y,
                                   transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpinAtom(canSpin);
    }

    void OnMouseDown()
    {
        periodicTableControllerScript.OpenPeriodicTable();
        periodicTableControllerScript.SetAtomTarget(gameObject);
    }

    private void CheckSpinAtom(bool canSpin)
    {
        if (canSpin)
        {      
            transform.RotateAround(rotateCenter, Vector3.up, 200 * Time.deltaTime);
        }
    }

    public void DestroyElectron()
    {
        Transform[] electrons = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform electron in electrons)
        {
            if (electron.tag.Equals("Electron"))
            {
                Destroy(electron.gameObject);
            }
        } 
    }

    private void GetPeriodicTableController()
    {
        periodicTableController = GameObject.Find("PeriodicTableController");
        periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
    }
}
