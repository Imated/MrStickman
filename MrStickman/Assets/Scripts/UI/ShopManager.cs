using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private GameObject container;
    [SerializeField] private Transform toolsParent;
    [SerializeField] private GameObject toolPrefab;
    [SerializeField] private List<Tool> tools;
    
    private List<UITool> _uiTools = new List<UITool>();
    private CanvasGroup _canvasGroup;
    private bool _isShown;

    protected override void Awake()
    {
        base.Awake();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        container.SetActive(false);
        foreach (var tool in tools)
        {
            var obj = Instantiate(toolPrefab, toolsParent);
            var uiTool = obj.GetComponent<UITool>();
            uiTool.Initialize(tool);
            _uiTools.Add(uiTool);
        }
    }

    private void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            if (_isShown)
                Hide();
            else
                Show();
        }
    }

    public void UpdateCurrentTool(Tool newTool)
    {
        StateController.Instance.CurrentTool = newTool;
        foreach (var uiTool in _uiTools)
            uiTool.UnFavorite();
    }
    
    public void Show()
    {
        _isShown = true;
        container.SetActive(true);
        _canvasGroup.DOFade(1f, 0.35f);
    }
    
    public void Hide()
    {
        _isShown = false;
        _canvasGroup.DOFade(0f, 0.35f).OnComplete(() => container.SetActive(false));
    }
}
