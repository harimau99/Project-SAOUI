﻿using UnityEngine;
using System;
using System.Collections;

public class CollisionController : MonoBehaviour {
	
	private bool allowTouch = false;
	private bool isHover;
	
	private BoxCollider boxCollider;
	private CapsuleCollider capsuleCollider;

	private Vector3 colliderPosition;
	private Vector3 colliderScale;


	private float colliderRadius;
	private float colliderHeight;
	private int colliderDirection;

	private bool colliderIsTrigger;
	private Vector3 colliderCenter;

	private Vector3 colliderSize;

	void Start () {
		StartCoroutine(wait(2));
	}

	public void initCapsuleCollider() {
		capsuleCollider = GetComponent<CapsuleCollider>();
	}

	public void initBoxCollider() {
		boxCollider = GetComponent<BoxCollider>();
	}
	
	#region Setters and Getters    
	public Vector3 ColliderPosition {
		get { return colliderPosition; }
		set { 
			colliderPosition = value; 
			transform.localPosition = value;
		}
	}
	
	public Vector3 ColliderScale {
		get { return colliderScale; }
		set {
			colliderScale = value;
			transform.localScale = value;
		}
	}

	public bool IsHover {
		get { return isHover; }
		set { isHover = value; }
	}

	public Vector3 ColliderSize {
		get { return colliderSize; }
		set {
			colliderSize = value;
			if(boxCollider != null)
				boxCollider.size = value;
		}
	}

	public bool ColliderIsTrigger {
		get { return colliderIsTrigger; }
		set {
			colliderIsTrigger = value;
			if(boxCollider != null)
				boxCollider.isTrigger = value;
			else if(capsuleCollider != null)
				capsuleCollider.isTrigger = value;
		}
	}

	public Vector3 ColliderCenter {
		get { return colliderCenter; }
		set {
			colliderCenter = value;
			if(boxCollider != null)
				boxCollider.center = value;
			else if(capsuleCollider != null)
				capsuleCollider.center = value;
		}
	}

	public float ColliderRadius {
		get { return colliderRadius; }
		set {
			colliderRadius = value;
			if(capsuleCollider != null)
				capsuleCollider.radius = value;
		}
	}
	
	public int ColliderDirection {
		get { return colliderDirection; }
		set {
			colliderDirection = value;
			if(capsuleCollider != null)
				capsuleCollider.direction = value;
		}
	}

	public float ColliderHeight {
		get { return colliderHeight; }
		set {
			colliderHeight = value;
			if(capsuleCollider != null)
				capsuleCollider.height = value;
		}
	}
	
	#endregion

	void OnTriggerEnter(Collider other) {
		if (other.name == "bone3" && allowTouch)
			if(isHover)
				Debug.Log("Hover");
			else 
				Debug.Log("Press");
		
	}
	
	void OnTriggerExit(Collider other) {
		if (other.name == "bone3" && allowTouch)
			if(isHover)
				Debug.Log("Hover Loss");
			else 
				Debug.Log("Press Loss");
	}
	
	public IEnumerator wait(int seconds) {
		yield return new WaitForSeconds (seconds);
		allowTouch = true;
	}
}
