using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 컴포넌트를 추가를 명시
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
// LivingEntity를 상속
public class Player : LivingEntity {
    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;
	GunController gunController;

    // 스크립트의 인스턴스가 활성화되면 첫번째 프레임의 업데이트 전에 한번 호출.
    protected override void Start() {
        // LivingEntity의 Start()
		base.Start();
        controller = GetComponent<PlayerController> ();
		gunController = GetComponent<GunController> ();
		viewCamera = Camera.main;
    }
    // 프레임마다 한번 씩 호출
    void Update() {
		// Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // normalized = 방향을 가리키는 단위벡터로 만듬
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        // PlayerController.cs 의 Move()함수
        controller.Move(moveVelocity);

		//Look input
        //카메라에서 마우스 커서를 향해 쏜 빛이 바닥에 닿는 점.
		Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayDistance;

		if (groundPlane.Raycast(ray, out rayDistance)) {
			Vector3 point = ray.GetPoint(rayDistance);
			//Debug.DrawLine(ray.origin, point, Color.red);
			controller.LookAt(point);
		}

		//Weapon input
		if (Input.GetMouseButton(0)) {
			gunController.Shoot();
		}
    }
}
