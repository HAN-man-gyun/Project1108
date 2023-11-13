using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRegenable
{
    public void Regen()
    {

    }

    public IEnumerator Regenerate()
    {
        yield break;
    }
}
