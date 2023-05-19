using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    [SerializeField] GameObject _prefab;

    public void OnChangePlayer()
    {
        SpawnPlayer spawner = FindObjectOfType<SpawnPlayer>();
        spawner.Player = _prefab;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        spawner.Spawn();
    }

}
