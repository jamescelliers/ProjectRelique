using UnityEngine;
using System.Collections;

public class HitCollider : MonoBehaviour {

    public float TimeAlive = 1f;

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyAfterTime());
	}

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(TimeAlive);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        print("Hit " + coll.gameObject.name);
    }
}
