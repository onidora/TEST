using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public float spdMove = 0.5f;

    private GameObject target;

    //Triggerが重なった時に呼ばれる
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy Damage");

        hp--;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        //プレイヤーを取得        
        if (target == null) return;

        //プレイヤーと自分の角度を取得
        float moveDir = GetAngle(gameObject.transform.position, target.transform.position);

        //プレイヤーの方向に移動
        Vector3 movement = GetMovement(spdMove, moveDir);
        gameObject.transform.position += movement;

    }

    public float GetAngle(Vector2 from, Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        float deg = rad * Mathf.Rad2Deg;
        return (deg - 90.0f) * -1.0f;
    }

    public Vector3 GetMovement(float spd, float dir)
    {
        return new Vector3(spd * Mathf.Sin(dir * Mathf.Deg2Rad), spd * Mathf.Cos(dir * Mathf.Deg2Rad), 0);
    }
}
