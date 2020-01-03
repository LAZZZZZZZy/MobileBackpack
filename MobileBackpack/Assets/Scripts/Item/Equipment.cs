using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment: Item
{
    private EquipType equiptype;
    private Affix surffix;
    private Affix perffix;
    private ValueType valueType;
    private int min;
    private int max;

    public Equipment(int iD, string name, EquipType type, int rare, Affix surffix, Affix perffix, ValueType valueType, int min, int max,string description,string sprite)
    {
        this.ID = iD;
        this.Name = name;
        this.Type = ItemType.Equipment;
        this.equiptype = type;
        this.Rare = rare;
        this.surffix = surffix;
        this.perffix = perffix;
        this.valueType = valueType;
        this.min = min;
        this.max = max;
        this.Description = description;
        this.Sprite = sprite;
        this.Capacity = 1;
    }

    public enum EquipType
    {
        Weapon,OffWeapon,Boot,Head,Body,Pants,Ring,Necklet,NULL
    }

    //equipment value type
    public enum ValueType
    {
        Physical,Magic, Evasion,Armor,NULL
    }

    override
    public string ToString()
    {
        string s = ID + "," + Name + "," + equiptype.ToString() + "," + Rare + "," + surffix.debug() + "," + perffix.debug() + "," + valueType.ToString() + "," + max + "," + max;
        return s;
    }

}
