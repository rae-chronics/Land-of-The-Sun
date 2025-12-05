using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public Collectable[] collectablePrefabs;

    private Dictionary<CollectableType, Collectable> collectableItemsDict =
        new Dictionary<CollectableType, Collectable>();

    private void Awake()
    {
        // set singleton
        Instance = this;

        // load dictionary
        foreach (Collectable item in collectablePrefabs)
        {
            AddItem(item);
        }
    }

    private void AddItem(Collectable item)
    {
        if (!collectableItemsDict.ContainsKey(item.type))
        {
            collectableItemsDict.Add(item.type, item);
        }
    }

    public Collectable GetItemByType(CollectableType type)
    {
        if (collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }

        return null;
    }
}
