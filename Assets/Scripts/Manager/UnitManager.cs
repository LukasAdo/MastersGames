using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
   public static UnitManager Instance;

    private List<ScriptableUnit> units; 

    private void Awake()
    {
        Instance = this;
        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnHeroes()
    {
        var heroCount = 1;

        for (int i = 0; i < heroCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseHeroes>(Faction.Hero);
            var spawnHero = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.instance.GetHeroSpawnTile();

            randomSpawnTile.SetUnit(spawnHero);
        }

        
    }
    

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

}
