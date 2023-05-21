using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RunTestAchievement : AchievementManager
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            UnlockAchievement(Achievements[0].ToString());
            //Debug.Log("Achievement Run!");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UnlockAchievement(Achievements[0].ToString());
    }
}