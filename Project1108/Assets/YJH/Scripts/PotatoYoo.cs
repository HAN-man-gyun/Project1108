using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoYoo : CollectableYoo
{
    private const float INIT_REGEN_TIME = 8f;

    private State state;
    private WaitForSeconds regenTerm;

    private void Awake()
    {
        state = State.Collectable;
        regenTerm = new WaitForSeconds(INIT_REGEN_TIME);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Collect()
    {
        transform.gameObject.SetActive(false);
        state = State.Collected;
    }

    public void CollectOnPhoton()
    {
        photonView.RPC("Collect", RpcTarget.All);
    }

    protected override void Regen()
    {
        StartCoroutine(Regenerate());
    }

    public void RegenOnPhoton()
    {
        photonView.RPC("Regen", RpcTarget.All);
    }

    protected override IEnumerator Regenerate()
    {
        yield return regenTerm;
        transform.gameObject.SetActive(true);
        state = State.Collectable;
        yield break;
    }
}
