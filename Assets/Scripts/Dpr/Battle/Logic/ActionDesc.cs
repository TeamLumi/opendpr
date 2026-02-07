namespace Dpr.Battle.Logic
{
    public sealed class ActionDesc
    {
        public uint serialNo;
        public bool isOiutiInterruptAction;
        public bool isYokodoriRobAction;
        public bool isMagicCoatReaction;
        public bool isOdorikoReaction;
        public bool isSaihaiReaction;
        public InsertActionInfo insertInfo = new InsertActionInfo();

        public void CopyFrom(ActionDesc src)
        {
            serialNo = src.serialNo;
            isOiutiInterruptAction = src.isOiutiInterruptAction;
            isYokodoriRobAction = src.isYokodoriRobAction;
            isMagicCoatReaction = src.isMagicCoatReaction;
            isOdorikoReaction = src.isOdorikoReaction;
            isSaihaiReaction = src.isSaihaiReaction;
            insertInfo.CopyFrom(src.insertInfo);
        }

        public void Clear()
        {
            serialNo = 0;
            isOiutiInterruptAction = false;
            isYokodoriRobAction = false;
            isMagicCoatReaction = false;
            isOdorikoReaction = false;
            isSaihaiReaction = false;
            insertInfo.Clear();
        }

        public static void Clear(ActionDesc desc)
        {
            desc.Clear();
        }
    }
}