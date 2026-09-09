public class SdCardAccess
{
	public bool FileExistsNoMount(string mountName, string filePath) {
	    return false;
	}
	
	public bool FileExists(string mountName, string fileName) {
	    return false;
	}
	
	public bool Mount(string mountName) {
	    return false;
	}
	
	// TODO
	public void Unmount(string mountName) { }
	
	public bool DirectoryExists(string dirPath) {
	    return false;
	}
	
	public bool LoadFile(ref byte[] buffer, string mountName, string path) {
	    return false;
	}
}