using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affix
{
    private int ID;
    private string name;
    private AffixPos position;
    private Attribute attribute;
    private int min;
    private int max;

    public Affix(int iD, string name, AffixPos position,Attribute attribute, int min, int max)
    {
        ID = iD;
        this.name = name;
        this.min = min;
        this.max = max;
        this.attribute = attribute;
        this.position = position;
    }

    public enum Attribute
    {
        PhysicalAttack, MagicAttack, PhysicalArmor, MagicArmor,Evasion, NULL
    }

    public enum AffixPos
    {
        Perffix,Surffix,NULL
    }

    override
    public string ToString()
    {
        string s = ID + "," + name + "," + position.ToString() + "," + attribute.ToString() + "," + min + "," + max;
        return s;
    }

    public int debug()
    {
        return ID;
    }
}
