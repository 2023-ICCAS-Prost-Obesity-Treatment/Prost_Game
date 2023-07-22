using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float mapSpeed = 10f;

    private void Update()
    {
        if (!DataManager.Instance.PlayerDie)
        {
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }

    }

    public GameObject[] itemSet;
    private void OnEnable()
    {
        for (int temp = 0; temp < itemSet.Length; temp++)
        {
            itemSet[temp].SetActive(true);
        }
    }
}
