using System.Collections;
using UnityEngine;

public class AnimationBoarder : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector3[] positions;
    private int currentPoint = 0;


    void Start()
    {

        positions = new Vector3[4];
        positions[0] = new Vector3(-10.5f, 4.0f, 0f);
        positions[1] = new Vector3(10.5f, 4.0f, 0f);
        positions[2] = new Vector3(10.50f, -4.0f, 0f);
        positions[3] = new Vector3(-10.51f, -4.0f, 0f);
        StartCoroutine(MoveInClockwise());
    }

    IEnumerator MoveInClockwise()
    {
        while (true)
        {

            Vector3 startPoint = positions[currentPoint];
            Vector3 endPoint = positions[(currentPoint + 1) % 4];


            yield return StartCoroutine(MoveToPosition(startPoint, endPoint));


            currentPoint = (currentPoint + 1) % 4;
        }
    }

    IEnumerator MoveToPosition(Vector3 startPoint, Vector3 endPoint)
    {
        float distance = Vector3.Distance(startPoint, endPoint);
        float travelTime = distance / speed;
        float elapsedTime = 0f;


        while (elapsedTime < travelTime)
        {
            transform.position = Vector3.Lerp(startPoint, endPoint, elapsedTime / travelTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        transform.position = endPoint;
    }

    
}
