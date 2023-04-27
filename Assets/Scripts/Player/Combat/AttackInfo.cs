using System;

[Serializable]
public class AttackInfo
{
    public string name;
    public AttackType attackType;
    public AbstractAttack attackScript;
    public int minDamage;
    public int maxDamage;
    public float cooldown;
}

public enum AttackType
{
    Melee, Ranged
}