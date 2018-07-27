using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NewEditModeTest {

    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
	public void T00_PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01_OneStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T02_Bowl8RerunsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T03_Bowl28SpareReturnsEndTurn()
    {
        int[] rolls = { 8, 2 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T04_CheckResetAtStrikeLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T05_CheckResetAtStrikeLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,9 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T06_YouTubeRollsENdInEndGame ()
    {
        int[] rolls = {8,2, 7,3, 3,4, 10,2, 8,10, 10,8, 0,10, 8,2, 9 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T07_GameEndAtBowl20()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T08_Bowl21SPareTest()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10,5 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T09_BensBowls20Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 ,0};
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T10_NathanBowlIndexTest()
    {
        int[] rolls = { 0,10,5,1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T11_Dondis10thFrameTurkey1()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T12_Dondis10thFrameTurkey2()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T13_Dondis10thFrameTurkey3()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T14_ZeroOneGivesEndTurn()
    {
        int[] rolls = {0,1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
}