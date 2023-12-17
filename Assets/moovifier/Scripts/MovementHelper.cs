using System;
using System.Collections;
using UnityEngine;

public static class MovementHelper
{
    public static IEnumerator SmoothVector3(Vector3 start, Vector3 destination, float moveSpeed, AnimationCurve curve, Action<Vector3> update, Action callback)
    {
        float dist = Vector3.Distance(start, destination);
        float duration = dist / moveSpeed;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            float progress = timeElapsed / duration;
            Vector3 intermediateVector3 = Vector3.Lerp(start, destination, curve.Evaluate(progress));
            update(intermediateVector3);
            yield return null;

            timeElapsed += Time.deltaTime;
        }

        update(destination);
        callback();
    }

    // same but for Quaternions
    public static IEnumerator SmoothQuaternion(Quaternion start, Quaternion destination, float moveSpeed, AnimationCurve curve, Action<Quaternion> update, Action callback)
    {
        float dist = Quaternion.Angle(start, destination);
        float duration = dist / moveSpeed;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            float progress = timeElapsed / duration;
            Quaternion intermediateQuaternion = Quaternion.Lerp(start, destination, curve.Evaluate(progress));
            update(intermediateQuaternion);
            yield return null;

            timeElapsed += Time.deltaTime;
        }

        update(destination);
        callback();
    }
}
