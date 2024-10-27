using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherryPrefab;
    private float spawnInterval = 10f; 
    private float movementSpeed = 2f; 
    private Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(SpawnCherry());
    }

    private IEnumerator SpawnCherry()
    {
        while (true)
        {

            yield return new WaitForSeconds(spawnInterval);
            Spawn();
        }
    }

    private void Spawn()
    {

        float minX = -7f;
        float maxX = 13f;
        float minY = -17f;
        float maxY = 3.3f;

        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);


        targetPosition = new Vector3(spawnPosition.x < 3.05f ? 13f : -7f, spawnPosition.y < -6.75f ? 3.3f : -17f, 0);


        GameObject cherry = Instantiate(cherryPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(MoveCherry(cherry));
    }

    private IEnumerator MoveCherry(GameObject cherry)
    {
        Vector3 startPosition = cherry.transform.position;
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (cherry != null)
        {
            float distanceCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            cherry.transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);


            if (fractionOfJourney >= 1f)
            {
                Destroy(cherry);
                break;
            }

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PacStudent"))
        {

            Destroy(gameObject); 
        }
    }

}