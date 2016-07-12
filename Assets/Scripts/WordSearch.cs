using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using SocketIO;

public class WordSearch : MonoBehaviour
{
    //the inputfield your user is typing to
    public InputField inputField;
    public bool caseSensetive;
    public bool restrictUserInput;
    public Button newButtonPrefab;
    public GameObject menuPanel;
    ArrayList possibleWords;
    private List<Button> newButtonList;
    private int maxNewButtonTotal = 5;

    private GameObject mainManager;
    private MainManager mainManagerScript;

    private GameObject networkManager;
    private NetworkManager networkManagerScript;

    void Awake()
    {
        GetNetworkManager();
        GetMainManager();
    }

    private void GetNetworkManager()
    {
        networkManager = GameObject.Find("NetworkManager");
        networkManagerScript = networkManager.GetComponent<NetworkManager>();
    }

    void Start()
    {
        SocketOn();
        inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        possibleWords = new ArrayList(mainManagerScript.moleculeList.Count);
        newButtonList = new List<Button>();
        StartCoroutine(WaitToEmitGetMainEditMoleculeJSON(1f));
    }

    private void SocketOn()
    {
        networkManagerScript.Socket.On("GET_All_mainEditMoleculeJSON", SetmoleculeList);
    }

    private void SetmoleculeList(SocketIOEvent evt)
    {
        Debug.Log(evt.data[0]) ;
        //mainManagerScript.AllMoleculesJSON = evt.data;
    }

    private IEnumerator WaitToEmitGetMainEditMoleculeJSON(float time)
    {
        float count = 0;
        while (count < time)
        {
            count += Time.deltaTime;
            // Debug.Log(Mathf.Floor(count));
            yield return new WaitForEndOfFrame();
        }
        networkManagerScript.Socket.Emit("GET_All_mainEditMoleculeJSON");
    }

    private void GetMainManager()
    {
        mainManager = GameObject.Find("MainManager");
        mainManagerScript = mainManager.GetComponent<MainManager>();
    }

    void ValueChangeCheck()
    {

        for (int i = 0; i < newButtonList.Count; i++)
        {
            //Debug.Log("name : " + newButtonList[i]);
            newButtonList[i].enabled = false;
            Destroy(newButtonList[i].gameObject);
        }
        newButtonList.Clear();
        

        possibleWords.Clear();
        //Go through all words in your databas (could be slow with many words)
        for (int i = 0; i < mainManagerScript.moleculeList.Count; i++)
        {
            //Check if the words start matches the start from the input
            if (mainManagerScript.moleculeList[i].name.StartsWith(inputField.text, !caseSensetive, null))
            {    //Not add possible words if the InputField is empty 
                if (inputField.text != "")
                {
                    possibleWords.Add(i);
                }  
            }
        }
        if (possibleWords.Count == 0 && restrictUserInput)
            inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);
        // Iterate through all possible words
        for (int i = 0; i < possibleWords.Count; i++)
        {
            //Debug.Log(MainManager.Instance.moleculeList[(int)possibleWords[i]].name); // do something with the word
            //may display it

            if (newButtonList.Count <= maxNewButtonTotal)
            {
                Button newButton = Instantiate(newButtonPrefab,
                new Vector3(inputField.transform.position.x, inputField.transform.position.y - 9.625f - (9.625f * i), inputField.transform.position.z),
                Quaternion.identity) as Button;

                newButton.transform.parent = menuPanel.transform;
                newButton.transform.localScale = new Vector3(1f, 1f, 1f);
                NewButtonController newButtonControllerScript = newButton.GetComponent<NewButtonController>();
                newButtonControllerScript.moleculeName = mainManagerScript.moleculeList[(int)possibleWords[i]].name;
                //newButton.GetComponentsInChildren<Text>()[0].text = MainManager.Instance.moleculeList[(int)possibleWords[i]].name;
                newButtonList.Add(newButton);
            }
            
        }
    }
}