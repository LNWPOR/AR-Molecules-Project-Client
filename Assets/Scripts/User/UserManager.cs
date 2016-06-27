using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserManager : MonoBehaviour {

	private static UserManager 		_instance;
	public 			UserData 			userData;

	public static UserManager Instance{
		get{
			if(_instance == null ){
				_instance = new GameObject("_UserManager").AddComponent<UserManager>();
			}
			return _instance;
		}
	}

}
