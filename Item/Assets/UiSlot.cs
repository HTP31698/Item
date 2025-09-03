using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSlot : MonoBehaviour
{
    public Image image;
    public string uiId;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        var ItemTable = DataTableIds.ItemTableId;
        image.image = ItemTable.Get(Sprite);
    }
}