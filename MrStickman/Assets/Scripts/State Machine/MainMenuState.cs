using UnityEngine.SceneManagement;
public class MainMenuState : State
{
    protected override void OnEnter()
    {
        Sc.CanBreak = false;
        AddSubState(Sc.BreakState);
        AddSubState(Sc.MovementState);
        AddSubState(Sc.InteractionState);
        Sc.PlayButton.onClick.AddListener(PlayClicked);
    }
    protected override void OnUpdate()
    {

    }

    void PlayClicked()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Sc.ChangeState(Sc.BreakState);
    }
    protected override void OnInteract()
    {

    }
    protected override void OnExit()
    {

    }
}
