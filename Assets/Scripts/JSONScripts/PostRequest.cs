using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace JSONScripts
{
    public class PostRequest : MonoBehaviour
    {
        void Start()
        {
            Player newPlayer = new Player { Name = "Taras", Age = 20, IsStudent = true };
            StartCoroutine(Post("apiUrl", newPlayer));
        }

        IEnumerator Post(string url, Player player)
        {
            string jsonData = JsonUtility.ToJson(player);

            using (UnityWebRequest webRequest = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonData);
                webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
                webRequest.downloadHandler = new DownloadHandlerBuffer();
                webRequest.SetRequestHeader("Content-Type", "application/json");

                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError(webRequest.error);
                }
                else
                {
                    string jsonResponse = webRequest.downloadHandler.text;
                    Debug.Log("Response: " + jsonResponse);
                }
            }
        }
    }
}

