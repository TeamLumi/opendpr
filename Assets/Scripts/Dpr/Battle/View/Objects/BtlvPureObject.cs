using Dpr.SequenceEditor;
using System;
using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public class BtlvPureObject : ITranslationObject, IDisposable
	{
		private Vector3 _translation = Vector3.zero;
        private Vector3 _translationOffset = Vector3.zero;
        private Vector3 _scale = Vector3.one;
        private Vector3 _scaleOffset = Vector3.one;
        private Vector3 _rotVec = Vector3.zero;
        private Vector3 _rotVecOffset = Vector3.zero;
        protected bool _isSuspendUpdate;
		protected string _name;
		protected PokeFollowInfo _pokeFollowInfo;
		protected BtlvObjectFollowInfo _objectFollowInfo;
		
		public BtlvPureObject()
		{
			BattleJobSystem.Add(this);
		}
		
		public virtual void Dispose()
		{
			BattleJobSystem.Remove(this);
			_pokeFollowInfo = null;
			_objectFollowInfo = null;
		}
		
		// TODO
		public void SetTranslationVec(Vector3 translation) { }
		
		public Vector3 GetTranslationVec()
		{
			return this._translation;
		}
		
		// TODO
		public void SetTranslationOffset(Vector3 translation) { }
		
		public Vector3 GetTranslationOffset()
		{
			return this._translationOffset;
		}
		
		// TODO
		public void SetScaleVec(Vector3 scale) { }
		
		public Vector3 GetScaleVec()
		{
			return this._scale;
		}
		
		// TODO
		public void SetScaleOffset(Vector3 scale) { }
		
		public Vector3 GetScaleOffset()
		{
			return this._scaleOffset;
		}
		
		// TODO
		public void SetRotationVec(Vector3 rot) { }
		
		public Vector3 GetRotationVec()
		{
			return this._rotVec;
		}
		
		// TODO
		public void SetRotationVecOffset(Vector3 rot) { }
		
		public Vector3 GetRotationVecOffset()
		{
			return this._rotVecOffset;
		}
		
		public virtual bool IsActive()
		{
			return false;
		}
		
		// TODO
		public virtual void OnUpdatePreJob(float deltaTime) { }
		
		// TODO
		public virtual void OnUpdatePostJob(float deltaTime) { }
		
		// TODO
		protected virtual void UpdateSRT() { }
		
		// TODO
		public Vector3 GetCalcTranslation() { return default; }
		
		// TODO
		public Vector3 GetCalcRot() { return default; }
		
		// TODO
		public Vector3 GetCalcScale() { return default; }
		
		// TODO
		public void AttachPoke(BOPokemon pokemon, SEQ_DEF_NODE node, bool isFollowRot, bool isFollowScl, bool isFollowAnimRot) { }
		
		public void DetachPoke()
		{
			this._pokeFollowInfo = null;
		}
		
		// TODO
		public void AttachModel(ITranslationObject iPtrObject, Transform joint, bool isFollowPos, bool isFollowRot, bool isFollowScl, bool followAnimScl, bool followLocalScl) { }
		
		public void DetachModel()
		{
			this._objectFollowInfo = null;
		}
	}
}