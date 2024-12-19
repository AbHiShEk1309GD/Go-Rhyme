using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.EventSystems;
public class DefinitionAPI : MonoBehaviour
{
    string url;
    public InputField input;
    public TextMeshProUGUI[] definitionText;
    public TextMeshProUGUI text;
    public void Text2()
    {
        text.text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }
    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    public void GetDefinition() => StartCoroutine(GetDefinition_Coroutine());
    public IEnumerator GetDefinition_Coroutine()
    {
        url = "https://api.dictionaryapi.dev/api/v2/entries/en/"+input.text;
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string jsonString = fixJson(request.downloadHandler.text);
                Dictionary[] definitions1 = JsonHelper.FromJson<Dictionary>(jsonString);
                definitionText[0].text = definitions1[0].meanings[0].definitions[0].definition;
            }
        }
    }
    
    public void GetDefinition2() => StartCoroutine(GetDefinition_Coroutine2());
    public IEnumerator GetDefinition_Coroutine2()
    {
        url = "https://api.dictionaryapi.dev/api/v2/entries/en/"+ text.text;
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string jsonString = fixJson(request.downloadHandler.text);
                Dictionary[] definitions1 = JsonHelper.FromJson<Dictionary>(jsonString);
                definitionText[0].text = definitions1[0].meanings[0].definitions[0].definition;
            }
        }
    }

}