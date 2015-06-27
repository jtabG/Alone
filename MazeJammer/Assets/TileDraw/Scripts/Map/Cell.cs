using System;
using TileDraw.Map;
using UnityEngine;

[Serializable]
public class Cell : MonoBehaviour
{
    public Tile[] Tiles;
    [SerializeField] private int _numberOfTiles;

    public void GenerateTiles(int numberOfTiles)
    {
        _numberOfTiles = numberOfTiles;

        Tiles = new Tile[numberOfTiles*numberOfTiles];
        for (int index = 0; index < Tiles.Length; index++)
        {
            Tiles[index] = new Tile(transform.position.y);
        }
    }

    public void UpdateHeight(int x, int y, float height)
    {
        var index = y * _numberOfTiles + x;

        Tiles[index].Heights = height;

        var entity = Tiles[index].Entity;
        if (entity != null)
        {
            var pos = entity.transform.localPosition;
            pos.y = height;
            entity.transform.localPosition = pos;
        }
    }

    public Tile GetTileFromPointInCell(int x, int y)
    {
        var index = y*_numberOfTiles + x;

        if (index >= Tiles.Length) throw new UnityException("Tile out of range");

        return Tiles[index];
    }
}