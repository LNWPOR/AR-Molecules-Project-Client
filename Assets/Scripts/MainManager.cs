using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

    private static MainManager _instance;
    public int axeNumber;

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
}
