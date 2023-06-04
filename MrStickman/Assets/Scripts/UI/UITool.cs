using TMPro;
using UnityEngine;

public class UITool : MonoBehaviour
{
    [SerializeField] private TMP_Text toolNameText;
    [SerializeField] private TMP_Text toolDescriptionText;
    [SerializeField] private GameObject starImage;

    private Tool _tool;

    public void Initialize(Tool tool)
    {
        _tool = tool;
        toolNameText.text = _tool.name;
        toolDescriptionText.text = _tool.description;
        starImage.SetActive(StateController.Instance.CurrentTool == tool);
    }

    public void OnClicked()
    {
        ShopManager.Instance.UpdateCurrentTool(_tool);
        Favorite();
    }

    public void Favorite()
    {
        starImage.SetActive(true);
    }
    
    public void UnFavorite()
    {
        starImage.SetActive(false);
    }
}
