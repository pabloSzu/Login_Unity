using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMananger : MonoBehaviour
{
   [Header("Login")]
   [SerializeField] private InputField m_LoginPassword = null;
   [SerializeField] private InputField m_LoginUserNameInput = null;



    [Header("Register")]
    [SerializeField] private GameObject m_regiterUI = null;
    [SerializeField] private GameObject m_loginUI = null;
    [SerializeField] private InputField m_userNameInput = null;
    [SerializeField] private Text m_Text = null;
    [SerializeField] private InputField m_emailInput = null;
    [SerializeField] private InputField m_password = null;
    [SerializeField] private InputField m_reEnterpassword = null;


    private networkManager m_NetworkManager = null;

    public void Awake()
    {
        m_NetworkManager = GameObject.FindObjectOfType<networkManager>();
    }

   public void SubmitLogin() 
    {
        if (m_LoginUserNameInput.text == "" || m_LoginPassword.text == "")
        {
            m_Text.text = "Completar los campos";
            return;
        }
        m_Text.text = "Procesando...";
        m_NetworkManager.CheckUser(m_LoginUserNameInput.text, m_LoginPassword.text, delegate (networkManager.Response response)

        {
            m_Text.text = response.message;
        });
        m_Text.text = "INGRESANDO";

    }


    public void SubmitRegister() 
    {

        if (m_userNameInput.text == "" || m_emailInput.text == "" || m_password.text == "" )
        {
            m_Text.text = "Completar los campos";
            return;
        }
        if(m_password.text == m_reEnterpassword.text)
        {
            m_Text.text = "Procesando...";
            m_NetworkManager.createUser(m_userNameInput.text, m_emailInput.text, m_password.text, delegate (networkManager.Response response)

            {
                m_Text.text = response.message;
            });
            m_Text.text = "creado";


        }
        else
        {
            m_Text.text = "No coinciden las contraseñas";
        }
    }


    public void ShowLogin()
    {
        m_regiterUI.SetActive(false);
        m_loginUI.SetActive(true);
    }
    public void ShowRegister()
    {
        m_regiterUI.SetActive(true);
        m_loginUI.SetActive(false);
    }

}
