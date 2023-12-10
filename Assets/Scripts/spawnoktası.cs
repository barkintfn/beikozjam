using UnityEngine;

public class CameraSpawnPoint : MonoBehaviour
{
    public GameObject cameraPrefab; // Kamera prefab'ını bu alandan sürükleyip bırakabilirsiniz.
    public float transitionDelay = 2f; // Kameranın doğduktan sonra geçiş yapmadan önce bekleme süresi.

    void Start()
    {
        SpawnCamera();
    }

    void SpawnCamera()
    {
        if (cameraPrefab != null)
        {
            // Kamera örneğini oluşturun ve spawn noktasına yerleştirin.
            GameObject cameraInstance = Instantiate(cameraPrefab, transform.position, Quaternion.identity);

            // Kamera örneğini spawn noktasının çocuğu yapabilirsiniz (isteğe bağlı).
            cameraInstance.transform.parent = transform;

            // Belirtilen süre sonra MainCamera'ya geçiş yapacak fonksiyonu başlatın.
            Invoke("SwitchToMainCamera", transitionDelay);
        }
        else
        {
            Debug.LogError("Kamera prefab'ını atamayı unuttunuz!");
        }
    }

    void SwitchToMainCamera()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Kamerayı etkinleştirin veya başka bir geçiş işlemi gerçekleştirin.
            mainCamera.enabled = true;

            // Bu spawn noktasındaki kamerayı devre dışı bırakabilirsiniz (isteğe bağlı).
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("MainCamera bulunamadı!");
        }
    }
}
