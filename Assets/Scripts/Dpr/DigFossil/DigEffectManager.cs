using Effect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.DigFossil
{
	public class DigEffectManager : MonoBehaviour
	{
		[SerializeField]
		private Camera targetCamera;
		[SerializeField]
		private Transform pos_cursor;
		[SerializeField]
		private Transform pos_collapse;
		[SerializeField]
		private Transform pos_crumbling;
		[SerializeField]
		private Transform pos_crack_start;
		[SerializeField]
		private Transform pos_crack_end;

		private readonly List<EffectFieldID> effectIds = new List<EffectFieldID>()
		{
			EffectFieldID.EF_SU_FUSSIL_HUMMER,
			EffectFieldID.EF_SU_FUSSIL_PIKKERU,
			EffectFieldID.EF_SU_FUSSIL_ROCK_HIT,
			EffectFieldID.EF_SU_FUSSIL_BLACKROCK_HIT,
			EffectFieldID.EF_SU_FUSSIL_GET,
			EffectFieldID.EF_SU_FUSSIL_RARE_GET,
			EffectFieldID.EF_SU_FUSSIL_DAMAGE,
			EffectFieldID.EF_SU_FOSSIL_END2,
			EffectFieldID.EF_SU_FUSSIL_ROCK_HIT_02,
			EffectFieldID.EF_SU_FOSSIL_OPENBOX,
			EffectFieldID.EF_SU_FOSSIL_COMPLETED,
			EffectFieldID.EF_SU_FOSSIL_CRACK_ROCK_01,
		};
		private readonly Dictionary<int, EffectData> effectData = new Dictionary<int, EffectData>();
		private readonly List<EffectInstance> effectInstances = new List<EffectInstance>();

		private List<int> playedCrumblingEffectPosIndices = new List<int>();
		private Dictionary<int, Transform> cursorPosDic = new Dictionary<int, Transform>();

		private static float CrackCosTotal = 37.69911f;
		
		// TODO
		private void Start() { }
		
		// TODO
		public void AddCursor(int index, Transform cursor) { }
		
		// TODO
		public void PlayOneShotToCursor(EffectId id, int cursorNum) { }
		
		public void PlayOneShot(EffectId id, Vector3 pos)
		{
			Play(id,pos,1);
		}
		
		// TODO
		public void PlayToCrumbling(int x, float delay = 0.0f) { }
		
		public EffectInstance PlayToCollapse()
		{
			this.pos_collapse.position;
			Play(7,1);
			return null;
		}
		
		public EffectInstance PlayToAllDigouted()
		{
			this.pos_collapse.position;
			Play(10,1);
			return null;
		}
		
		// TODO
		public EffectInstance PlayToCrack(float t) { return default; }
		
		// TODO
		public EffectInstance Play(EffectId id, Vector3 pos, bool isNearScreen = true) { return default; }
		
		// TODO
		public IEnumerator Load() { return default; }
		
		// TODO
		private IEnumerator PlayWithDelay(EffectId id, Vector3 pos, float delay) { return default; }
		
		// TODO
		private void OnDestroy() { }

		public enum EffectId : int
		{
			KnockWithHummer = 0,
			KnockWithPickaxe = 1,
			BreakBuildupWithPickaxe = 2,
			KnockHardStone = 3,
			DigOutNormal = 4,
			DigOutRare = 5,
			Crumbling = 6,
			Collapse = 7,
			BreakBuildupWithHummer = 8,
			OpenBox = 9,
			Completed = 10,
			Crack = 11,
			Count = 12,
		}
	}
}