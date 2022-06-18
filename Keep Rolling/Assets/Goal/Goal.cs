using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameController controller;

    void Start()
    {
        controller = GameObject.FindWithTag("GameController")
            .GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("goal");
            controller.NextLevel();
        }
    }
}
