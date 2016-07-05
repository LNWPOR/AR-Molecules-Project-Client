using UnityEngine;
using System.Collections;

public class MoleculeArrowRotate : MonoBehaviour {

    public string arrowDirection;
    private string AXEName;
    private GameObject moleculeTarget;
    private bool buttonIsHold;
    public float rotateSpeed;

    void Awake()
    {
        AXEName = "AX2E0";
        moleculeTarget = GameObject.Find(AXEName);
        buttonIsHold = false;
        rotateSpeed = 50f;
    }
    
    void Update()
    {
        if (buttonIsHold)
        {
            if (arrowDirection.Equals("Left"))
            {
                moleculeTarget.transform.RotateAround(moleculeTarget.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
            }
            else if (arrowDirection.Equals("Right"))
            {
                moleculeTarget.transform.RotateAround(moleculeTarget.transform.position, -Vector3.up, rotateSpeed * Time.deltaTime);
            }
        }
    }

    public void OnPointerDownButton()
    {
        buttonIsHold = true;
    }
    public void OnPointerUpButton()
    {
        buttonIsHold = false;
    }
}
