using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InputOnClick : MonoBehaviour
{
    public InputField inputUser;
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject button1;
    public GameObject button2;
   

    private void Start()
    {
        first.SetActive(true);
        second.SetActive(false);
        third.SetActive(false);
        button1.SetActive(false);
        
    }
    public void Hide()
    {
        first.SetActive(false);
        second.SetActive(true);
        button2.SetActive(true);
        third.SetActive(false);
        button1.SetActive(false);
    }
    public void Show()
    {
        first.SetActive(true);
        second.SetActive(false);
        third.SetActive(false);
        inputUser.text = null;
        button1.SetActive(false);
    }
    public void definition()
    {
        first.SetActive(false);
        second.SetActive(false);
        third.SetActive(true);
        button1.SetActive(false);
    }
    public void DefinitionButton()
    {
        button1.SetActive(true);
        button2.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    
   
}
