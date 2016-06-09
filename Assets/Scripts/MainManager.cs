using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour
{

    private static MainManager _instance;
    public int axeNumber = 0;
    public string axeName = "AX2E0";

    //public GameObject ARCam;

    public static MainManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("_MainManager").AddComponent<MainManager>();
            }

            return _instance;
        }
    }

    public void Start()
    {
       // ARCam = GameObject.FindGameObjectWithTag("ARCam");
        //DontDestroyOnLoad(ARCam);
       // ARCam.SetActive(false);
    }
}
