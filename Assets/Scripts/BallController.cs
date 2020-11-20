using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 15;
    public int minSwipeRecognition = 1000;
    private bool isMoving;

    private Vector3 moveDirection;
    private Vector3 nextCollisionPosition;

    private Vector2 swipePosisitonLast;
    private Vector2 swipePosisitionCurrent;
    private Vector2 currentSwipe;


    private void FixedUpdate()
    {
        // TOPUN HIZI AYARLANIYOR
        if (isMoving)
        {
            rb.velocity = moveDirection * speed;
        }

        // HEDEFE ULAŞIP ULAŞMADIĞIMIZIN KONTROLÜ
        if (nextCollisionPosition != Vector3.zero)
        {
            if (Vector3.Distance(transform.position, nextCollisionPosition) < 1)
            {
                isMoving = false;
                moveDirection = Vector3.zero;
                nextCollisionPosition = Vector3.zero;
            }
        }

        if (isMoving)
            return;

        // SWİPE İŞLEMİ BURADA YAPILIYOR
        if (Input.GetMouseButton(0))
        {
            // MOUSE ŞU AN NEREDE
            swipePosisitionCurrent = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (swipePosisitonLast != Vector2.zero)
            {
                // SWİPE YÖNÜNÜ HESAPLIYORUZ 
                currentSwipe = swipePosisitionCurrent - swipePosisitonLast;

                // BİZİM BELİRLEDİĞİMİZ MİNİMUM MESAFEDEN KÜÇÜKSE HİÇBİR ŞEY YAPMIYORUZ, EĞER BÜYÜKSE HAREKETİ SAĞLIYORUZ.
                if (currentSwipe.sqrMagnitude < minSwipeRecognition)
                    return;

                currentSwipe
                    .Normalize(); // MESAFEYİ DEĞİL, SADECE YÖNÜ ELDE ETMEK İÇİN 

                // YUKARI - AŞAĞI SWİPE 
                if (currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    SetDestination(currentSwipe.y > 0 ? Vector3.forward : Vector3.back);
                }

                // SAĞ - SOL SWİPE
                if (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    SetDestination(currentSwipe.x > 0 ? Vector3.right : Vector3.left);
                }
            }

            swipePosisitonLast = swipePosisitionCurrent;
        }

        // PARMAĞI - MOUSE KALDIRDIĞIMIZ ZAMAN NE OLACAĞINI BURADA BELİRTİYORUZ
        if (Input.GetMouseButtonUp(0))
        {
            swipePosisitonLast = Vector2.zero;
            currentSwipe = Vector2.zero;
        }
    }

    private void SetDestination(Vector3 direction)
    {
        moveDirection = direction;

        // ÇARPIŞACAĞIMIZ YERİN TESPİTİ YAPILIYOR. 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 100f))
        {
            nextCollisionPosition = hit.point;
        }

        isMoving = true;
    }
}