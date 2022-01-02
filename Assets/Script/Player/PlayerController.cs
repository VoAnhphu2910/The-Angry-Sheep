using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float starHealth = 100;
    public float health;

    public Image healthBar;

    public GameController gameController;

    public bool isDefensed = false;

    [SerializeField]
    public static float speed = 4;

    public float timeDefensed = 5;

    public Text textHealth;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        health = starHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Hiển thị máu của Player
        healthBar.fillAmount = health / starHealth;
        // Hiển thị số máu
        textHealth.text = health.ToString();

        // Không cho máu vượt quá máu tối đa
        if (health > starHealth)
        {
            health = starHealth;
        }

        // Nếu nhặt được khiên sẽ được bất tử trong khoảng thời gian
        if(isDefensed)
        {
            timeDefensed -= Time.deltaTime;
            if (timeDefensed <= 0)
            {
                isDefensed = false;
            }
        }
        else
        {
            timeDefensed = 5;
        }

    }

    public void TakeDame( int dame)
    {
        // Có khiên thì thoát khỏi hàm
        if(isDefensed)
        {
            return;
        }

        // Nhận sát thưng thì phát âm thanh và trừ máu 
        audioSource.Play();
        health -= dame;
        
        // Nêu máu nhỏ hơn hoặc bằng 0 thì EndGame
        if (health <= 0)
        {
            gameController.EndGame();
        }
    }
}
