using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletObject;
    public float bulletSpd = 0.1f;
    public float spd = 1.0f;

    private float timeElapsed = 0.0f;
    public float interval = 2.0f;

    private float scaleX = 1.0f;
    private float spdX = 0.0f;
    private float spdY = 0.0f;

    void Update()
    {
        spdX = 0.0f;
        spdY = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            spdY = spd;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            spdY = spd * -1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            spdX = spd;

            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                scaleX = 1.0f;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spdX = spd * -1.0f;

            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                scaleX = -1.0f;
            }
        }
    }

    void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;

        if (interval < timeElapsed)
        {
            Fire();
            timeElapsed = 0.0f;
        }

        //���W�̍X�V
        Vector2 position = gameObject.transform.position;
        gameObject.transform.position = new Vector3(position.x + spdX, position.y + spdY);

        //���E�̍X�V
        Vector2 scale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(scaleX, scale.y);
    }

    void Fire()
    {
        //Debug.Log("Fire");
        GameObject copiedBullet1 = Instantiate(bulletObject, gameObject.transform.position, Quaternion.identity);
        Bullet bullet1 = copiedBullet1.GetComponent<Bullet>();

        bullet1.spdX = scaleX == 1.0f ? bulletSpd : bulletSpd * -1.0f;
    }

    //Trigger���d�Ȃ����u�ԂɌĂ΂��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player HIT");
        gameObject.SetActive(false);
    }

    //Trigger���d�Ȃ��Ă���Ԃ����ƌĂ΂��
    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    //Trigger�����ꂽ�u�ԂɌĂ΂��
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
