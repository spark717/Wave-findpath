using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {



    public int height, widht;
    public string setMode = "Wall";
    public WaveAlgoritm algorithmScript;
    public List<IntVector2> wall = new List<IntVector2>();
    public IntVector2 enterTile = new IntVector2();
    public IntVector2 exitTile = new IntVector2();
    private FieldTile[,] fieldTiles;




    public void SetEnterButtonPress ()
    {
        setMode = "EnterPoint";
    }



    public void SetExitButtonPress ()
    {
        setMode = "ExitPoint";
    }



    public void StartAlgorithmButtonPress ()
    {
        algorithmScript.StartAlgorithm(new IntVector2(height, widht), enterTile, exitTile, wall);
    }




}
