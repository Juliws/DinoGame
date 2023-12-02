using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class SubiryBajarInfo : MonoBehaviour
{
    string u;
    public TMP_Text user;

    void Start()
    {
        StartCoroutine(CorruitinaLeer(u));
    }


    void Update()
    {

    }


    private IEnumerator CorruitinaLeer(string res)
    {
        UnityWebRequest web = UnityWebRequest.Get("https://julivs.000webhostapp.com/Dino%20Game/respuesta.php" + res);
        yield return web.SendWebRequest();
        Debug.Log(web.downloadHandler.text);
        string usuario = (web.downloadHandler.text);
        user.text = usuario;
    }
}
