
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Factory.Models
{
	public class Engineer
	{
		public Engineer(){
			this.JoinEntities = new HashSet<EngineerMachine>();
		}
		[Key]
		public int EId {get;set;}

		public string EName {get;set;}

		public string EExperience {get;set;}

		public virtual ICollection<EngineerMachine> JoinEntities{get;set;}
	}

}