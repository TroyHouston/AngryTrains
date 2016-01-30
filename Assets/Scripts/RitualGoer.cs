using UnityEngine;
using System.Collections;

public abstract class RitualGoer : MonoBehaviour {

    public bool startUp;
    
    public virtual void StartAnimation (float rngStartTime) {}

    protected virtual void AnimateRitual () {}
    
    // TODO Ryan Train Interaction
    public virtual void Die (Collider col) {}
}
