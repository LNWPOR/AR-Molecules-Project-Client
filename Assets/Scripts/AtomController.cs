using UnityEngine;
using System.Collections;

public class AtomController : MonoBehaviour
{

    private Vector3 rotateCenter;
    public bool canDestroyElectron;
    // Use this for initialization
    void Start()
    {
        rotateCenter = new Vector3(transform.position.x - 1f,
                                   transform.position.y,
                                   transform.position.z);
        canDestroyElectron = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotateCenter, Vector3.up, 200 * Time.deltaTime);
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        Destroy(this.gameObject);
    }

    public void OnTriggerStay(Collider other)
    {
        if (canDestroyElectron && other.gameObject.tag.Equals("Electron"))
        {
            Destroy(other.gameObject);
        }
    }
}
