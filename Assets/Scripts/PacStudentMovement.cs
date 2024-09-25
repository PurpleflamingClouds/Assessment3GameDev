using System.Collections;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector3[] positions;
    private int currentPoint = 0;
    public AudioSource audioSource;

    void Start()
    {

        positions = new Vector3[4];
        positions[0] = new Vector3(-4.87f, 1.55f, 0f);
        positions[1] = new Vector3(-1.64f, 1.55f, 0f);
        positions[2] = new Vector3(-1.64f, -0.69f, 0f);
        positions[3] = new Vector3(-4.91f, -0.54f, 0f);
        StartCoroutine(MoveInClockwise());
    }

    IEnumerator MoveInClockwise()
    {
        while (true)
        {

            Vector3 startPoint = positions[currentPoint];
            Vector3 endPoint = positions[(currentPoint + 1) % 4];


            StartCoroutine(MovingAudio());


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

    IEnumerator MovingAudio()
    {
        while (true)
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
