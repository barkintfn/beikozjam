using UnityEngine;

public class WaterKontrol : MonoBehaviour
{
    public Transform respawnNoktasi; // Karakterin respawn yapacağı nokta

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KarakterTag")) // Karakterin tag'ini kullanarak kontrol edebilirsiniz
        {
            KarakterRespawn(other.gameObject);
        }
    }

    private void KarakterRespawn(GameObject karakter)
    {
        // Karakteri respawn noktasına geri yerleştir
        karakter.transform.position = respawnNoktasi.position;
        karakter.transform.rotation = respawnNoktasi.rotation;

        // İsterseniz ekstra işlemler de ekleyebilirsiniz
        Debug.Log("Karakter respawn yapıldı!");
    }
}
