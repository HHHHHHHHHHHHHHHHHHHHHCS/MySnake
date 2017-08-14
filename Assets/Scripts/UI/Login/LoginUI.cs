using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : UIBG_Base
{
    private InputField accountInput;
    private InputField passwordInput;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Transform root = transform;
        Transform loginPanel = root.Find(UIName.login_loginPanel);
        accountInput = loginPanel.Find(UIName.login_accountInput).GetComponent<InputField>();
        passwordInput = loginPanel.Find(UIName.login_passwordInput).GetComponent<InputField>();
        AddButtonListener(loginPanel, UIName.login_loginButton, ClickLoginButton);
    }

    private void ClickLoginButton()
    {
        Debug.Log("LoginUserInfo:" + accountInput.text + "   " + passwordInput.text);
        UIManager.Instance.JumpBG(UIName.prefab_homeBG);
        //var test = TipWindowUI.Create(UIManager.Instance.transform);
        //test.ChangeTitleText("title").ChangeContentText("content")
        //.ChangeButtonText("close").AddDeafultEvent();

    }
}
