using UnityEngine;

public class RetroCameraJitter : MonoBehaviour
{
    public float jitterAmount = 0.02f;
    public float jitterInterval = 0.05f; // co ile sekund zmienia pozycjê

    private Vector3 startPos;
    private Vector3 offset;
    private float timer;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= jitterInterval)
        {
            timer = 0f;

            offset = new Vector3(
                Random.Range(-jitterAmount, jitterAmount),
                Random.Range(-jitterAmount, jitterAmount),
                0
            );
        }

        transform.localPosition = startPos + offset;
    }
}