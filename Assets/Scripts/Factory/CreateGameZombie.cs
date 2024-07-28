using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameZombie : ISpawnZombieFactory
{
    private Transform _pointSpawn;
    private PoolObjectFactory<FollowForAim> pool;

    public CreateGameZombie(Transform pointSpawn)
    {
        _pointSpawn = pointSpawn;
    }
    public override GameObject SpawnerGameZombie()
    {
        var prefabStandartZombie = Resources.Load<GameObject>("Zombie/ZombieAttackNew");
        var prefabStandart = Instantiate(prefabStandartZombie, _pointSpawn.position, Quaternion.identity);
        return prefabStandart;
    }

    public override GameObject SpawnerGameZombieBig()
    {
        var prefabsStandartZombie = Resources.Load<GameObject>("Zombie/ZombieAttackNew");
        var prefabsStandart = Instantiate(prefabsStandartZombie, _pointSpawn.position, Quaternion.identity);
        return prefabsStandart;
    }

    public GameObject CreatePrefab(GameObject prefabsStandart, Vector3 vector3, Quaternion identity)
    {
        var spawnPosition = transform.position;
        var shit = this.pool.GetFreeElement();
        shit.transform.position = spawnPosition;
        return prefabsStandart;
    }
}
