using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{

    public GameObject imageTarget;
    public GameObject[] moleculePrefabs;
    private GameObject moleculeInstantiate;
    public Button homeBtn;
    public Text moleculeNameText;
    public Text axeNameText;

    void Awake()
    {
        homeBtn.onClick.AddListener(() => OnClickHome());
    }

    void Start()
    {
        InitMolecule();
        SetUIText();
    }

    private void OnClickHome()
    {
        SceneManager.LoadScene("menu");
    }

    private void InitMolecule()
    {
        moleculeInstantiate = Instantiate(moleculePrefabs[MainManager.Instance.axeNumber],
            new Vector3(transform.position.x, transform.position.y + 15f, transform.position.z),
            Quaternion.identity) as GameObject;
        moleculeInstantiate.name = moleculePrefabs[MainManager.Instance.axeNumber].name;
        moleculeInstantiate.transform.parent = imageTarget.transform;
    }

    private void SetUIText()
    {
        moleculeNameText.text = moleculeInstantiate.name;
        axeNameText.text = MainManager.Instance.axeName;
    }
}
