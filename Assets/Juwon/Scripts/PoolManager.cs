using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    [SerializeField] private GameObject[] prefabs;
    List<GameObject>[] pools;


    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach(GameObject item in pools[index]) {
            if(!item.activeSelf) {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select) {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        return select;
    }
}
