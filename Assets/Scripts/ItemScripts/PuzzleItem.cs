using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : ItemProperties
{
    //properties
    public string keyWord;
    public string riddle;
    public bool Solved;

    //constructor
    public PuzzleItem(string itemName, float ItemWeight, string keyWord, string riddle) : base(itemName, ItemWeight)
    {
        this.keyWord = keyWord;
        this.riddle = riddle;
        Solved = false;
    }

    //methods
    public bool AwnserIsTo(string input)
    {
        Debug.Log($"the qeustion was: {riddle}, your anwser was {input}, the awnser is {keyWord}");
        Solved = (input == keyWord);
        return Solved;
    }
}
