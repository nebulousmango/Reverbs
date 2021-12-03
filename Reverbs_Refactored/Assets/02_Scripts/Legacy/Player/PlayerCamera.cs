using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform tr_Player;
    float f_posX;
    float f_posY;
    Vector3 v3_newPos;

    private void Update()
    {
        f_posX = tr_Player.position.x;
        f_posY = tr_Player.position.y;
        v3_newPos.x = f_posX;
        v3_newPos.y = f_posY;
        v3_newPos.z = transform.position.z;
        transform.position = v3_newPos;
    }

    public void SetTransform()
    {
        tr_Player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }
}