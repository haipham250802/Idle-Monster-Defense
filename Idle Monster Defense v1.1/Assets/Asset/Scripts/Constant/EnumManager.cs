using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumManager : MonoBehaviour
{
   
}
public enum TypeShopElement
{
    NONE = -1,
    PRIMARY,
    ADVANCED,
    SUPER_ADVANCED
}
public enum TypeScenes
{
    NONE = -1,
    LOBBY,
    GAMEPLAY
}
public enum TypeAudioClip
{
    NONE = -1,
    AUCLIP_BUTTON,
    AUCLIP_CLAIM,
    WIN,
    LOSE,
    BULLET
}
public enum TypeSellectLobby
{
    NONE = -1,
    FIGHT,
    UPGRADE,
    SHOP
}
public enum E_TypeEnemy
{
    NONE = -1,
    Enemy1,
    Enemy2,
    Enemy3,
    Enemy4,
    Enemy5,
    Enemy6,
    Enemy7,
    Enemy8,
    Enemy9,
    Enemy10,
    Enemy11,
    Enemy12,
    Enemy13,
    Enemy14,
    Enemy15,
    Boss_Hami,
    Boss_Ske,
    Boss_kicker
}
public enum E_TypeUpgrade
{
    NONE = -1,
    DAMAGE,
    HP,
    RANGE_ATTACK,
    ATTACK_SPEED
}

