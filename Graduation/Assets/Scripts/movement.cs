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
		
			VerticalMovement = Input.GetAxis("Vertical")*speed;
			VerticalMovement *= Time.deltaTime;
			transform.Translate(0,VerticalMovement,0);
			HorizontalMovement = Input.GetAxis("Horizontal")*speed;
			HorizontalMovement *= Time.deltaTime;
			transform.Translate(HorizontalMovement,0,0);
		
		if (Input.GetMouseButtonDown(0) && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			fire();
		}
	}
	void fire(){
		var MousePosition = Input.mousePosition;
		var PlayerPosition = Camera.main.WorldToScreenPoint(transform.position);
		BulletPos = transform.position;
		if (MousePosition.x > PlayerPosition.x && PlayerPosition.x/(MousePosition.x+1) < PlayerPosition.y/MousePosition.y){
			BulletPos += new Vector2 (0.1f, 0f);
			Instantiate(BulletToRight, BulletPos, Quaternion.identity);
		}else if(MousePosition.x < PlayerPosition.x && PlayerPosition.x/MousePosition.x >PlayerPosition.y/(MousePosition.y+1)){
			BulletPos += new Vector2 (-0.3f, 0f);
			Instantiate(BulletToLeft, BulletPos, Quaternion.identity);
		}
		if (MousePosition.y>PlayerPosition.y&& PlayerPosition.x/MousePosition.x > PlayerPosition.y/(MousePosition.y+1)){
			BulletPos += new Vector2 (0.5f, 0f);
			Instantiate(BulletUp, BulletPos, Quaternion.identity);
		}else if (MousePosition.y<PlayerPosition.y && PlayerPosition.x/(MousePosition.x+1) < PlayerPosition.y/MousePosition.y){
			BulletPos += new Vector2 (-0.5f, 0f);
			Instantiate(BulletDown, BulletPos, Quaternion.identity);
		}
	}
}
