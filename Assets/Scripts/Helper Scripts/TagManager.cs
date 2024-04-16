using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTags {

    public const string MOVEMENT = "Movement";
    public const string JUMP = "Jump";

    public const string IDLE_ANIMATION = "Idle";

    public const string PUNCH_1TRIGGER = "Punch1";
    public const string PUNCH_2TRIGGER = "Punch2";
    public const string PUNCH_3TRIGGER = "Punch3";

    public const string KICK_1_TRIGGER = "Kick1";
    public const string KICK_2_TRIGGER = "Kick2";

    public const string ATTACK_1_TRIGGER = "Attack1";
    public const string ATTACK_2_TRIGGER = "Attack2";

    public const string KNOCK_DOWN_TRIGGER = "KnockDown";
    public const string STAND_UP_TRIGGER = "StandUp";
    public const string HIT_TRIGGER = "Hit";
    public const string DEATH_TRIGGER = "Death";

    public const string VICTORY_TRIGGER = "Victory";
}

public class Axis {
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class Tags {
    public const string GROUND_TAG = "Ground";
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "ENEMY";
    public const string UNTAGGED_TAG = "Untagged";

    public const string LEFT_ARM_TAG = "LeftArm";
    public const string RIGHT_ARM_TAG = "RightArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string RIGHT_LEG_TAG = "RightLeg";
}
