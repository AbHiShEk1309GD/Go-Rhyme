using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.EventSystems;

public class GetAPIData : MonoBehaviour
{
    string url;
    public InputField input;
    public TextMeshProUGUI text;
    public TextMeshProUGUI[] output;
    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }
    public void GetData() => StartCoroutine(GetData_Coroutine());
    public IEnumerator GetData_Coroutine()
    {
        url = "https://api.datamuse.com/words?rel_rhy=" + input.text;
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                output[1].text = request.error;
            }
            else
            {
                string jsonString = fixJson(request.downloadHandler.text);
                Rhyme[] rhyme = JsonHelper.FromJson<Rhyme>(jsonString);
                output[0].text = rhyme[0].word;
                output[1].text = rhyme[1].word;
                output[2].text = rhyme[2].word;
                output[3].text = rhyme[3].word;
                output[4].text = rhyme[4].word;
                

            }
        }
    }
    public void Text1()
    {
        text.text = null;
        text.text = input.text;
    }
    public void GetData2() => StartCoroutine(GetData_Coroutine2());
    public IEnumerator GetData_Coroutine2()
    {
        url = "https://api.datamuse.com/words?rel_rhy=" + EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                output[1].text = request.error;
            }
            else
            {
                string jsonString = fixJson(request.downloadHandler.text);
                Rhyme[] rhyme = JsonHelper.FromJson<Rhyme>(jsonString);
                output[0].text = rhyme[0].word;
                output[1].text = rhyme[1].word;
                output[2].text = rhyme[2].word;
                output[3].text = rhyme[3].word;
                output[4].text = rhyme[4].word;
            }
        }
    }
}   
