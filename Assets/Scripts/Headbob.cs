using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    //Time to take going up. 
    [SerializeField] private float timeBetweenPhases;

    //Height to rise.
    [SerializeField] private float deltaHeight;

    private Vector3 initPosition;
    private Vector3 finalPosition;

	// Use this for initialization
	void Start ()
	{
        //Calculate initial and final positions to loop between.
	    initPosition = transform.position;

	    finalPosition = transform.position + new Vector3(0, deltaHeight, 0);

	    StartCoroutine(Bob());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Bob()
    {
        while (true)
        {
            // Go up.
            for (float timeUp = 0; timeUp < timeBetweenPhases + (Random.Range(-0.1f, 0.1f)); timeUp += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(initPosition, finalPosition, Mathf.SmoothStep(0.0f, 1.0f, timeUp / timeBetweenPhases));
                yield return null;

            }

            // Go down.
            for (float timeDown = 0; timeDown < timeBetweenPhases + (Random.Range(-0.1f, 0.1f)); timeDown += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(finalPosition, initPosition, Mathf.SmoothStep(0.0f, 1.0f, timeDown / timeBetweenPhases));
                yield return null;

            }
        }
    }
}
