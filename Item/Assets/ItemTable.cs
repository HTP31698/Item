using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemTable : DataTable
{
    public static readonly string Unknown = "키 없음";

    public class ItemData
    {
        public string Id { get; set; }
        public string Sprite { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }
        public int Effect { get; set; }
        public int Defense { get; set; }
    }

    private readonly Dictionary<string, ItemData> dictionary = 
        new Dictionary<string, ItemData>();

    public override void Load(string filename)
    {
        dictionary.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<ItemData>(textAsset.text);
        foreach (var item in list)
        {
            if (!dictionary.ContainsKey(item.Id))
            {
                dictionary.Add(item.Id, item);
            }
            else
            {
                Debug.LogError($"키 중복: {item.Id}");
            }
        }

    }

    public ItemData Get(string key)
    {
        if (!dictionary.ContainsKey(key))
        {
            return null;
        }
        return dictionary[key];
    }
}