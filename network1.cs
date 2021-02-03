using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;

public class network1 : MonoBehaviour {

    // Use this for initialization
    public void Crearusu(string user, string email, string pass, string repass, Action<Response> response)
    {
        StartCoroutine(CO_Createuser(user, email, pass, repass, response));
    }
    public IEnumerator CO_Createuser(string user, string email, string pass, string repass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("email", email);
        form.AddField("pass", pass);
        form.AddField("repass", repass);

        WWW w = new WWW("http://localhost:80/Game/createuser.php", form);

        yield return w;
        Debug.Log(w.text);
        response(JsonUtility.FromJson<Response>(w.text));
    }

    // Use this for initialization
    public void Crearusur(string user, string pass, Action<Response> response)
    {
        StartCoroutine(CO_Crearusur(user,  pass, response));
    }
    public IEnumerator CO_Crearusur(string user, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("pass", pass);

        WWW w = new WWW("http://localhost:80/Game/checkuser.php", form);

        yield return w;
        Debug.Log(w.text);
        response(JsonUtility.FromJson<Response>(w.text));

        
    }

    public class Response
    {

        public bool done = false;
        public string message = "";
    }
}
