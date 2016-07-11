using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserManager : MonoBehaviour {
	public  UserData userData;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
