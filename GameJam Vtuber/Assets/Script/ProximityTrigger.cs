using UnityEngine;
using System.Collections.Generic; // Penting: tambahkan ini untuk menggunakan List

public class ProximityTrigger : MonoBehaviour
{
    [Header("Trigger Settings")]
    [Tooltip("Tag objek yang akan memicu event (biasanya 'Player').")]
    [SerializeField] private string targetTag = "Player";

    [Header("On Trigger Enter (Masuk)")]
    [Tooltip("Objek yang akan diaktifkan saat 'Player' masuk trigger.")]
    public List<GameObject> activateOnEnter = new List<GameObject>();
    [Tooltip("Objek yang akan dinonaktifkan saat 'Player' masuk trigger.")]
    public List<GameObject> deactivateOnEnter = new List<GameObject>();

    [Header("On Trigger Stay (Tetap Berada di Dalam)")]
    [Tooltip("Objek yang akan diaktifkan saat 'Player' tetap berada di dalam trigger.")]
    public List<GameObject> activateOnStay = new List<GameObject>();
    [Tooltip("Objek yang akan dinonaktifkan saat 'Player' tetap berada di dalam trigger.")]
    public List<GameObject> deactivateOnStay = new List<GameObject>();

    [Header("On Trigger Exit (Keluar)")]
    [Tooltip("Objek yang akan diaktifkan saat 'Player' keluar dari trigger.")]
    public List<GameObject> activateOnExit = new List<GameObject>();
    [Tooltip("Objek yang akan dinonaktifkan saat 'Player' keluar dari trigger.")]
    public List<GameObject> deactivateOnExit = new List<GameObject>();

    [Header("Self Deactivation")]
    [Tooltip("Apakah trigger ini harus menonaktifkan dirinya sendiri setelah digunakan (hanya sekali di Enter)?")]
    public bool deactivateSelfOnEnter = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log($"'{targetTag}' masuk ke trigger {gameObject.name}.");
            SetObjectsActive(activateOnEnter, true);
            SetObjectsActive(deactivateOnEnter, false);

            if (deactivateSelfOnEnter)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            // Logika untuk saat pemain TETAP berada di dalam collider
            // Perhatikan: ini akan dipanggil setiap frame saat pemain di dalam trigger.
            // Gunakan dengan bijak agar tidak membebani performa.
            SetObjectsActive(activateOnStay, true);
            SetObjectsActive(deactivateOnStay, false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log($"'{targetTag}' keluar dari trigger {gameObject.name}.");
            SetObjectsActive(activateOnExit, true);
            SetObjectsActive(deactivateOnExit, false);
        }
    }

    /// <summary>
    /// Metode pembantu untuk mengatur status aktif dari daftar GameObject.
    /// </summary>
    /// <param name="objectList">Daftar GameObject yang akan diatur.</param>
    /// <param name="isActive">True untuk mengaktifkan, False untuk menonaktifkan.</param>
    private void SetObjectsActive(List<GameObject> objectList, bool isActive)
    {
        if (objectList == null || objectList.Count == 0)
        {
            return;
        }

        foreach (GameObject obj in objectList)
        {
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
            else
            {
                Debug.LogWarning("Objek null ditemukan dalam daftar di ProximityTrigger: " + gameObject.name);
            }
        }
    }
}