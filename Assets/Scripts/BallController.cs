using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public bool isMoving;
    private Vector3 moveDirection;
    private Vector3 nextCollisionPosition;

    public int minSwipeRecognition = 500;
    private Vector2 swipePositionLastFrame;
    private Vector2 swipePositionCurrentFrame;
    private Vector2 currentSwipe;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = speed * Vector3.right;

            if (Vector3.Distance(transform.position, nextCollisionPosition) < 1)
            {
                isMoving = false;
                moveDirection = Vector3.zero; // TOPUMUZUN ARTIK HAREKET ETMESİNİ İSTEMEDİĞİMİZ İÇİN DURDURUYORUZ.
                nextCollisionPosition = Vector3.zero; // BİR SONRAKi SWİPE İŞLEMİNDE YERİ AYARLANACAK O YÜZDEN ŞU AN SIFIR.
            }
        }

        if (isMoving)
        {
            return;
        }

        if (Input.GetMouseButton(0)) // PARMAKLA VEYA MOUSE İLE DOKUNSAMDA İKİSİ İÇİNDE ÇALIŞIYOR.
        {
            swipePositionCurrentFrame = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}