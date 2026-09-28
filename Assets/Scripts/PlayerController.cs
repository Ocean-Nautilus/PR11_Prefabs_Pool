using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;     
    public float limitX = 8.5f;    

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * moveX * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);
        transform.position = pos;
    }
}