using UnityEngine;

public enum SwordType
{
    regular,
    bounce,
    Pierce,
    spin,
}
public class Sword_Skill : Skill
{
    public SwordType SwordType = SwordType.regular;

    [Header("Bounce info")]
    [SerializeField] private int bounceAmount;
    [SerializeField] private float bounceGravity;
    [SerializeField] private float bounceSpeed;

    [Header("skill info")]
    [SerializeField] private GameObject swordprefab;
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float SwordGravity;
    Vector2 finalDir;

    [Header("Aim Dots")]
    [SerializeField] private int numberOfDot;
    [SerializeField] private float spaceBetweenDots;
    [SerializeField] private GameObject DotPrefar;
    [SerializeField] private Transform dotParent;

    [Header("Pierce info")]
    [SerializeField] private int pierceAmount;
    [SerializeField] private float pierceGravity;


    GameObject[] dots;
    protected override void Start()
    {
        base.Start();
        GenerateDots();
        SetUpGravity();
    }
    public void SetUpGravity()
    {

    }
    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
            finalDir = new Vector2(AimDirection().normalized.x * launchForce.x, AimDirection().normalized.y * launchForce.y);
        if (Input.GetKey(KeyCode.Mouse1))
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].transform.position = DotsPosition(i * spaceBetweenDots);
            }
        }
    }

    public void CreateSword()
    {
        GameObject newSword = Instantiate(swordprefab, Player.transform.position, transform.rotation);
        Sword_Skill_Controller newSwordScript = newSword.GetComponent<Sword_Skill_Controller>();
        if(SwordType == SwordType.bounce)
        {
            newSwordScript.SetupBounce(true, bounceAmount, bounceSpeed);
        }
        newSwordScript.SetUpSword(finalDir, SwordGravity, Player);
        Player.assignSword(newSword);
        DotActive(false);
    }
    #region Aim
    public Vector2 AimDirection()
    {
        Vector2 PlayerPosition = Player.transform.position;
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = MousePosition - PlayerPosition;
        return direction;
    }
    public void DotActive(bool active)
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].SetActive(active);
        }
    }
    public void GenerateDots()
    {
        dots = new GameObject[numberOfDot];
        for (int i = 0; i < numberOfDot; i++)
        {
            dots[i] = Instantiate(DotPrefar, Player.transform.position, Quaternion.identity, dotParent);
            dots[i].SetActive(false);
        }
    }
    public Vector2 DotsPosition(float t)
    {
        Vector2 position = (Vector2)Player.transform.position + new Vector2(AimDirection().normalized.x * launchForce.x, AimDirection().normalized.y * launchForce.y) * t + .5f * (Physics2D.gravity * SwordGravity) * (t * t);
        return position;
    }
    #endregion
}
