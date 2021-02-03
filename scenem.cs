using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenem : MonoBehaviour {

    [SerializeField] private InputField m_username = null;
    [SerializeField] private InputField m_pass = null;
    [SerializeField] private InputField m_usernameinput = null;
    [SerializeField] private InputField m_emailinput = null;
    [SerializeField] private InputField m_password = null;
    [SerializeField] private InputField m_enterpass = null;
    [SerializeField] private Text m_errorText = null;
    [SerializeField] private GameObject m_register = null;
    [SerializeField] private GameObject m_login = null;
    public GameObject boton;
    public network1 m_network = null;
    private bool done;
    public float te = 5;

    private void Start()
    {
        boton.SetActive(true);
        te = 2;
    }
    
    private void Awake()
    {
        m_network = GameObject.FindObjectOfType<network1>();
    }
    public void SumbitRegister()
    {
       if(m_usernameinput.text == "" || m_emailinput.text == "" || m_password.text == "" || m_enterpass.text == "")
        {
            m_errorText.text = "Porfavor llena los campos";
            return;
        }
       if(m_password.text == m_enterpass.text)
        {
            m_errorText.text = "Processando Registrado con exito";
             
            m_network.Crearusu(m_usernameinput.text ,m_emailinput.text , m_password.text, m_enterpass.text, delegate(network1.Response response)
            {
                m_errorText.text = response.message;
                

            });
        }

        else
        {
            m_errorText.text = "Contraseña no son iguales";
        }
    }
    public void Sumbitlogin()
    {
        if (m_username.text == "" || m_pass.text == "" )
        {
            m_errorText.text = "Porfavor llena los campos";
            return;
        }
        
            

            m_network.Crearusur(m_username.text, m_pass.text, delegate (network1.Response response)
            {
                m_errorText.text = response.message;
                if (response.done == true)
                {
                    boton.SetActive(false);
                }
                else
                {
                    boton.SetActive(true);
                }
            });

       


    }
    public void ShowLogin()
    {
        m_register.SetActive(false);
        m_login.SetActive(true);

    }
    public void ShowRegister()
    {
        m_register.SetActive(true);
        m_login.SetActive(false);

    }
    public class Response
    {
        public bool done = false;
        public string message = "";
    }
}
