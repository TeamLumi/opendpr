using Dpr.NetworkUtils;

public class UnionOpcController : OpcController
{
	private bool isTransitionAfter;
	private bool isMultiMatchWait;
	
	// TODO
	public void Awake() { }
	
	// TODO
	protected override void MyUpdate(float deltaTime) { }
	
	// TODO
	public override void SetNetData(INetData netData) { }
	
	public void SetIsTransitionAfter(bool isTransition) {
	    this.isTransitionAfter = isTransition;
	}
	
	public bool GetTransitionAfter() {
	    return isTransitionAfter;
	}
	
	public void SetIsMultiMatchWait(bool flag) {
	    this.isMultiMatchWait = flag;
	}
	
	public bool GetIsMultiMatchWait() {
	    return isMultiMatchWait;
	}
}