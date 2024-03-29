using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class TileLogic 
{

    public Vector3Int pos;
    public Vector3 worldPos;
    public GameObject content;
    public Floor floor;
    public int contentOrder;

    public TileLogic()
    {
    }

    public TileLogic(Vector3Int cellPos, Vector3 worldPosition, Floor tempFloor)
    {
       pos = cellPos;
       worldPos = worldPosition;
       floor = tempFloor;
        contentOrder = tempFloor.contentOrder;
    }


    public static TileLogic Create(Vector3Int cellPos, Vector3 worldPosition, Floor tempFloor)
    {
        TileLogic tileLogic = new TileLogic(cellPos, worldPosition, tempFloor);
        return tileLogic;
    }

}
