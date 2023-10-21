using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalStopper : MonoBehaviour
{
    private int _grade;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Runner runner))
        {
            runner.Finish(_grade++);
        }
    }
}
