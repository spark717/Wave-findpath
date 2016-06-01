using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaveAlgoritm : MonoBehaviour {



    //public Transform gameField;
    public Text debugOut;
    public Transform debugTileNum;

    private IntVector2 size;
    private FieldTile[,] fieldTiles;
    private Mesh fieldMesh;
    private int wave = 1;
    private int emptyCount = 0;



    void Awake () {
       // InitNewField();

        //workPoints.Add(new Vector3(start.x, start.y, 0));
        //field[(int)start.x, (int)start.y] = 0;
       // field[6, 3] = 0;
        //field[6, 4] = 0;
       // field[6, 5] = 0;

       // Wave();

       // DebugOutput();
    }



    public void StartAlgorithm (IntVector2 _size, IntVector2 _enterTile, IntVector2 _exitTile, List<IntVector2> _wall)
    {
        this.size = _size;

        InitNewField(_enterTile, _wall);

        //DebugOutput();

        Wave();

        DebugOutput();
    }



    void InitNewField(IntVector2 _enterTile, List<IntVector2> _wall)
    {
        //Значения в ячейках:
        //                      empty: пустая, не обработанная
        //                      wall: стена
        //                      handle: в режиме обработки (по этим ячейкам ходит рекурсивный цикл)
        //                      numbered: уже обработанна, содержит цифровой индикатор удаленности
                
        fieldTiles = new FieldTile[size.x, size.y];
        
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++, emptyCount++)
            {
                fieldTiles[x, y] = new FieldTile("empty");
            }
        }

        fieldTiles[_enterTile.x, _enterTile.y] = new FieldTile("start", 0, 1);
        emptyCount--;

        foreach (IntVector2 wallPi in _wall)
        {
            fieldTiles[wallPi.x, wallPi.y].fill = "wall";
            emptyCount--;
        }
    }



    void Wave ()
    {
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                if (fieldTiles[x, y].wave == wave)
                {
                    int newNum = fieldTiles[x, y].num + 1;
                    int newWave = wave + 1;

                    if (y < size.y - 1 && fieldTiles[x, y + 1].fill == "empty")
                    {
                        fieldTiles[x, y + 1] = new FieldTile("numbered", newNum, newWave);
                        emptyCount--;
                    }

                    if (y > 0 && fieldTiles[x, y - 1].fill == "empty")
                    {
                        fieldTiles[x, y - 1] = new FieldTile("numbered", newNum, newWave);
                        emptyCount--;
                    }

                    if (x < size.x - 1 && fieldTiles[x + 1, y].fill == "empty")
                    {
                        fieldTiles[x + 1, y] = new FieldTile("numbered", newNum, newWave);
                        emptyCount--;
                    }

                    if (x > 0 && fieldTiles[x - 1, y].fill == "empty")
                    {
                        fieldTiles[x - 1, y] = new FieldTile("numbered", newNum, newWave);
                        emptyCount--;
                    }                
                }
            }
        }
        wave++;
         if (emptyCount > 0)
         {
           Wave();
         }
    }



    void DebugOutput()
    {
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                Transform tileNum = (Transform)Instantiate(debugTileNum, new Vector3(y, 0, x), debugTileNum.rotation);
                tileNum.GetComponent<TextMesh>().text = fieldTiles[x, y].num.ToString();
                   // num.ToString();
            }
        }
    }
}




