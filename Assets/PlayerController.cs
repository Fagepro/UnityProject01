using System;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 1;
    [SerializeField] private float _playerJumpForce = 1;
    private Rigidbody rb;
    private bool isOnPlatform = false;
    private float _horizontalDirection;
    private int coinSumm;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private GameObject _coinsParent;
    [SerializeField] private GameObject _playerSpawn;
    private CoinSpawner coinSpawner;
    private bool isDead = false;
    [SerializeField] private GameObject[] _coins;

    [SerializeField] private int _playerHealth = 100;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coinSpawner = new CoinSpawner();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnPlatform)
        {
            Jump();
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            _horizontalDirection = Input.GetAxis("Horizontal");
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(_horizontalDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            isOnPlatform = true;
        }

    }

    private void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.transform.CompareTag("Coin"))
        {
            CollectCoin(collidedObject.gameObject);
        }
        
        if (collidedObject.transform.CompareTag("DeathCollider"))
        {
            isDead = !isDead;
            SpawnCoins();
            ClearCoinSumm();
            RespawnPlayer();
        }

        if (collidedObject.transform.CompareTag("Enemy"))
        {
            Enemy enemy = collidedObject.GetComponent<Enemy>();
            int enemyDamage = enemy.GetDamage();
            TakeEnemyDamage(enemyDamage);
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0, 1 * _playerJumpForce, 0), ForceMode.Impulse);
        isOnPlatform = false;
    }

    private void MovePlayer(float direction)
    {
        rb.MovePosition(transform.position + new Vector3(direction * _playerSpeed, 0, 0));
    }

    private void CollectCoin(GameObject other)
    {
        HideCoin(other);
        SummCoin(other);
    }

    private void HideCoin(GameObject other)
    {
        other.gameObject.SetActive(false);
    }

    private void SummCoin(GameObject other)
    {
        coinSumm++;
        _coinText.text = Convert.ToString(coinSumm);
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _coins.Length; i++)
        {
            _coins[i].gameObject.SetActive(true);
            coinSpawner.Inject(isDead, _coins[i].GetComponent<Transform>().position , _coins[i]);
        }
    }

    private void ClearCoinSumm()
    {
        coinSumm = 0;
        _coinText.text = Convert.ToString(coinSumm);
    }

    private void RespawnPlayer()
    {
        this.transform.position = _playerSpawn.transform.position;
    }

    public void TakeEnemyDamage(int damage)
    {
        
        if (_playerHealth > 0)
        {
            _playerHealth = _playerHealth - damage;
            if (_playerHealth < 0)
            {
                Death();
                Debug.Log("U DIE");
            }
            else
            {
                Debug.Log($"Damage: - {damage} Player Health: {_playerHealth}");
            }
        }
        else
        {
            Death();
            Debug.Log("U DIE");
        }
    }

    private void Death()
    {
        if (_playerHealth < 0)
        {
            RespawnPlayer();
            SpawnCoins();
            ClearCoinSumm();
            _playerHealth = 100;
        }
    }
}
