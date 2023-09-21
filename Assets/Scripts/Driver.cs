using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] Color32 isDeliveringColor = Color.white;

    SpriteRenderer spriteRenderer;
    Package package;

    GameController _gameController;
    AudioController _audioController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindAnyObjectByType<GameController>();
        _audioController = FindAnyObjectByType<AudioController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _audioController.ImpactFX();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !package)
        {
            package = collision.gameObject.GetComponent<Package>();
            package.customer.gameObject.SetActive(true);
            spriteRenderer.color = isDeliveringColor;
            _audioController.CollectFX();
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Customer" && package != null)
        {
            var customer = collision.gameObject.GetComponent<Customer>();
            if (package.customer.id == customer.id)
            {
                _gameController.DeliverPackage(package);
                spriteRenderer.color = Color.white;
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
    }
}
