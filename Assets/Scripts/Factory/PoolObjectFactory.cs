using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolObjectFactory<T> where T : MonoBehaviour
{
    public static PoolObjectFactory<T> instance;

    public T prefab { get; }

    public bool autoExpend { get; set; }

    public Transform container { get; }

    private List<T> gameObjects = new List<T>();

    private int poolCount = 20;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private T GetPrefab()
    {
        return prefab;
    }

    private void Start(T prefab)
    {
        for (int i = 0; i < poolCount; i++)
        {
            prefab = Object.Instantiate(prefab);
            prefab.gameObject.SetActive(false);
            gameObjects.Add(prefab);
        }
    }


    public PoolObjectFactory(T prefab, int count)
    {
        this.prefab = prefab;
        this.container = container;
        this.CreatePool(count);
    }

    public PoolObjectFactory(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.gameObjects = new List<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createObject = Object.Instantiate(this.prefab, this.container);
        createObject.gameObject.SetActive(isActiveByDefault);
        this.gameObjects.Add(createObject);
        return createObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in gameObjects)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
            return element;
        if (this.autoExpend)
            return this.CreateObject(true);
        else
            Debug.Log($"There is no free elements in pool {typeof(T)}");
        return null;
    }
}
