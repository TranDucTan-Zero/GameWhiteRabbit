using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diemtheogioi : MonoBehaviour
{
    [SerializeField] private GameObject[] diemduong;
    private int chisoduongdiemhientai = 0;
    [SerializeField] private float tocdo = 5f;
    private void Update()
    {
        if (diemduong == null || diemduong.Length == 0)
        {
            // Không có điểm đường nào được chỉ định trong inspector
            return;
        }

        if (Vector2.Distance(diemduong[chisoduongdiemhientai].transform.position, transform.position) < .1f)
        {
            chisoduongdiemhientai++;
            if (chisoduongdiemhientai >= diemduong.Length)
            {
                chisoduongdiemhientai = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, diemduong[chisoduongdiemhientai].transform.position, Time.deltaTime * tocdo);
    }
}
