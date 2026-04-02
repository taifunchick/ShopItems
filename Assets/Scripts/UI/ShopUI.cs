using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    [Header("UI elements")]
    public TextMeshProUGUI goldText;
    public Transform shopItemsContainer;
    public GameObject shopButtonPrefab;
    public TextMeshProUGUI inventoryText;

    private ShopController controller;

    void Awake()
    {
        controller = FindObjectOfType<ShopController>();
    }

    void OnEnable()
    {
        controller.OnGoldChanged += UpdateGoldDisplay;
        controller.OnInventoryChanged += UpdateInventoryDisplay;
    }

    void OnDisable()
    {
        controller.OnGoldChanged -= UpdateGoldDisplay;
        controller.OnInventoryChanged -= UpdateInventoryDisplay;
    }

    void Start()
    {
        UpdateGoldDisplay(controller.playerGold);
        UpdateInventoryDisplay();
    }

    void UpdateGoldDisplay(int gold)
    {
        goldText.text = $"{gold}";
    }

    void UpdateInventoryDisplay()
    {
        string items = "";
        foreach (var item in controller.inventory)
        {
            items += $"{item.itemName}\n";
        }
        inventoryText.text = items.Length > 0 ? items : "Empty";
    }

    public void SetupShopButtons(ItemData[] items)
    {
        foreach (Transform child in shopItemsContainer)
            Destroy(child.gameObject);

        foreach (var item in items)
        {
            GameObject buttonObj = Instantiate(shopButtonPrefab, shopItemsContainer);
            ShopButton button = buttonObj.GetComponent<ShopButton>();
            button.Setup(item, controller);
        }
    }
}