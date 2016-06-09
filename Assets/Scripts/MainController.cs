using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour
{

    public GameObject imageTarget;
    public GameObject[] moleculePrefabs;
    private GameObject moleculeInstantiate;

    void Awake()
    {
        //imageTarget = GameObject.FindGameObjectWithTag("ImageTarget");
    }


    void Start()
    {
        //for (int i = 0; i < moleculePrefabs.Length; i++)
        //{
        //   if (i != MainManager.Instance.axeNumber)
        //  {
        //     moleculePrefabs[i].SetActive(false);
        //}
        //}
        //moleculePrefabs[MainManager.Instance.axeNumber].SetActive(true);
        //Debug.Log(MainManager.Instance.axeNumber);

        
        moleculeInstantiate = Instantiate(moleculePrefabs[MainManager.Instance.axeNumber], transform.position, Quaternion.identity) as GameObject;
        moleculeInstantiate.transform.parent = imageTarget.transform;
        //MainManager.Instance.ARCam.SetActive(true);
    }

    public void Update()
    {

    }
}
