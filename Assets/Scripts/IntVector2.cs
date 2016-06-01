//using UnityEngine;
//using System.Collections;

public class IntVector2
{

    public int x, y;

    public IntVector2() { }


    public IntVector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

}

public class FieldTile
{

    public string fill;
    public int num;
    public int wave;

    public FieldTile() { }

    public FieldTile(string fill, int num)
    {
        this.fill = fill;
        this.num = num;
    }

    public FieldTile(string fill, int num, int wave)
    {
        this.fill = fill;
        this.wave = wave;
        this.num = num;
    }

    public FieldTile(string fill)
    {
        this.fill = fill;
    }

}
