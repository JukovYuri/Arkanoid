using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

	private void OnCollisionEnter2D(Collision2D collision)
	{
		print("enter!");
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		print("exit!");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		print("trigger enter!");
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		print("trigger exit!");
	}

}
