using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawn : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] Attacker attackerPrefab;

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAttacker()
    {
        Instantiate(attackerPrefab, transform.position, transform.rotation);
    }

}
