using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Shop/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int price;
    public Sprite icon;
}