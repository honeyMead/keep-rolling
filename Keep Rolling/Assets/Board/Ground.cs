using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameController controller;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ground");
            controller.RestartLevel();
        }
    }
}
