using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableRing : MonoBehaviour
{
    public float lifeTime;
    public float growSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }
    private void Update()
    {
        gameObject.transform.localScale += growSpeed * Time.deltaTime * Vector3.one;
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
