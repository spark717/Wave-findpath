using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {



    public GameManager gameManager;
    public Transform tilePrefab;

    private IntVector2 size = new IntVector2();



    void Awake ()
    {
        InitField();
    }



    void InitField ()
    {
       // Tile tileScript;

        size.x = gameManager.widht;
        size.y = gameManager.height;    
        
        for (int y = 0; y < size.y; y ++)
        {
            for (int x = 0; x < size.x; x++)
            {
                Transform newTile = (Transform)Instantiate(tilePrefab, new Vector3(y, 0, x), transform.rotation);
                newTile.parent = transform;

                Tile tileScript = newTile.Find("TileCollider").GetComponent<Tile>();
                tileScript.posInField = new IntVector2(x, y);
                //Debug.Log(tileScript.posInField.x);
            }
        }         
    }

}
