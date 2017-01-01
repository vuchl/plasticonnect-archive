namespace ValidationManager
{
	public struct ValidationResult
	{
		public bool Status; 
		public Severity Severity;
		public string Message;
		public string Technical;

		public override string ToString()
		{
			return string.Format("**{3}** [{0}] \"{1}\" {{{2}}}", Severity, Message, Technical, Status?"Passed":"Failed");
		}
	}
}