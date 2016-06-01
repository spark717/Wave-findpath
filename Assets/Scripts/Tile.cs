using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {



    public GameManager gameManager;
    public Object wallPi;
    public IntVector2 posInField = new IntVector2();



    void Awake ()
    {
        InitGameManager();
    }



    void InitGameManager()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
    }



    void OnMouseUp ()
    {
        string setMode = gameManager.setMode;
        if (setMode == "Wall")
        {
            Instantiate(wallPi, transform.parent.position, transform.parent.rotation);
            gameManager.wall.Add(posInField);
        }
        else if (setMode == "EnterPoint")
        {
            gameManager.enterTile = posInField;
        }
        else if (setMode == "ExitPoint")
        {
            gameManager.exitTile = posInField;
        }
    }
	
}
