using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float startSpeed = 5.0f;
    [SerializeField] float timeBetweenBoostSpeed = 15.0f;
    Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Bonfire").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, startSpeed * Time.deltaTime);
        timeBetweenBoostSpeed -= Time.deltaTime;
        if (timeBetweenBoostSpeed <= 0)
        {
            startSpeed += WaveManager.currentLvl / 2;
            timeBetweenBoostSpeed = 15.0f;
        }
    }
}
