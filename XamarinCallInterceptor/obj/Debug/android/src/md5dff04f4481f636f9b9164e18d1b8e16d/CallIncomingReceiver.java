package md5dff04f4481f636f9b9164e18d1b8e16d;


public class CallIncomingReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("XamarinCallInterceptor.CallIncomingReceiver, XamarinCallInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CallIncomingReceiver.class, __md_methods);
	}


	public CallIncomingReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CallIncomingReceiver.class)
			mono.android.TypeManager.Activate ("XamarinCallInterceptor.CallIncomingReceiver, XamarinCallInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

	java.util.ArrayList refList;
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
