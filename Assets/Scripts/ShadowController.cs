using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShadowController : MonoBehaviour {
	[SerializeField]
	private Image _shadowRenderer;
	
	[SerializeField]
	private Color _bgColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_shadowRenderer.material.SetVector("_Position1", transform.position);
		//_shadowRenderer.material.SetVector("_Position2", vPos2);
		
		_shadowRenderer.material.SetColor("_Color", _bgColor);
	}
}
