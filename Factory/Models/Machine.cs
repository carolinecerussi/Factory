using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Factory.Models
{
	public class Machine
	{
		public Machine(){
			this.JoinEntities = new HashSet<EngineerMachine>();
		}
		[Key]
		public int MId {get;set;}
		public string MName {get;set;}
		public virtual ICollection<EngineerMachine> JoinEntities{get;set;}
	}
}