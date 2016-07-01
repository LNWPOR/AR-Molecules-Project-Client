using UnityEngine;
using System.Collections;

public class AtomController : MonoBehaviour
{

    private Vector3 rotateCenter;
    public bool canDestroyElectron;
    public bool canSpin;
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
        canDestroyElectron = false;
        canSpin = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpinAtom();
    }

    void OnMouseDown()
    {
        periodicTableControllerScript.OpenPeriodicTable();
    }

    private void CheckSpinAtom()
    {
        if (canSpin)
        {
            transform.RotateAround(rotateCenter, Vector3.up, 200 * Time.deltaTime);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (canDestroyElectron && other.gameObject.tag.Equals("Electron"))
        {
            Destroy(other.gameObject);
        }
    }

    private void GetPeriodicTableController()
    {
        periodicTableController = GameObject.Find("PeriodicTableController");
        periodicTableControllerScript = periodicTableController.GetComponent<PeriodicTableController>();
    }
}
