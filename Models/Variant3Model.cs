using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace model_binding_tut.Models
{
	public class Variant3Model
	{
		[FromQuery(Name = "ids")]
		public List<int> ids { get; set; }

		[FromQuery(Name = "singleId")]
		public int singleId { get; set; } = -1;

		[FromHeader(Name = "SupportedTypes")]
		[MinLength(3)]
		public string SupportedTypes { get; set; } = "EveryThing";
	}
}
