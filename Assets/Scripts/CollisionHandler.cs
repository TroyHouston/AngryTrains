using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    public TrainMovement sendTo;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("RitualGoers"))
        {
            sendTo.CollideWithVillager(col);
        }
    }
}
