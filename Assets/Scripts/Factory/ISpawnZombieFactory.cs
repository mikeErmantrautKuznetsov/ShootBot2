using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISpawnZombieFactory : MonoBehaviour
{
    public abstract GameObject SpawnerGameZombie();

    public abstract GameObject SpawnerGameZombieBig();
}
