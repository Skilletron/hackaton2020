using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public enum ProjectAxis { onlyX = 0, xAndY = 1 };
	public ProjectAxis projectAxis = ProjectAxis.onlyX;
	public float speed = 150;
	public float addForce = 7;
	public bool isFacingRight = true;
	public AudioClip clip_pistol,clip_revolver,clip_ak;
	private Vector3 direction;
	private bool visibility = false;
	private float vertical;
	private float horizontal;
	private Rigidbody2D body;
	  public Transform addParent;
	  public GameObject Audio;
	public GameObject firePoint;
	public GameObject bullet;
	public int health;
	public SaveAllGame Money;
	public GameObject Player;
    public GameObject Bot;
	private float timeBtwShots;
	public float startTimeBtwShots;
	public int isDead = 0;
	private Animator animator;
	public int balance = 1;
	void Start()
	{
		
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		Player = GameObject.Find("Terrain/Player");
		Audio = GameObject.Find("ScriptHolder");
		addParent = GameObject.Find("Terrain/Bullets").transform;
		if (projectAxis == ProjectAxis.xAndY)
		{
			body.gravityScale = 0;
			body.drag = 10;
		}
	}

void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.transform.tag == "DeathZone")
		{
			Destroy(gameObject);
		}
	}

	
	public void TakeDamage(int damage) {
		health -= damage;
	}

	 void Shoot() {
		if (isDead != 1)
		{
			Audio.GetComponent<AudioSource>().PlayOneShot(clip_ak);
			GameObject kek = Instantiate(bullet, firePoint.transform.position, transform.rotation);
			kek.transform.SetParent(addParent, true);
		}
       
        
    }
	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed);

		if (Mathf.Abs(body.velocity.x) > speed / 100f)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
		}

		if (projectAxis == ProjectAxis.xAndY)
		{
			if (Mathf.Abs(body.velocity.y) > speed / 100f)
			{
				body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
			}
		}
	}

	void Flip()
	{
		if (projectAxis == ProjectAxis.onlyX)
		{
			isFacingRight = !isFacingRight;
			transform.Rotate(0,180f,0);
		}
	}

	void Update()
	{
		if (visibility)
		{
			if (((Player.transform.position.x - Bot.transform.position.x) < 2f) && ((Player.transform.position.x - Bot.transform.position.x) > 0.4f) && (((Player.transform.position.y - Bot.transform.position.y) < 3f) && ((Bot.transform.position.y - Player.transform.position.y) < 3f && isDead !=1)))
			{
				horizontal = 1;

			}
			else if (((Bot.transform.position.x - Player.transform.position.x) < 2f) && ((Bot.transform.position.x - Player.transform.position.x) > 0.4f) && (((Player.transform.position.y - Bot.transform.position.y) < 3f) && ((Bot.transform.position.y - Player.transform.position.y) < 3f && isDead != 1)))
			{
				horizontal = -1;

			}
			else 
			{
				 
				horizontal = 0;
				
			}
		}

		else {
		
		 if (((Player.transform.position.x - Bot.transform.position.x) < 2f) && ((Player.transform.position.x - Bot.transform.position.x) > 0.4f) && (((Player.transform.position.y - Bot.transform.position.y) < 0.5f) && ((Bot.transform.position.y - Player.transform.position.y) < 0.5f && isDead != 1)))
		{
			horizontal = 1;
			visibility = true;
		}
		else if (((Bot.transform.position.x - Player.transform.position.x) < 2f) && ((Bot.transform.position.x - Player.transform.position.x) > 0.4f) && (((Player.transform.position.y - Bot.transform.position.y) < 0.5f) && ((Bot.transform.position.y - Player.transform.position.y) < 0.5f && isDead != 1)))
		{
			horizontal = -1;
			visibility = true;
		}
		else 
		{
			horizontal = 0;

		}
		}
		if ((Player.transform.position.y > Bot.transform.position.y) && isDead != 1)
		{
			vertical = 1;
		}
		else 
		{
			vertical = 0;
		}
		if (health <= 0) {
			transform.rotation = Quaternion.Euler(0, 0, 90);
			if(balance == 1)
            {
				Money.Money += Random.Range(50, 150);
				balance = 0;
			}
			
			isDead = 1;
			horizontal = 0;
			vertical = 0;
			gameObject.tag = "Untagged";
			animator.SetBool("IsRun",false);
		}
		

		if(horizontal != 0 || vertical != 0) {
			animator.SetBool("IsRun",true);
		}else {
			animator.SetBool("IsRun",false);
		}
		if (((Bot.transform.position.y - Player.transform.position.y) < 0.3f) && ((Player.transform.position.y - Bot.transform.position.y) < 0.3f) && (Player.transform.position.x > Bot.transform.position.x) && ((Player.transform.position.x - Bot.transform.position.x) < 2.4f &&isDead !=1))
		{
			if( timeBtwShots <= 0){
		
            Shoot();
			timeBtwShots = startTimeBtwShots;
        
	} 
	else {
		timeBtwShots -= Time.deltaTime;
	}
		}
		else if (((Bot.transform.position.y - Player.transform.position.y) < 0.3f) && ((Player.transform.position.y - Bot.transform.position.y) < 0.3f) && (Player.transform.position.x < Bot.transform.position.x) && ((Bot.transform.position.x - Player.transform.position.x) < 2.4f && isDead != 1))
		{
			if( timeBtwShots <= 0){
		
            Shoot();
			timeBtwShots = startTimeBtwShots;
        
	} 
	else {
		timeBtwShots -= Time.deltaTime;
	}
		}

		if (projectAxis == ProjectAxis.onlyX)
		{
			direction = new Vector2(horizontal, 0);
		}
		if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
	}
	
	
}