using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPlatform : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] GameObject[] _platformsPrefab;
    [Space]
    [SerializeField] int _stepsCountToSpawn;
    [SerializeField] int _stepsCountToDelite;
    [SerializeField] float _stepsHeight;
    [SerializeField] Vector3 _bounds;
    [SerializeField] Vector3 _bounds2;

    private Queue<GameObject> _spawnedPlatforms;

    private float _lastPlatformSpawnedOnPlayerPosition;
    private float _lastPlatformDelitedOnPlayerPosition;

    void Awake()
    {
        _spawnedPlatforms = new Queue<GameObject>();
        _lastPlatformDelitedOnPlayerPosition = _lastPlatformSpawnedOnPlayerPosition = _target.position.z;

        for(int i = 0; i < _stepsCountToSpawn; i++)
        {
            SpawnPlatform(i+1);
        }
    }

    void Update()
    {
        if(_target.position.z - _lastPlatformSpawnedOnPlayerPosition > _stepsHeight)
        {
            SpawnPlatform(_stepsCountToSpawn);
            _lastPlatformSpawnedOnPlayerPosition += _stepsHeight;
        }
        if(_target.position.z - _lastPlatformDelitedOnPlayerPosition > _stepsHeight * _stepsCountToDelite)
        {
            var platformToDelite = _spawnedPlatforms.Dequeue();
            if(platformToDelite && platformToDelite.gameObject)
            {
                Destroy(platformToDelite.gameObject);
            }
            _lastPlatformDelitedOnPlayerPosition += _stepsHeight;
        }
    }

    private void SpawnPlatform(int _stepsCount)
    {
        var platformPositionX = Random.Range(_bounds.x, _bounds.x);
        var platformPositionY = Random.Range(_bounds.y, _bounds.y);
        var platformPositionZ = _target.position.z + _stepsCount * _stepsHeight;

        var platformPosition = new Vector3(platformPositionX, platformPositionY, platformPositionZ);

        var platformPrefab = _platformsPrefab[Random.Range(0, _platformsPrefab.Length)];

        var spawnPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity, this.transform);

        _spawnedPlatforms.Enqueue(spawnPlatform);
    }
}
