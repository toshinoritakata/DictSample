using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample2 : MonoBehaviour
{
    void Start()
    {
        foreach (var item in CGWORLD.AnimalDB.Instance.DB.AnimalTable.All)
        {
            Debug.Log($"{item.Id}{item.Classification}{item.Name}{item.Size}");
        }
    }
}
