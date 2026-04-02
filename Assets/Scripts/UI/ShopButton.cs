using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI priceText;
    public Image iconImage;
    public Button buyButton;

    private ItemData item;
    private ShopController controller;

    public void Setup(ItemData itemData, ShopController shopController)
    {
        item = itemData;
        controller = shopController;

        itemNameText.text = item.itemName;
        priceText.text = $"{item.price}";
        iconImage.sprite = item.icon;

        buyButton.onClick.AddListener(OnBuyClicked);
    }

    void OnBuyClicked()
    {
        controller.BuyItem(item);
    }
}