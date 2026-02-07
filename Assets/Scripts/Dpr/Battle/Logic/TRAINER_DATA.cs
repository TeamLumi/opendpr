using Dpr.Trainer;
using Pml;
using XLSXContent;

namespace Dpr.Battle.Logic
{
	public class TRAINER_DATA
	{
		public MyStatus playerStatus;
		public TrainerTable.SheetTrainerData trainerData;
		public TowerTrainerTable.SheetTrainerData instTrainerData;
		public string name;
		public string name_label;
		public string trtype_name_label;
		public TrainerID trainerID;
		public TrainerType trainerType;
		public TrainerTypeGroup trainerGroup;
		public Sex trainerSex;
		public byte trainerGold;
		public uint ai_bit;
		public ushort[] useItem = new ushort[BSP_TRAINER_DATA.USE_ITEM_MAX];
		public string modelID;
		public int colorID;
		
		public void Clear()
		{
			playerStatus = null;
			trainerData = null;
			instTrainerData = null;
			name = null;
			name_label = null;
			trtype_name_label = null;
			trainerID = 0;
			trainerType = 0;
			trainerGroup = 0;
			trainerSex = 0;
			trainerGold = 0;
			ai_bit = 0;
			for (int i = 0; i < useItem.Length; i++)
			{
				useItem[i] = 0;
			}
			modelID = null;
			colorID = 0;
		}
	}
}