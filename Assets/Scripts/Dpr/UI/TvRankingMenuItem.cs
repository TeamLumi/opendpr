using DPData;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.UI
{
	public class TvRankingMenuItem : MonoBehaviour
	{
		[SerializeField]
		private UIText _title;
		[SerializeField]
		private RectTransform _select;

		private UIDatabase.SheetRankingDisplay _rankingData;
		private List<RankParam> _rankParams;
		
		public UIDatabase.SheetRankingDisplay rankingData { get => _rankingData; }
		public List<RankParam> rankParams { get => _rankParams; }
		
		// TODO
		public void Setup(UIDatabase.SheetRankingDisplay rankingData, List<RankParam> rankParams) { }
		
		// TODO
		public int DeleteRankParam(int flagIndex, int rankParamIndex) { return default; }
		
		public void Select(bool enabled)
		{
			GameObject.SetActive(this._select.gameObject,(enabled ? 1 : 0) & 1,0);
		}

		public class RankParam
		{
			public RANDOMGROUP groupId = (RANDOMGROUP)(-1);
			public int rank = -1;
			public uint value;
			public long timeStamp;
			
			public bool isMine { get => groupId == 0; }
		}
	}
}