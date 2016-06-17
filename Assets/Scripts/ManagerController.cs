using UnityEngine;
using System.Collections;

public class ManagerController : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(MainManager.Instance.gameObject);
    }
	
}
