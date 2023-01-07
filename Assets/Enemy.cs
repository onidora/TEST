using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public float spdMove = 0.5f;

    private GameObject target;

    //Trigger���d�Ȃ������ɌĂ΂��
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
        //�v���C���[���擾        
        if (target == null) return;

        //�v���C���[�Ǝ����̊p�x���擾
        float moveDir = GetAngle(gameObject.transform.position, target.transform.position);

        //�v���C���[�̕����Ɉړ�
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
