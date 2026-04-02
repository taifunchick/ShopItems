using UnityEngine;

public class ShopInitializer : MonoBehaviour
{
    public ItemData[] shopItems;
    public ShopUI shopUI;

    void Start()
    {
        shopUI.SetupShopButtons(shopItems);
    }
}