using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace JSONScripts
{
    public class GetRequest : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(Get("apiUrl"));
        }

        IEnumerator Get(string url)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError(webRequest.error);
                }
                else
                {
                    string jsonResponse = webRequest.downloadHandler.text;
                    Debug.Log("Response: " + jsonResponse);

                    Player player = JsonUtility.FromJson<Player>(jsonResponse);
                    Debug.Log("Name: " + player.Name);
                    Debug.Log("Age: " + player.Age);
                    Debug.Log("Is Student: " + player.IsStudent);
                }
            }
        }
    }
}

