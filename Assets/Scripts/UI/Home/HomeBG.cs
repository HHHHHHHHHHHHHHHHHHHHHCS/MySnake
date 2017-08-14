using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HomeBG : UIBG_Base
{
    private Image userAvatarImg;
    private Text userNameText;
    private Text userLVText;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Transform root = transform;

        Transform userInfo = root.Find(UIName.home_userInfo);
        userAvatarImg = userInfo.Find(UIName.home_userAvatarImg).GetComponent<Image>();
        userNameText = userInfo.Find(UIName.home_userNameText).GetComponent<Text>();
        userLVText = userInfo.Find(UIName.home_userLVText).GetComponent<Text>();

        Transform playButtonBar = root.Find(UIName.home_playButtonsBar);
        var buttonsPath = new string[] 
        { UIName.home_endlessPVEButton, UIName.home_timeLimitPVEButton, UIName.home_pVPButton };
        var calls = new UnityAction[] 
        { ClickEndlessPVEButton, ClickTimeLimitPVEButton, ClickPVPButton};
        AddButtonsListener(playButtonBar, buttonsPath, calls);

    }

    private void ClickEndlessPVEButton()
    {
        Debug.Log("ClickEndlessPVEButton");
    }

    private void ClickTimeLimitPVEButton()
    {
        Debug.Log("ClickTimeLimitPVEButton");
    }

    private void ClickPVPButton()
    {
        Debug.Log("ClickPVPButton");
    }
}
