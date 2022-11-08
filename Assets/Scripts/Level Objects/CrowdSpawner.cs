using System.Collections;
using UnityEngine;

namespace Level_Objects
{
    public class CrowdSpawner : MonoBehaviour
    {
        [SerializeField] private TranslateObject bystanderPrefab;
        [SerializeField] private Vector2 direction;
        [SerializeField] private float timeBetweenCrowds;
        [SerializeField] private float initialTime;
        [SerializeField] private int amountOfBystandersPerCrowd;

        private float timeUntilNextCrowd;

        private void Start()
        {
            timeUntilNextCrowd = initialTime;
        }

        private void Update()
        {
            timeUntilNextCrowd -= Time.deltaTime;
            
            if (timeUntilNextCrowd <= 0)
            {
                StartCoroutine(SpawnCrowd());
                timeUntilNextCrowd = timeBetweenCrowds;
            }
        }

        private IEnumerator SpawnCrowd()
        {
            float timeBetweenBystandersInCrowd = 0.03f / direction.magnitude;
            for (int i = 0; i < amountOfBystandersPerCrowd; i++)
            {
                TranslateObject translateObject = Instantiate(bystanderPrefab, transform);
                translateObject.Init(direction);
                yield return new WaitForSeconds(timeBetweenBystandersInCrowd);
            }
        }
    }
}