using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControl : MonoBehaviour
{
    public Transform controlCamera;
    public Transform cameraFollowPT;
    public Transform gunRoot;
    public Transform fireRoot;
    public Object hitEffect;
    public AudioClip shootAudio;


    public float rotateSpeed = 1.0f;
    public float moveSpeed = 2.0f;
    public float cameraH = 0.0f;
    private float gunDistance = 500.0f;

    void Start()
    {
        Vector3 cameraVec = controlCamera.position - transform.position;
        cameraH = cameraVec.y;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        float rotateAmountX = rotateSpeed * mouseX;

        transform.Rotate(0, rotateAmountX, 0);

        controlCamera.Rotate(0, rotateAmountX, 0, Space.World);
        controlCamera.Rotate(mouseY, 0, 0, Space.Self);
        gunRoot.Rotate(mouseY, 0, 0, Space.Self);



        float fMoveV = Input.GetAxis("Vertical");
        float fMoveH = Input.GetAxis("Horizontal");

        Vector3 vForward = transform.forward;
        Vector3 vRigght = transform.right;

        Vector3 moveAmount = (vRigght * fMoveV - vForward * fMoveH) * moveSpeed * Time.deltaTime;
        transform.position = transform.position + moveAmount;
        controlCamera.position = Vector3.Lerp(transform.position, cameraFollowPT.position, 0.8f);

        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(shootAudio, transform.position);

            Vector3 temPos = controlCamera.position + controlCamera.forward * gunDistance;
            Vector3 fireDirection = temPos - fireRoot.position;
            fireDirection.Normalize();

            Ray rayGun = new Ray(fireRoot.position, fireDirection);
            int targetMask = 1 << LayerMask.NameToLayer("Enemy") | 1 << LayerMask.NameToLayer("Terrain") | 1 << LayerMask.NameToLayer("Wall");

            RaycastHit rh = new RaycastHit();
            bool bHit = Physics.Raycast(rayGun, out rh, gunDistance, targetMask);

            if (bHit)
            {
                GameObject gEffect = Instantiate(hitEffect) as GameObject;
                gEffect.transform.position = rh.point;
                gEffect.transform.forward = rh.normal;

                if (rh.collider.tag == "enemy")
                {
                    GameObject ey = rh.collider.gameObject;
                    ey.SendMessage("Damage", 30.0f);

                }

            }

        }
    }


}
