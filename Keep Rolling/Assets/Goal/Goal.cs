using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameController controller;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.RestartLevel();
        }
    }
}
