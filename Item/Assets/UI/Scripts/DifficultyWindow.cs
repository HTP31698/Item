using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyData
{
    public string Difficulty { get; set; }
    public int ToggleIndex { get; set; }

    public override string ToString()
    {
        return $"{Difficulty} / {ToggleIndex}";
    }
}

public class DifficultyTable : DataTable
{
    private readonly Dictionary<string, int> DifficultyList = new Dictionary<string, int>();

    public override void Load(string filename)
    {
        DifficultyList.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<DifficultyData>(textAsset.text);
        foreach (var item in list)
        {
            if (!DifficultyList.ContainsKey(item.Difficulty))
            {
                DifficultyList.Add(item.Difficulty, item.ToggleIndex);
            }
            else
            {
                Debug.LogError("아이템 아이디 중복!");
            }
        }
    }
}

public class DifficultyWindow : GenericWindow
{
    public int index = 1;

    public ToggleGroup toggleGroup;
    public Toggle[] toggles;
    public Button[] buttons;
    private string difficulty;
    public TextMeshProUGUI text;

    private void Awake()
    {
        buttons[0].onClick.AddListener(OnClickSave);
        buttons[1].onClick.AddListener(OnClickLoad);
        buttons[2].onClick.AddListener(OnClickTitle);
        buttons[3].onClick.AddListener(OnClickGameOver);
    }

    public override void Open()
    {
        base.Open();
        toggles[index].isOn = true;
    }

    public void OnToglle()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                Debug.Log(i);
                break;
            }
        }
    }

    public void OnClickEasy(bool value)
    {
        if (value)
        {
            difficulty = "EASY";
            index = 0;
            text.text = difficulty;
        }
    }

    public void OnClickNormal(bool value)
    {
        if (value)
        {
            difficulty = "NORMAL";
            index = 1;
            text.text = difficulty;
        }
    }

    public void OnClickHard(bool value)
    {
        if (value)
        {
            difficulty = "HARD";
            index = 2;
            text.text = difficulty;
        }
    }

    public void OnClickSave()
    {
        SaveLoadManager.Data.Difficulty = difficulty;
        SaveLoadManager.Data.ToggleIndex = index;
        SaveLoadManager.Save();
    }
    public void OnClickLoad()
    {
        if(SaveLoadManager.Load())
        {
            difficulty = SaveLoadManager.Data.Difficulty;
            index = SaveLoadManager.Data.ToggleIndex;
            Open();
            text.text = difficulty;
        }

        Debug.Log(SaveLoadManager.Data.ToggleIndex);
    }
    public void OnClickTitle()
    {
        manager.Open(Windows.Start);
    }
    public void OnClickGameOver()
    {
        manager.Open(Windows.GameOver);
    }
}