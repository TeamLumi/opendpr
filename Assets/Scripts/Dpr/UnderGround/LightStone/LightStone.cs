using Effect;
using Pml;
using UnityEngine;

namespace Dpr.UnderGround.LightStone
{
	public class LightStone : MonoBehaviour
	{
		[SerializeField]
		private Transform root;
		[SerializeField]
		private Transform monsterRoot;
		[SerializeField]
		private Transform effectRoot;

		private State state;
		private State nextState;
		private MonsNo monsNo;
		private FieldPokemonEntity entity;
		private EffectInstance lightStoneEffect;
		
		public Vector2Int Pos { get; private set; }
		
		// TODO
		public void Init(Vector2Int pos) { }
		
		// TODO
		public void LoadModel(MonsNo monsNo) { }
		
		public void ReturnUnUsed()
		{
			if ((int)this.state != 0) {
			  this.state = (State)0;
			  if (((int)this.state == 3) && (this.lightStoneEffect != null)) {
			    0.Stop(this.lightStoneEffect,0);
			  }
			  ExtensionMethods.SetActive(this.root,0);
			  ExtensionMethods.SetActive(this.monsterRoot,0);
			}
		}
		
		// TODO
		public void ReturnUnUsedWithAnimation() { }
		
		// TODO
		public bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		public bool IsContact() { return default; }
		
		public bool IsUnuse()
		{
			return (int)this.state == 0;
		}
		
		public void OnHit()
		{
			if ((int)this.state != 3) {
			  if ((int)this.state == 1) {
			    var uVar2 = GameObject.get_activeInHierarchy(this.monsterRoot.gameObject,0);
			    if (uVar2) {
			      PlayPokeSE();
			      PLayDigAnimation();
			      this.nextState = (State)3;
			    }
			  }
			}
			FindLightStone();
		}
		
		public void DigStart()
		{
			if ((int)this.state == 1) {
			  var uVar2 = GameObject.get_activeInHierarchy(this.monsterRoot.gameObject,0);
			  if (uVar2) {
			    PlayPokeSE();
			    PLayDigAnimation();
			    this.nextState = (State)3;
			  }
			}
		}
		
		// TODO
		private void PLayDigAnimation() { }
		
		// TODO
		public void FindLightStone() { }
		
		public bool IsAliveModel()
		{
			if ((int)this.state == 1) {
			  this.monsterRoot.gameObject = GameObject.get_activeInHierarchy(Component.get_gameObject(this.monsterRoot),0);
			  return this.monsterRoot.gameObject;
			}
			return false;
		}
		
		// TODO
		private void PlaySmokeEffect(float delay) { }
		
		// TODO
		public void PlayLightStoneEffect(float delay) { }
		
		// TODO
		private void PlayPokeSE() { }
		
		private void SetState(State state)
		{
			if (this.state != state) {
			  this.state = (State)(state);
			  switch(state) {
			  case 0:
			    if (((int)this.state == 3) && (this.lightStoneEffect != null)) {
			      0.Stop(this.lightStoneEffect,0);
			    }
			    ExtensionMethods.SetActive(this.root,0);
			    ExtensionMethods.SetActive(this.monsterRoot,0);
			    break;
			  case 1:
			    ExtensionMethods.SetActive(this.monsterRoot,1);
			    break;
			  case 3:
			    GameObject.SetActive(this.monsterRoot.gameObject,0,0);
			    PlayLightStoneEffect(0x3dcccccd,this);
			    break;
			  case 4:
			    if (this.lightStoneEffect != null) {
			      0.Stop(this.lightStoneEffect,0);
			      break;
			    }
			  }
			}
		}

		private enum State : int
		{
			Uninitialized = 0,
			Idle = 1,
			DigAnimation = 2,
			LightStone = 3,
			Empty = 4,
		}
	}
}