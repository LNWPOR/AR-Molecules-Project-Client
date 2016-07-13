using UnityEngine;
using System.Collections;

public class MoleculeArrowRotate : MonoBehaviour {

    public string arrowDirection;
    private string AXEName;
    private bool buttonIsHold;
    public float rotateSpeed;
    public GameObject mainEditMolecule;

    void Awake()
    {
        buttonIsHold = false;
        rotateSpeed = 50f;
    }
    
    void Update()
    {
        if (buttonIsHold)
        {
            if (arrowDirection.Equals("Left"))
            {
                mainEditMolecule.transform.RotateAround(mainEditMolecule.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
            }
            else if (arrowDirection.Equals("Right"))
            {
                mainEditMolecule.transform.RotateAround(mainEditMolecule.transform.position, -Vector3.up, rotateSpeed * Time.deltaTime);
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
