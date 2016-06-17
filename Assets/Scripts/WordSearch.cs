using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WordSearch : MonoBehaviour
{
    //the inputfield your user is typing to
    public InputField inputField;
    public bool caseSensetive;
    public bool restrictUserInput;
    public Button newButtonPrefab;
    public Canvas menuCanvas;
    ArrayList possibleWords;
    private List<Button> newButtonList;
    private int maxNewButtonTotal = 5;

    void Start()
    {
        //DontDestroyOnLoad(MainManager.Instance.gameObject);
        inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        possibleWords = new ArrayList(MainManager.Instance.moleculeList.Count);
        newButtonList = new List<Button>();
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
        for (int i = 0; i < MainManager.Instance.moleculeList.Count; i++)
        {
            //Check if the words start matches the start from the input
            if (MainManager.Instance.moleculeList[i].name.StartsWith(inputField.text, !caseSensetive, null))
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
                new Vector3(menuCanvas.transform.position.x, menuCanvas.transform.position.y - 25f * i, menuCanvas.transform.position.z),
                Quaternion.identity) as Button;

                newButton.transform.parent = menuCanvas.transform;
                NewButtonController newButtonControllerScript = newButton.GetComponent<NewButtonController>();
                newButtonControllerScript.moleculeName = MainManager.Instance.moleculeList[(int)possibleWords[i]].name;
                //newButton.GetComponentsInChildren<Text>()[0].text = MainManager.Instance.moleculeList[(int)possibleWords[i]].name;
                newButtonList.Add(newButton);
            }
            
        }
    }
}