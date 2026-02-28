namespace Dpr.Battle.Logic
{
    public sealed class InsertActionInfo
    {
        public bool isTokuseiWindowDisplay;
        public StrParam prevActionMessage = new StrParam();

        // TODO
        public void CopyFrom(InsertActionInfo src) { }

        public void Clear()
        {
        	this.isTokuseiWindowDisplay = false;
        	this.prevActionMessage.Clear();
        }
    }
}