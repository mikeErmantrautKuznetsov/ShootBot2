using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public static PoolObjects instance;
    private List<GameObject> objects = new List<GameObject>();
    private int amountBullet = 30;
    [SerializeField]
    private GameObject bulletPrefabs;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        for (int i = 0; i < amountBullet; i++)
        {
            GameObject prefabs = Instantiate(bulletPrefabs);
            prefabs.SetActive(false);
            objects.Add(prefabs);
        }
    }

    public GameObject GetFreeElement()
    {
        for(int i = 0;i < objects.Count;i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }
        return null;
    }
}
