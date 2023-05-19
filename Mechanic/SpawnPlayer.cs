using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject Player { set { _player = value; } }
    [SerializeField] Transform _spawnTarget, _moveTarget;
    [SerializeField] float _spawnDelay = 1f;
    [SerializeField] GameObject _player;
    Reference _references;

    private void Awake()
    {
        _references = FindObjectOfType<Reference>();
    }
    public void Spawn()
    {
        if (!_references.GameIsOver)
            Invoke("SpawnLoop", _spawnDelay);
    }

    void SpawnLoop()
    {
        GameObject player =
        Instantiate(_player,
        _spawnTarget.position,
        _player.transform.rotation);

        player.GetComponent<MoveForward>().Target = _moveTarget;
    }
}
