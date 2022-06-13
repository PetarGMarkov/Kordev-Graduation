using UnityEngine;

public class movement : MonoBehaviour
{
	public float speed = 10f;
	public GameObject BulletDown , BulletUp , BulletToRight , BulletToLeft;
	Vector2 BulletPos;
	public float fireRate = 0.5f;
	public float nextFire = 0f;
	
    // Update is called once per frame
    void Update()
    {
		float VerticalMovement = 0f;
		float HorizontalMovement = 0f;
		HorizontalMovement *= Time.deltaTime;
		VerticalMovement *= Time.deltaTime;
			if(Input.GetKey("w")){
			VerticalMovement =speed;
			VerticalMovement *= Time.deltaTime;
			transform.Translate(0,VerticalMovement,0);
			}
			if(Input.GetKey("s")){
			VerticalMovement =-speed;
			VerticalMovement *= Time.deltaTime;
			transform.Translate(0,VerticalMovement,0);
			}
			if(Input.GetKey("d")){
			HorizontalMovement = speed;
			HorizontalMovement *= Time.deltaTime;
			transform.Translate(HorizontalMovement,0,0);
			}
			if(Input.GetKey("a")){
			HorizontalMovement = -speed;
			HorizontalMovement *= Time.deltaTime;
			transform.Translate(HorizontalMovement,0,0);
			}
		if (Input.GetKeyUp("up") || Input.GetKeyUp("down") || Input.GetKeyUp("left") || Input.GetKeyUp("right") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			fire();
		}
	}
	void fire(){
		var MousePosition = Input.mousePosition;
		var PlayerPosition = Camera.main.WorldToScreenPoint(transform.position);
		BulletPos = transform.position;
		if (Input.GetKeyUp("right")){
			BulletPos += new Vector2 (0.1f, 0f);
			Instantiate(BulletToRight, BulletPos, Quaternion.identity);
		}else if(Input.GetKeyUp("left")){
			BulletPos += new Vector2 (-0.1f, 0f);
			Instantiate(BulletToLeft, BulletPos, Quaternion.identity);
		}
		if (Input.GetKeyUp("up")){
			BulletPos += new Vector2 (0.04f, 0.05f);
			Instantiate(BulletUp, BulletPos, Quaternion.identity);
		}else if (Input.GetKeyUp("down")){
			BulletPos += new Vector2 (0.04f, -0.05f);
			Instantiate(BulletDown, BulletPos, Quaternion.identity);
		}
	}
}
