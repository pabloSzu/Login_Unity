using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;


public class networkManager : MonoBehaviour
{
    public void createUser(string userName, string email, string pass, Action<Response> response) 
    {
        StartCoroutine(CO_createUser(userName, email, pass, response));
    }

    private IEnumerator CO_createUser(string userName, string email, string pass, Action<Response> response) 
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("email", email);
        form.AddField("pass", pass);
        Debug.Log(userName);
        WWW w = new WWW("http://localhost/Game/createuser.php", form);

        yield return w;

//        response(JsonUtility.FromJson<Response>(w.text));

    }



    public void CheckUser(string userName, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CheckUser(userName, pass, response));
    }

    private IEnumerator CO_CheckUser(string userName, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("pass", pass);

        WWW w = new WWW("http://localhost/Game/checkuser.php", form);

      
        yield return w;

    }


    public class Response 
{
    public bool done = false;
    public string message = "";
}





}




