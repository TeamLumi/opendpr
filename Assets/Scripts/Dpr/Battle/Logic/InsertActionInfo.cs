namespace Dpr.Battle.Logic
{
    public sealed class InsertActionInfo
    {
        public bool isTokuseiWindowDisplay;
        public StrParam prevActionMessage = new StrParam();

        public void CopyFrom(InsertActionInfo src)
        {
            isTokuseiWindowDisplay = src.isTokuseiWindowDisplay;
            prevActionMessage.CopyFrom(src.prevActionMessage);
        }

        public void Clear()
        {
            isTokuseiWindowDisplay = false;
            prevActionMessage.Clear();
        }
    }
}