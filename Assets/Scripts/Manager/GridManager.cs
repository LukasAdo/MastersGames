using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField] private int _width, _height;
    [SerializeField] private Tile grassTile, mountainTile;
    [SerializeField] private Transform _cam;
    [SerializeField] private Transform tilesParent; // Parent transform to hold the tiles

    private Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        instance = this;
    }

    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var randomTile = UnityEngine.Random.Range(0, 6) == 3 ? mountainTile : grassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity, tilesParent); // Set parent
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Init(x, y);
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 3.84f - 0.5f, (float)_height / 1.4f - 0.5f, -10);
        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
    }

    public Tile GetHeroSpawnTile()
    {
        return _tiles.Where(t => t.Key.x < _width / 2 && t.Value.IsWalkable).OrderBy(t => UnityEngine.Random.value).First().Value;
    }

    public Tile GetEnemySpawnTile()
    {
        return _tiles.Where(t => t.Key.x > _width / 2 && t.Value.IsWalkable).OrderBy(t => UnityEngine.Random.value).First().Value;
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }

    public bool IsWithinBounds(Vector2 pos)
    {
        return pos.x >= 0 && pos.x < _width && pos.y >= 0 && pos.y < _height;
    }

    public Tile GetRandomWalkableTile()
    {
        return _tiles.Where(t => t.Value.IsWalkable).OrderBy(t => UnityEngine.Random.value).FirstOrDefault().Value;
    }

    public List<Tile> GetAllWalkableTiles()
    {
        return _tiles.Where(t => t.Value.IsWalkable).Select(t => t.Value).ToList();
    }
}
