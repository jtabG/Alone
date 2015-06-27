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

public class ConstValues
{
    #region STRINGS
    public const string PLAYER_TAG = "Player";

    #endregion

    #region NUMERICAL
    public const int SUICIDE_SAM_MAX_COUNT = 3;
    public const float SUICIDE_SAM_RESET_TIME = 2.0F;

    #endregion
}