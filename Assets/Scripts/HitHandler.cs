using UnityEngine;
using System.Collections;

public class HitHandler : MonoBehaviour {

    public TrainMovement sendTo;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("RitualGoers"))
        {
            sendTo.HitVillager(col);
        }
    }
}
