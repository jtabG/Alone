using UnityEngine;
using System.Collections;


public enum TrapType
{
    NONE,
    PIT,
    FIRE,
    WURM
}

public enum TrapState
{
    DISABLED,
    IDLE,
    TRIGGERED,
    ACTIVE,
    RESETTING
}

public class StringConsts
{
    public const string PLAYER_TAG = "Player";
}