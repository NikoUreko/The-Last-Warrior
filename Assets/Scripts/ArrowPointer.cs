using UnityEngine;
using UnityEngine.UI;

public class ArrowPointer : MonoBehaviour
{
    public Transform player;          // Referensi ke player
    public Transform target;          // Referensi ke target/tujuan
    public RectTransform arrowUI;     // Panah UI di canvas
    public float rotationSpeed = 5f;  // Semakin besar, semakin cepat rotasinya

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
       if(!MissionManager.Instance.missionCompleted)
        {
            arrowUI.gameObject.SetActive(false);
            return;
        }

        arrowUI.gameObject.SetActive(true);

       if (player == null || target == null || arrowUI == null) return;

        // Ambil posisi arah dari player ke target (hanya pada bidang XZ)
        Vector3 toTarget = target.position - player.position;
        toTarget.y = 0; // Abaikan tinggi

        // Ambil arah hadap player
        Vector3 playerForward = player.forward;
        playerForward.y = 0;

        // Hitung sudut antara player dan target
        float angle = Vector3.SignedAngle(playerForward, toTarget, Vector3.up);

        // Buat rotasi target untuk panah UI (sumbu Z karena UI)
        Quaternion targetRotation = Quaternion.Euler(0, 0, -angle); // Minus karena UI rotasi searah jarum jam

        // Smooth rotasi panah
        arrowUI.rotation = Quaternion.Lerp(arrowUI.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
