using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Board : MonoBehaviour
{

    public Dictionary<Vector3Int, TileLogic> tiles;
    public List<Floor> floors;
    public static Board instance;
    [HideInInspector] Grid grid;


    private void Awake()
    {
        tiles = new Dictionary<Vector3Int, TileLogic>();
        instance = this;
        grid = GetComponent<Grid>();
    }


    private void Start()
    {
        InitSequence();
    }

    public void InitSequence()
    {
        LoadFloors();
        Debug.Log("Foram Criados - " + tiles.Count + " - tiles");
    }

    void LoadFloors()
    {
        for(int i = 0; i < floors.Count; i++)
        {
            List<Vector3Int> floorsTiles = floors[i].LoadTiles();
            for(int j = 0; j < floorsTiles.Count; j++)
            {
                if (!tiles.ContainsKey(floorsTiles[j]))
                {
                    CreateTile(floorsTiles[j], floors[i]);
                }
            }
        }
    }

    void CreateTile(Vector3Int pos, Floor floor)
    {
        Vector3 worldPos = grid.CellToWorld(pos);
        worldPos.y += floor.tilemap.tileAnchor.y / 2;
        TileLogic tileLogic = new TileLogic(pos, worldPos, floor);
        tiles.Add(pos, tileLogic);

    }
}
