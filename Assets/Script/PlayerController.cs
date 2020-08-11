using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    Vector3 velocity;
    Rigidbody myRigidbody;

    void Start() {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity) {
        velocity = _velocity;
    }

    public void LookAt(Vector3 lookPoint) {
        // tramsform 은 게임 오브젝트가 가지는 기본 컴포넌트. 위치 회전 크기 정보 가짐.
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
    // 프레임 기반이 아닌 고정된 시간을 기준으로 호출
    void FixedUpdate() {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
