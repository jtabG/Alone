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
    DISABLED, // unable to be activated
    IDLE, // able to be activated
    TRIGGERED, // activated
    ACTIVE, // do active thing
    RESETTING // reset trap
}

public enum AIType
{
    NONE,
    FLOATY_FRED,
    SUICIDE_SAM
}

public enum AIState
{
    IDLE,
    TRIGGERED,
    ACTIVE,
    RESETTING
}

public enum PlayerAnimation
{
    COMMAND,
    DEATH,
    FALL
}

public class ConstValues
{
    #region STRINGS
    public const string PLAYER_TAG = "Player";
    public const string PLAYER_ANIMATION_MOVEMENT = "Forward";
    public const string PLAYER_ANIMATION_COMMAND = "Command";
    public const string PLAYER_ANIMATION_DEATH = "Death";
    public const string PLAYER_ANIMATION_FALL = "FallDeath";

    #endregion

    #region NUMERICAL
    public const int SUICIDE_SAM_MAX_COUNT = 3;
    public const float SUICIDE_SAM_RESET_TIME = 2.0F;

    public const int FLOATY_FRED_MAX_COUNT = 1;
    //public const float FLOATY_FRED_SIGHT_RANGE = 5.0F;

    #endregion
}

public enum LevelEnum
{
    LEVEL1 = 1,
    LEVEL2 = 2,
    LEVEL3 = 3
}