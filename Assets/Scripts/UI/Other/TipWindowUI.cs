using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipWindowUI : MonoBehaviour
{
    public enum TipWindowType
    {
        oneButton,
        twoButton
    }


    private Text titleText;
    private Text contentText;
    public Button oneButton1 { get; private set; }
    private Text oneButton1Text;
    public Button twoButton1 { get; private set; }
    private Text twoButton1Text;
    public Button twoButton2 { get; private set; }
    private Text twoButton2Text;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Transform root = transform;
        Transform tipPanel = root.Find(UIName.tipWindow_tipPanel);
        titleText = tipPanel.Find(UIName.tipWindow_titleText).GetComponent<Text>();
        contentText= tipPanel.Find(UIName.tipWindow_contentText).GetComponent<Text>();
        Transform bottomBar = tipPanel.Find(UIName.tipWindow_bottomBar);
        oneButton1 = bottomBar.Find(UIName.tipWindow_one_Button_1).GetComponent<Button>();
        oneButton1Text = oneButton1.transform.Find(UIName.tipWindow_one_Button_1_text).GetComponent<Text>();
        twoButton1 = bottomBar.Find(UIName.tipWindow_two_Button_1).GetComponent<Button>();
        twoButton1Text = twoButton1.transform.Find(UIName.tipWindow_two_Button_1_text).GetComponent<Text>();
        twoButton2 = bottomBar.Find(UIName.tipWindow_two_Button_2).GetComponent<Button>(); ;
        twoButton2Text = twoButton2.transform.Find(UIName.tipWindow_two_Button_2_text).GetComponent<Text>();

    }

    public static TipWindowUI Create(Transform parent, TipWindowType type = TipWindowType.oneButton)
    {

        var window = Instantiate(LoadResources
            .Load<TipWindowUI>(UIName.prefab_tipWindow), parent);
        if (type == TipWindowType.oneButton)
        {
            window.twoButton1.gameObject.SetActive(false);
            window.twoButton2.gameObject.SetActive(false);
        }
        else if (type == TipWindowType.twoButton)
        {
            window.oneButton1.gameObject.SetActive(false);
        }

        return window;
    }

    public TipWindowUI ChangeTitleText(string title)
    {
        titleText.text = title;
        return this;
    }

    public TipWindowUI ChangeContentText(string content)
    {
        contentText.text = content;
        return this;
    }

    public TipWindowUI ChangeButtonText(string button1Text)
    {
        oneButton1Text.text = button1Text;
        return this;
    }


    public TipWindowUI ChangeButtonText(string button1Text, string button2Text)
    {
        twoButton1Text.text = button1Text;
        twoButton2Text.text = button2Text;
        return this;
    }

    public TipWindowUI AddDeafultEvent()
    {
        oneButton1.onClick.AddListener(() => { DestroySelf(); });
        twoButton1.onClick.AddListener(() => { DestroySelf(); });
        twoButton2.onClick.AddListener(() => { DestroySelf(); });
        return this;
    }


    public void DestroySelf(float time = 0)
    {
        if (time != 0)
        {
            Destroy(gameObject, time);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
