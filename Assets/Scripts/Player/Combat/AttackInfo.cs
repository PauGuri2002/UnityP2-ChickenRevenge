using System;

[Serializable]
public class AttackInfo
{
    public AttackType attackType;
    public AbstractAttack attack;
    public int minDamage;
    public int maxDamage;
    public float cooldown;
}

public enum AttackType
{
    Melee, Ranged
}