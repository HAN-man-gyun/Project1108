using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class CollectableYoo : MonoBehaviourPun, IRegenable
{
    protected float regenTime;
    protected WaitForSeconds regenTerm;
    protected enum State
    {
        Collectable, Collected
    }

    protected virtual void Collect()
    {

    }    

    protected virtual void Regen()
    {

    }

    protected virtual IEnumerator Regenerate()
    {
        yield break;
    }
}
