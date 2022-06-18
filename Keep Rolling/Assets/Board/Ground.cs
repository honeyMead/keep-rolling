using UnityEngine;

public class Ground : MonoBehaviour
{
    private GameController controller;

    void Start()
    {
        controller = GameObject.FindWithTag("GameController")
            .GetComponent<GameController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ground");
            controller.RestartLevel();
        }
    }
}
