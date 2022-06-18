using System;
using UnityEngine;

public class BoardLogic : MonoBehaviour
{
    public float MaxRotationEuler;
    public float RotationSpeed;

    private Vector3 currentEulerAngles;

    void Update()
    {
        if (Time.timeSinceLevelLoad > 0.2)
        {
            RotateBoard();
        }
    }

    private void RotateBoard()
    {
        var mousePosPercent = GetPercentageOfMousePosition();
        var xPercent = mousePosPercent.Item1;
        var zPercent = mousePosPercent.Item2;

        var targetX = xPercent * MaxRotationEuler;
        var targetZ = zPercent * MaxRotationEuler;

        var differenceToX = targetX - currentEulerAngles.x;
        var differenceToZ = targetZ - currentEulerAngles.z;

        currentEulerAngles += RotationSpeed * Time.deltaTime * new Vector3(differenceToX, 0f, differenceToZ);

        currentEulerAngles.x = LimitAngleToMaximum(currentEulerAngles.x);
        currentEulerAngles.z = LimitAngleToMaximum(currentEulerAngles.z);

        transform.eulerAngles = currentEulerAngles;
    }

    private float LimitAngleToMaximum(float vectorComponent)
    {
        float result = vectorComponent;
        if (Mathf.Abs(vectorComponent) > MaxRotationEuler)
        {
            result = MaxRotationEuler * Mathf.Sign(vectorComponent);
        }
        return result;
    }

    private static Tuple<float, float> GetPercentageOfMousePosition()
    {
        var screenPoint = Input.mousePosition;
        var mousePosition = Camera.main.ScreenToViewportPoint(screenPoint);
        var halfOfViewPort = 0.5f;

        var x = -(halfOfViewPort - mousePosition.y);
        var z = halfOfViewPort - mousePosition.x;

        var maxDisplayPos = 0.5f;
        var xPercent = x / maxDisplayPos;
        var zPercent = z / maxDisplayPos;

        return Tuple.Create(xPercent, zPercent);
    }
}
