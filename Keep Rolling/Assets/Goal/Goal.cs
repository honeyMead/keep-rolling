using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameController controller;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("goal");
            controller.NextLevel();
        }
    }
}
