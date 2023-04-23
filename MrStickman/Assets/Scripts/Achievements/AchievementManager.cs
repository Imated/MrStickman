using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : Singleton<AchievementManager>
{
    [SerializeField] private List<Achievement> achievements = new List<Achievement>();

    public void UnlockAchievement(string title)
    {
        var achievement = achievements.Find((a) => a.title == title);
        SavingSystem.SetBool($"{achievement.title}_unlocked", true);
    }
}
