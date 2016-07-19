using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserNameText : MonoBehaviour {

    public Text userNameText;
    //private GameObject userManager;
    //private UserManager userManagerScript;


    void Awake()
    {
       //GetUserManager();
    }

	void Start () {
        userNameText.text = UserManager.Instance.userData.username;
	}

    //private void GetUserManager()
    //{
    //    userManager = GameObject.Find("UserManager");
    //    userManagerScript = userManager.GetComponent<UserManager>();
    //}

}
