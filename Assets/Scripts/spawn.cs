using UnityEngine;

public class NesneKontrol : MonoBehaviour
{
    public float spawnSuresi = 2f; // Nesnenin spawn edildikten sonra geri dönme süresi
    private Vector2 GameplayScene; // Nesnenin başlangıç noktası
    private bool geriDonduMu = false; // Nesne geri döndü mü?

    void Start()
    {
        GameplayScene = transform.position; // Başlangıç noktasını kaydet
        Invoke("GeriDon", spawnSuresi); // Belirli bir süre sonra GeriDon metodunu çağır
    }

    void Update()
    {
        // Nesne henüz geri dönmediyse ve belirli bir koşulu kontrol etmek istiyorsanız:
        if (!geriDonduMu)
        {
            // Koşulu kontrol etmek için gerekli kodu buraya ekleyin
            // Örneğin, Input.GetKeyDown(KeyCode.Space) gibi bir şey
        }
    }

    void GeriDon()
    {
        transform.position = GameplayScene; // Nesneyi başlangıç noktasına geri taşı
        geriDonduMu = true; // Nesne geri döndü
    }
}
