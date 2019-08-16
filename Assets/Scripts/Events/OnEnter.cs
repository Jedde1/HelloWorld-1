using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class OnEnter : MonoBehaviour
{
    // Is it going to destroy the incoming object?
    public string hitTag = "Player";
    public bool destroySelf = false;
    public bool destroyOther = false;
    public UnityEvent onEnter;

    void HandleCollision(Collider col)
    {
        // If hitTag matches incoming object's tag OR hitTag is set to nothing
        if (hitTag == col.tag)
        {
            // Should the other object be destroyed?
            if (destroyOther)
            {
                Destroy(col.gameObject); // Destroy it!
            }

            // Should this object be destroyed?
            if (destroySelf)
            {
                Destroy(gameObject); // Destroy it!
            }

            // Run Unity Event
            onEnter.Invoke();
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        // Performs collision event for a trigger
        HandleCollision(col);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Performs collision event for a non-trigger
        HandleCollision(collision.collider);
    }
}
