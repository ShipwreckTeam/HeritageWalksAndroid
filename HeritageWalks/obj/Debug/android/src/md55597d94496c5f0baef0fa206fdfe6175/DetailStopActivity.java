package md55597d94496c5f0baef0fa206fdfe6175;


public class DetailStopActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("HeritageWalks.Activities.DetailStopActivity, HeritageWalks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DetailStopActivity.class, __md_methods);
	}


	public DetailStopActivity ()
	{
		super ();
		if (getClass () == DetailStopActivity.class)
			mono.android.TypeManager.Activate ("HeritageWalks.Activities.DetailStopActivity, HeritageWalks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
