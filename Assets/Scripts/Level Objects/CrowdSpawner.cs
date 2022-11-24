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
        [SerializeField] private float timeBetweenIndividuals;

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
            for (int i = 0; i < amountOfBystandersPerCrowd; i++)
            {
                TranslateObject translateObject = Instantiate(bystanderPrefab, transform);
                translateObject.transform.position += Vector3.up * (0.048f * Random.Range(-1, 1));
                translateObject.Init(direction);
                yield return new WaitForSeconds(timeBetweenIndividuals);
            }
        }
    }
}