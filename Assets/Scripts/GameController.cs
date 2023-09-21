using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<Package> packagesList = new();

    AudioController _audioController;

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
        packagesList.Remove(package);
        Destroy(package.gameObject);
        _audioController.DeliveryFX();
    }

    public void GameOver()
    {
        _audioController.StopMusic();
        _audioController.SuccessFX();
    }
}
