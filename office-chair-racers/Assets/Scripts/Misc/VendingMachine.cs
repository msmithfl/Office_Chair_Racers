using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] sodaCans = new GameObject[3];
    [SerializeField] private Transform canSpawnPoint;
    [SerializeField] private float canForce = 5;
    [SerializeField] private float spawnTime = 10f;
    [SerializeField] private Transform cansContainer;

    private Animator myAnim;

    private bool canTimerIsActive;

    private void Start()
    {
        canTimerIsActive = false;
        myAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.relativeVelocity.magnitude > 3f)
            {
                myAnim.SetTrigger("wasHit");

                if (!canTimerIsActive)
                {
                    SpawnCan();
                    StartCoroutine(NewCanTimer());
                }
            } 
        }
    }

    IEnumerator NewCanTimer()
    {
        yield return new WaitForSeconds(spawnTime);
        canTimerIsActive = false;
    }

    void SpawnCan()
    {
        int randNum = Random.Range(0, sodaCans.Length);

        Vector3 pos = canSpawnPoint.transform.position;
        Quaternion rotation = canSpawnPoint.transform.rotation;
        var instance = Instantiate(sodaCans[randNum], pos, rotation);
        instance.transform.parent = cansContainer.transform;
        instance.GetComponent<Rigidbody>().AddForce(Vector3.back * canForce);
        canTimerIsActive = true;
    }
}
