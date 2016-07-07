using UnityEngine;
using System.Collections;

public class ManagerController : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(NetworkManager.Instance.gameObject);
        DontDestroyOnLoad(NetworkManager.Instance.Socket);
        DontDestroyOnLoad(UserManager.Instance.gameObject);
        DontDestroyOnLoad(MainManager.Instance.gameObject);
        DontDestroyOnLoad(PeriodicTableManager.Instance.gameObject);
        DontDestroyOnLoad(EditorManager.Instance.gameObject);
    }
	
}
