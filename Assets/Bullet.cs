using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float spdX = 0.0f;
    public float spdY = 0.0f;
    public float lifeTime = 2.0f;

    SpriteRenderer renderer;

    private float timeElapsed = 0.0f;

    private void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;
        if (lifeTime < timeElapsed)
        {
            Destroy(gameObject);
        }

        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x + spdX,
            gameObject.transform.position.y + spdY,
            gameObject.transform.position.z);
    }

    //Trigger‚ªd‚È‚Á‚½Žž‚ÉŒÄ‚Î‚ê‚é
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
