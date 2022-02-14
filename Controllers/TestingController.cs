using Microsoft.AspNetCore.Mvc;

using model_binding_tut.Models;

namespace model_binding_tut.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class TestingController : ControllerBase
	{
		[BindProperty(SupportsGet = true)]
		public bool isTrue2 { get; set; } = false;
		[HttpGet("{id}")]
		public async Task<string> GetHello(int id, bool isTrue = false)
		{
			return $"Id: {id}, Is true ? - {isTrue}, Is true2 ? - {isTrue2}";
		}

		[HttpGet("variant2")]
		public async Task<string> GetVariant2([FromQuery] List<int> ids,
			[FromQuery] int singleId = -1,
			[FromHeader] string? SupportedTypes = "Everything")
		{
			string idsStr = "";
			foreach(var id in ids)
			{
				idsStr += id.ToString() + "\t";
			}
			return $"Passed ids: {idsStr}, Supported types from body : {SupportedTypes}, Passed SingleId: {singleId}";
		}

		[HttpGet("variant3")]
		public async Task<string> GetVariant3([FromQuery]Variant3Model model)
		{
			string idsStr = "";
			foreach (var id in model.ids)
			{
				idsStr += id.ToString() + "\t";
			}
			return $"Passed ids: {idsStr}, Supported types from body : {model.SupportedTypes}, Passed SingleId: {model.singleId}";
		}

		[HttpPost("variant4")]
		public async Task<Dictionary<string, string>> GetVariant4([FromBody] Variant4Model model)
		{
			return new Dictionary<string, string>
			{
				["name"] = model.name,
				["email"] = model.email,
				["issuedAt"] = new DateTime().ToString()
			};
		}

		[HttpPost("variant5")]
		[Consumes("multipart/form-data")]
		public async Task<string> GetVariant5([FromForm] IFormFile[] files)
		{
			string names = "";
			foreach(var file in files)
			{
				names += file.FileName + "\t";
			}
			return $"Uploaded files: {names}";
		}
	}
}
