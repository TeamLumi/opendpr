using Dpr.NetworkUtils;
using Pml;
using Pml.PokePara;
using System;

public class TradeSecurityController
{
	private const int POKE_RARITY_VERY_RARE = 3;
	private const int POKE_RARITY_LEGEND_RARE = 2;
	private const int POKE_RARITY_SUB_LEGEND_RARE = 1;
	private const int NETWORK_NOT_ERROR = 1;
	private const int NETWORK_ERROR = 0;
	private const int INVALID_MONS_NO = -1;

	private static readonly MonsNo[] very_rare_monsno = new MonsNo[]
	{
		MonsNo.MYUU,     MonsNo.SEREBHI, MonsNo.ZIRAATI,  MonsNo.DEOKISISU,
        MonsNo.FIONE,    MonsNo.MANAFI,  MonsNo.DAAKURAI, MonsNo.SHEIMI,
		MonsNo.ARUSEUSU,
    };
	private static readonly MonsNo[] legend_rare_monsno = new MonsNo[]
	{
		MonsNo.MYUUTUU,   MonsNo.RUGIA,    MonsNo.HOUOU,    MonsNo.KAIOOGA,
		MonsNo.GURAADON,  MonsNo.REKKUUZA, MonsNo.DHIARUGA, MonsNo.PARUKIA,
		MonsNo.GIRATHINA,
    };
	private static readonly MonsNo[] sub_legend_rare_monsno = new MonsNo[]
    {
		MonsNo.HURIIZAA,   MonsNo.SANDAA,   MonsNo.FAIYAA,    MonsNo.RAIKOU,
		MonsNo.ENTEI,      MonsNo.SUIKUN,   MonsNo.REZIROKKU, MonsNo.REZIAISU,
		MonsNo.REZISUTIRU, MonsNo.RATHIASU, MonsNo.RATHIOSU,  MonsNo.YUKUSII,
		MonsNo.EMURITTO,   MonsNo.AGUNOMU,  MonsNo.HIIDORAN,  MonsNo.REZIGIGASU,
		MonsNo.KURESERIA,
    };

    public TradeParent tradeParent;
	public MonsNo myMonsNo;
	public MonsNo targetMonsNo;
	public PokemonParam targetPokeData;
	public TradeStateModel tradeStateModel;
	private Action initFunc;
	private bool isRecruiment;
	private UnionTradeManager.BoxPokeData boxPokeData;
	private UnionTradeManager.TargetTranerParam targetTranerParam;
	
	// TODO
	public void Init(int stationIndex, UnionTradeManager.BoxPokeData boxPokeData) { }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void Error() { }
	
	public void SetIsRecruiment(bool Recruiment) {
	    this.isRecruiment = Recruiment;
	}
	
	// TODO
	public void SetInitCallBack(Action func, Action<int, bool> startOpenTradeBoxWindow, Action<UnionTradeManager.TradeFlowState> setState) { }
	
	// TODO
	public void SetTargetPokeData(PokemonParam pokeData) { }
	
	// TODO
	public void SetBoxPokeData(UnionTradeManager.BoxPokeData boxPokeData) { }
	
	// TODO
	public void SetTragetTranerParam(UnionTradeManager.TargetTranerParam param) { }
	
	// TODO
	public TradeStateModel.TradeState GetCurrentState() { return default; }
	
	// TODO
	public void ResetTradeState() { }
	
	// TODO
	private void SendState() { }
	
	// TODO
	public void ReciveState(NetDataTradeReadyOkData data) { }
	
	public void SetTradeParent(TradeParent parent) {
	    this.tradeParent = parent;
	}
	
	// TODO
	public bool CheckPokeRarity() { return default; }
	
	// TODO
	private void CreateTradeStateModel(int stationIndex) { }
	
	// TODO
	public void ChangeTradeModelState(TradeStateModel.TradeState state) { }
	
	// TODO
	public TradeStateModel.TradeState GetTradeState() { return default; }
	
	// TODO
	public void SetIsTradeReadyOk(bool isTrade) { }
	
	// TODO
	public void DisconnectVictim_ResetSave() { }

	public enum TradeParent : int
	{
		NONE = 0,
		PARENT = 1,
		CHILD = 2,
	}
}