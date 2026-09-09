using Dpr.NetworkUtils;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

public abstract class OpcManager
{
	protected const int INVALID_CHARAID = -1;
	protected const string ASSET_PASS_FIELD = "persons/field/";

	[SerializeField]
	protected List<OpcController> _OpcControllers;
	[SerializeField]
	protected List<OpcController> _CopyOpcControllers;

    public UnionCharacterTable.SheetSheet1[] _DataTable { set; get; }
    public UnionNpcColorTable.SheetSheet1[] _ColorDataTable { get; set; }
    public int characterCreateCount { get; set; }

    public Action<byte> _RequestNetDataCallback;

	[Space(30.0f)]
	[Header("DEBUG_PARAMATER")]
	[Space(30.0f)]
	[SerializeField]
	private int _CreateMaxCharacterCount = 16;
	
	// TODO
	public void Init() { }
	
	// TODO
	public virtual void Destroy() { }
	
	// TODO
	public void SetDataTable(UnionCharacterTable.SheetSheet1[] table) { }
	
	// TODO
	public void SetNpcColorDataTable(UnionNpcColorTable.SheetSheet1[] table) { }
	
	// TODO
	public bool IsOverCreateCount() { return default; }
	
	// TODO
	public void SetRequestNetDataCallBack(Action<byte> RequestNetData) { }
	
	// TODO
	public virtual void SetNetData(INetData netData) { }
	
	// TODO
	protected CharaData CreateCharaData(ANetData<JoinData> netJoinData) { return default; }
	
	// TODO
	public virtual void AddOpc(OpcController opc) { }
	
	// TODO
	public virtual void RemoveOpc(OpcController opc) { }
	
	// TODO
	private void CleanOpcs() { }
	
	// TODO
	public OpcController GetOpc(int id) { return default; }
	
	// TODO
	public int GetSexId(int id) { return default; }
	
	// TODO
	public CharaData GetCharaData(int id) { return default; }
	
	// TODO
	private int GetNpcColorId(int avaterId) { return default; }
	
	// TODO
	protected IEnumerator OpLoadCharacter(string path, RequestEventCallback callback) { return default; }

	// TODO
	public abstract void CreateCharacter(INetData data);
	
	// TODO
	public virtual void RemoveCharacter(int stationIndex, bool isGameObjectDestroy = true) { }
	
	// TODO
	public virtual void DestroyCharacterObject(GameObject gameObj) { }
	
	// TODO
	public virtual void RemoveAllCharacter() { }
	
	// TODO
	public void ChangeOpcState(OpcState.OnlineState state) { }
	
	// TODO
	public void CreateEmoticon(NetEmotionData data) { }
	
	public List<OpcController> GetOpcControllerList() {
	    return _OpcControllers;
	}
	
	// TODO
	public void TargetOpcTalk(int targetIndex) { }
	
	// TODO
	private int GetOpcSexId(int avaterId) { return default; }
	
	// TODO
	protected OpcManager() { }

	[Serializable]
	public struct CharaData
	{
		public int stationIndex;
		public string assetName;
		public int colorId;
		public int avatarId;
		public int sexId;
		public int cassetVersion;
	}
}