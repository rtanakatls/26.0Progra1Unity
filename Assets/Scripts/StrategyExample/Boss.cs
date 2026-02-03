using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private IBossStrategy currentStrategy;

    private void Start()
    {
        StartCoroutine(BossPhases());
    }

    private IEnumerator BossPhases()
    {
        currentStrategy = new BossPhase1(GetComponent<Rigidbody>(),10);
        yield return new WaitForSeconds(10);
        currentStrategy.End();

        currentStrategy = new BossPhase2(transform,GetComponent<Rigidbody>());
        yield return new WaitForSeconds(10);
        currentStrategy.End();
    }


    void Update()
    {
        currentStrategy?.Execute();
    }
}
