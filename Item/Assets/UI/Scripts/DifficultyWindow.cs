using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public int index = 1;

    public ToggleGroup toggleGroup;
    public Toggle[] toggles;
    public Button[] buttons;

    public override void Open()
    {
        base.Open();
        toggles[index].isOn = true;
    }
    
    public void OnToglle()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
            if(toggles[i].isOn)
            {
                Debug.Log(i);
                break;
            }
        }
    }

    public void OnClickEasy(bool value)
    {
        if(value)
        {
            Debug.Log("e");
        }
    }

    public void OnClickNormal(bool value)
    {
        if (value)
        {
            Debug.Log("n");
        }
    }

    public void OnClickHard(bool value)
    {
        if (value)
        {
            Debug.Log("h");
        }
    }
}