using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AchievementManager : Singleton<AchievementManager>
{
    [SerializeField] private List<Achievement> achievements = new List<Achievement>();
    public List<Achievement> Achievements => achievements;

    public Action<Achievement> OnAchievementUnlocked;

    private void Update()
    {
        if(Keyboard.current.pKey.wasPressedThisFrame)
            SavingSystem.ClearSave();
    }

    public void UnlockAchievement(string title)
    {
        var achievementToUnlock = achievements.Find(achievement => achievement.title == title);
        if (achievementToUnlock != null && SavingSystem.GetBool($"{achievementToUnlock.title}_unlocked", false) == false)
        {
            Debug.Log("Achievement unlocked: " + achievementToUnlock.title);
            OnAchievementUnlocked?.Invoke(achievementToUnlock);
            SavingSystem.SetBool($"{achievementToUnlock.title}_unlocked", true);
        }
    }

    public bool IsAchievementUnlocked(string title)
    {
        var achievementToCheck = achievements.Find(achievement => achievement.title == title);
        return SavingSystem.GetBool($"{achievementToCheck.title}_unlocked", false) == true;
    }
}
