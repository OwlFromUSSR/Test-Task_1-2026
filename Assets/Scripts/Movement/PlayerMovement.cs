using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed = 6f;
    [SerializeField] float iceFriction = 2f;
    [SerializeField] MoveInputSource[] sources;

    private Rigidbody2D rb;
    private MoveInputSource input;
    private Vector2 intent;

    private float boostMultiplier = 1f;
    private float boostTimerLeft;
    public float CurrentSpeed => baseSpeed * (boostTimerLeft > 0 ? boostMultiplier : 1f);


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = sources[(int)ControlSettings.Current];    
    }

    void Update()
    {
        intent = input.ReadIntent();
        if (boostTimerLeft > 0)
            boostTimerLeft -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = intent * CurrentSpeed;

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, Time.fixedDeltaTime * iceFriction);
    }

    public void ApplySpeedBoost(float multipler, float duration)
    {
        boostMultiplier = multipler;
        boostTimerLeft = duration;
    }
}
