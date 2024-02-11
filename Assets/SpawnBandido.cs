using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBandido : MonoBehaviour
{
    float spawnTimer;
    bool _isPerformingAction = false;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bandido;

    void Start()
    {
        Instantiate(bandido, spawnPoint);
        spawnTimer = 5f;
    }

    void Update()
    {
        if (_isPerformingAction)
        {
            return;
        }
        StartCoroutine(TransitionTo());
    }

    private IEnumerator TransitionTo()
    {
        _isPerformingAction = true;
        yield return new WaitForSeconds(spawnTimer);
        Instantiate(bandido, spawnPoint);
        _isPerformingAction = false;
        Debug.Log(spawnPoint.position);
    }
}
