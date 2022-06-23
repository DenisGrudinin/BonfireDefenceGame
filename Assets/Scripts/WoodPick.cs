using UnityEngine;

public class WoodPick : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.GetInstance().Wood += 1;
        }
    }
}
