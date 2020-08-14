using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SM4SlaveMaker : SM4Slave
{



    public Products products;
    // public List<PlanningAct> smActs1 = new List<PlanningAct>();
    // public List<PlanningAct> smActs2 = new List<PlanningAct>();
    public General generalSM;
    public int currentSlaveID;
    
    public bool[] rulesAreOn = new bool[11] ;
    public string[] rulesTextOn = new string[11];
    public string[] rulesTextOff = new string[11];



}

public struct General{
    public string masterMistress;		// what your slaves calls you after master/mistress event
    public bool supervise;				// are you supervising slave
}


public struct Products
{
    public int trained;
    public int sold;
    public int kept;
    public int bought;
    public int lost;
    public int escaped;
    public int kidnapped;
    public int died;
}

public struct Money
{
    public int current;
    public int bank;
    public int totalEarned;
    public int totalSpend;
}