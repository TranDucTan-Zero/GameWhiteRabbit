using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luoicuaquay : MonoBehaviour
{
    [SerializeField] private float tocdo = 2f;// toc do quay
   private void Update()
    {
        transform.Rotate(0, 0, 360 * tocdo * Time.deltaTime); //xoay vong tron + voi thoi gian quay
    }
}
