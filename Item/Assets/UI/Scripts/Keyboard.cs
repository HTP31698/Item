using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : GenericWindow
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI cursor;
    public List<Button> keybutton;
    public Button[] buttons;
    private string text;
    private bool iscursor = true;
    private float timer = 0;
    private float maxtimer = 0.5f;

    protected void Awake()
    {
        for (int i = 0; i < keybutton.Count; i++)
        {
            var text = keybutton[i].GetComponentInChildren<TextMeshProUGUI>();
            var key = text.text;
            keybutton[i].onClick.AddListener(
                () =>
                {
                    OnKey(key);
                }
                );
        }
        buttons[0].onClick.AddListener(OnClickCancel);
        buttons[1].onClick.AddListener(OnClickDelete);
        buttons[2].onClick.AddListener(OnclikAccept);
    }

    private void Update()
    {
        timer += Time.deltaTime;
       
        if (timer >= maxtimer)
        {
            iscursor = !iscursor;
            cursor.text = iscursor ? "_" : "";
            timer = 0;
        }

        if (name.text.Length > 7)
        {
            iscursor = false;
            cursor.text = iscursor ? "_" : "";
            timer = 0;
        }
    }

    public void OnKey(string Key)
    {
        //StringBuilder
        text = Key;
        StringBuilder sb = new StringBuilder(name.text);
        sb.Append(text);
        if (name.text.Length <= 7)
        {
            name.text = sb.ToString();
        }
    }
    public void OnClickCancel()
    {
        manager.Open(Windows.Start);
    }
    public void OnClickDelete()
    {
        StringBuilder sb = new StringBuilder(name.text);
        sb.Remove(sb.Length - 1, 1);
        name.text = sb.ToString();
    }
    public void OnclikAccept()
    {
        manager.Open(Windows.Difficulty);
    }

}