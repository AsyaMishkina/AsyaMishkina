using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SceneClass : MonoBehaviour {
	Collider2D _hitCollider2D;
	Rigidbody2D _targetRigidBody;
	Vector3 _offsetDragVec3;
	Vector3 _cursorMemoryVec3;

void Update(){
	if (Input.GetMouseButtonDown (0)) {
			_hitCollider2D=Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			if(_hitCollider2D){
				_offsetDragVec3=_hitCollider2D.transform.position-Camera.main.ScreenToWorldPoint(Input.mousePosition);
				_targetRigidBody=_hitCollider2D.transform.gameObject.GetComponent<Rigidbody2D>();
			}
	}
	if (Input.GetMouseButtonUp (0)) {
		_hitCollider2D = null;
			_targetRigidBody.AddForce((Input.mousePosition-_cursorMemoryVec3)*0.1f,ForceMode2D.Impulse);
	}
	if(_hitCollider2D){
			_targetRigidBody.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition)+_offsetDragVec3);
			//_hitCollider2D.transform.position=Camera.main.ScreenToWorldPoint(Input.mousePosition)+_offsetDragVec3;
			_cursorMemoryVec3=Input.mousePosition;
	}
sds
}
}
