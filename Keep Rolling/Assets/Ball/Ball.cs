using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameController controller;

    void Start()
    {
        controller = GameObject.FindWithTag("GameController")
            .GetComponent<GameController>();
    }

    void Update()
    {
        var worldCenter = new Vector3(0f, 0f, 0f);
        var distanceToWorldCenter = Vector3.Distance(transform.position, worldCenter);

        if (distanceToWorldCenter > 20f)
        {
            controller.RestartLevel();
        }
    }
}
