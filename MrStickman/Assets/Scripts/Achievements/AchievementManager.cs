using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AchievementManager : Singleton<AchievementManager>
{
    public List<Achievement> achievements = new List<Achievement>();
    public AchievementManager instance;
    public List<Achievement> Achievements
    {
        get => achievements;
    }
    public Action<Achievement> OnAchievementUnlocked;

    private void Start()
    {
        instance = this;
    }

    //public void GetAchievement(int)
    //{
    //    achievements[achIndex].ToString();
    //    return;
    //}


    public void UnlockAchievement(string title)
    {
        var achievementToUnlock = achievements.Find(achievement => achievement.title == title);
        if (achievementToUnlock != null && SavingSystem.GetBool($"{achievementToUnlock.title}_unlocked", false) == false)
        {
            Debug.Log("Achievement unlocked: " + achievementToUnlock.title);
            OnAchievementUnlocked?.Invoke(achievementToUnlock);
            //Invoke(achievementToUnlock);
            SavingSystem.SetBool($"{achievementToUnlock.title}_unlocked", true);
        }
    }

    private void Invoke(Achievement achievementToUnlock)
    {
        throw new NotImplementedException();
    }

    public bool IsAchievementUnlocked(string title)
    {
        var achievementToCheck = achievements.Find(achievement => achievement.title == title);
        return SavingSystem.GetBool($"{achievementToCheck.title}_unlocked", false) == true;
    }
}
