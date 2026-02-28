using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
	public static class StatuePlacementUtility
	{
		// TODO
		public static Vector3 CalcGridLocalPosition(float width, float height) { return default; }
		
		// TODO
		public static KeyValuePair<int, int> CalcHighestStatueEffect(SecretBaseMasterDataManager masterData) { return default; }
		
		public static int CalcStatueEffectLevel(int value)
		{
			if (699 < value) {
			  return 2;
			}
			if (299 < value) {
			  return 1;
			}
			return -(uint)(value < 1);
		}
	}
}