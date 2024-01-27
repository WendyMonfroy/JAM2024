using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	[SerializeField] private GameObject _wall;
	[SerializeField] private Transform _particules;
	
	public void DestroyWall()
	{
		_wall.SetActive(false);
		foreach (ParticleSystem p in _particules.GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}

		StartCoroutine(Cleaner());
	}

	private IEnumerator Cleaner()
	{
		yield return new WaitForSeconds(2.5f);
		Destroy(gameObject);
	}
}
