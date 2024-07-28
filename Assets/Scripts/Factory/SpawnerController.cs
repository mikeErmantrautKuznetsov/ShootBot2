using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private Transform oneTransform;
    [SerializeField] private Transform twoTansform;
    [SerializeField] private Transform threeTansform;
    [SerializeField] private Transform fourTansform;

    private ISpawnZombieFactory spawnZombieFactory;

    private PoolObjectFactory<FollowForAim> pool;

    private bool isSpawnZomber;

    private void Start()
    {
        StartCoroutine(SpawnZombie());
        StartCoroutine(CalculateZombie());
    }

    IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(5);
        ZombieAttack();
        StartCoroutine(SpawnZombie());
    }

    IEnumerator CalculateZombie()
    {
        yield return new WaitForSeconds(1);
        CheckZombie();
        StartCoroutine(CalculateZombie());
    }

    void CheckZombie()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= 10)
            isSpawnZomber = false;
        else 
            isSpawnZomber = true;
    }

    void ZombieAttack()
    {
        if (isSpawnZomber == true)
        {
            spawnZombieFactory = new CreateGameZombie(oneTransform);
            spawnZombieFactory.SpawnerGameZombie();


            spawnZombieFactory = new CreateGameZombie(twoTansform);
            spawnZombieFactory.SpawnerGameZombieBig();


            spawnZombieFactory = new CreateGameZombieBig(threeTansform);
            spawnZombieFactory.SpawnerGameZombie();


            spawnZombieFactory = new CreateGameZombieBig(fourTansform);
            spawnZombieFactory.SpawnerGameZombieBig();
        }
        else
        {
            spawnZombieFactory = null;
        }
    }

    public GameObject CreatePrefab(GameObject prefabsStandart, Vector3 vector3, Quaternion identity)
    {
        var spawnPosition = transform.position;
        var shit = this.pool.GetFreeElement();
        shit.transform.position = spawnPosition;
        return prefabsStandart;
    }
}
