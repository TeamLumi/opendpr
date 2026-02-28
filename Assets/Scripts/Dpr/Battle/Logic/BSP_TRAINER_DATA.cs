using Dpr.Trainer;
using Pml;
using XLSXContent;

namespace Dpr.Battle.Logic
{
    public class BSP_TRAINER_DATA
    {
        public const int USE_ITEM_MAX = 4;
        private CORE_DATA mCore = new CORE_DATA();

        public TrainerID GetTrainerID()
        {
        	return this.mCore.tr_id;
        }

        public uint GetAIBit()
        {
        	return this.mCore.ai_bit;
        }

        public BattleSetupEffectId GetBattleEffectID()
        {
        	return this.mCore.btl_eff_id;
        }

        public TrainerType GetTrainerType()
        {
        	return this.mCore.tr_type;
        }

        public TrainerTypeGroup GetTrainerGroup()
        {
        	return this.mCore.tr_group;
        }

        public Sex GetTrainerSex()
        {
        	return this.mCore.tr_sex;
        }

        public byte GetGoldParam()
        {
        	return (byte)(this.mCore.gold);
        }

        public string GetModelID()
        {
        	return this.mCore.model_id;
        }

        public int GetColorID()
        {
        	return this.mCore.color_id;
        }

        // TODO
        public ushort GetUseItem(int index) { return 0; }

        public string GetNameLabel()
        {
        	return this.mCore.name_label;
        }

        public string GetTrTypeNameLabel()
        {
        	return this.mCore.trtype_name_label;
        }

        public void SetTrainerID(TrainerID id)
        {
        	this.mCore.tr_id = id;
        }

        public void SetAIBit(uint bit)
        {
        	this.mCore.ai_bit = bit;
        }

        public void SetGoldParam(byte gold)
        {
        	this.mCore.gold = gold;
        }

        public void SetModelID(string modelID)
        {
        	this.mCore.model_id = modelID;
        }

        public void SetColorID(int color_id)
        {
        	this.mCore.color_id = color_id;
        }

        // TODO
        public void Dispose() { }

        // TODO
        public void LoadTrTypeData(TrainerType trainerType) { }

        // TODO
        public void SetupTrainerData(TrainerTable.SheetTrainerData trainerData) { }

        // TODO
        public void SetupTrainerData(TowerTrainerTable.SheetTrainerData trainerData) { }

        // TODO
        public void ReloadTrTypeData() { }

        public TrainerTable.SheetTrainerType GetTrTypeData()
        {
        	return this.mCore.tr_type_data;
        }

        public TrainerTable.SheetTrainerData GetTrainerData()
        {
        	return this.mCore.trainer_data;
        }

        public TowerTrainerTable.SheetTrainerData GetInstTrainerData()
        {
        	return this.mCore.inst_trainer_data;
        }

        // TODO
        public void SetUseItem(ushort[] items) { }

        public void SetNameLabel(string name_label)
        {
        	this.mCore.name_label = name_label;
        }

        public void SetTrTypeNameLabel(string trtype_name_label)
        {
        	this.mCore.trtype_name_label = trtype_name_label;
        }

        private class CORE_DATA
        {
            public TrainerID tr_id;
            public TrainerType tr_type;
            public TrainerTable.SheetTrainerType tr_type_data;
            public TrainerTable.SheetTrainerData trainer_data;
            public TowerTrainerTable.SheetTrainerData inst_trainer_data;
            public BattleSetupEffectId btl_eff_id;
            public TrainerTypeGroup tr_group;
            public Sex tr_sex;
            public string model_id;
            public int color_id;
            public uint ai_bit;
            public byte gold;
            public ushort[] use_item = new ushort[USE_ITEM_MAX];
            public string trtype_name_label;
            public string name_label;
        }
    }
}