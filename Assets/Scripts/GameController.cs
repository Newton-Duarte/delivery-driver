using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] List<Package> packagesList = new();
    [SerializeField] TextMeshProUGUI txtDeliveries;

    AudioController _audioController;
    int deliveriesCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _audioController = FindAnyObjectByType<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeliverPackage(Package package)
    {
        deliveriesCount++;
        txtDeliveries.SetText(deliveriesCount.ToString());
        packagesList.Remove(package);
        Destroy(package.gameObject);
        _audioController.DeliveryFX();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
