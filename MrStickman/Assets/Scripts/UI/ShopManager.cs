using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Transform toolsParent;
    [SerializeField] private GameObject toolPrefab;
    [SerializeField] private List<Tool> tools;
    private CanvasGroup _canvasGroup;
    private bool _isShown;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        //gameObject.SetActive(false);
        foreach (var tool in tools)
            Instantiate(toolPrefab, toolsParent);
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

    public void Show()
    {
        _isShown = true;
        //gameObject.SetActive(true);
        _canvasGroup.DOFade(1f, 0.35f);
    }
    
    public void Hide()
    {
        _isShown = false;
        _canvasGroup.DOFade(0f, 0.35f)/*.OnComplete(() => gameObject.SetActive(false))*/;
    }
}
