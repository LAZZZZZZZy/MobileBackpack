using UnityEngine;
using System.Collections;
///
/// 背包类，继承自 存货类Inventroy
///
public class Knapsack : Inventory
{
    //单例模式
    private static Knapsack _instance;
    public static Knapsack Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Backpack").GetComponent<Knapsack>();
            }
            return _instance;
        }
    }

    public override void Start()
    {
        base.Start();
       // Hide();
    }
}