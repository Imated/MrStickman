using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MainMenuState : State
{
    protected override void OnEnter()
    {
        Sc.CanBreak = false;
        Sc.PlayButton.onClick.AddListener(PlayClicked);
    }

    private void PlayClicked()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Sc.ChangeState(Sc.BreakState);
    }
    
    protected override void OnUpdate()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
            EventSystem.current.SetSelectedGameObject(null);
    }
}
