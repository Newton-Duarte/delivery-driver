using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float regularSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float currentSpeed = 20f;
    [SerializeField] GameObject pointer;

    Package package;
    Transform customerPosition;

    GameController _gameController;
    AudioController _audioController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindAnyObjectByType<GameController>();
        _audioController = FindAnyObjectByType<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if (pointer.activeSelf)
        {
            pointer.transform.right = customerPosition.position - pointer.transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _audioController.ImpactFX();
        currentSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !package)
        {
            package = collision.gameObject.GetComponent<Package>();
            package.customer.gameObject.SetActive(true);
            customerPosition = package.customer.transform;
            Debug.Log($"The customer position is: {customerPosition.localPosition}");
            _audioController.CollectFX();
            pointer.SetActive(true);
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Customer" && package != null)
        {
            var customer = collision.gameObject.GetComponent<Customer>();
            if (package.customer.id == customer.id)
            {
                pointer.SetActive(false);
                _gameController.DeliverPackage(package);
                if (customer.package != null)
                {
                    customer.package.SetActive(true);
                    package = null;
                    Destroy(customer.gameObject);
                }
                else
                {
                    _gameController.GameOver();
                }
            }
        }

        if (collision.tag == "Boost")
        {
            _audioController.BoostFX();
            currentSpeed = boostSpeed;
        }
    }
}
