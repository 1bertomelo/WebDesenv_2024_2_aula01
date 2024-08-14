using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("api/aluno")]
	public class AlunoController : ControllerBase
	{
		private static List<DadosAluno> dadosAlunosList =  new List<DadosAluno>();

		public AlunoController()
		{

		}

		[HttpGet]
		public IActionResult OlaAluno()
		{
			return Ok("Ola Mundo");
		}

		[HttpGet]
		[Route("ObterTodos")]
		public IActionResult ObterTodos()
		{
			return Ok(dadosAlunosList);
		}

		[HttpPost]
		public IActionResult OlaAlunoNome(string nome)
		{
			return Ok($"Ola Mundo {nome}");
		}

		[HttpPost]
		[Route("Inserir")]
		public IActionResult Inserir(DadosAluno dados)
		{
			dadosAlunosList.Add(dados);
			return Ok($"Aluno(a) {dados.nome} inserido com sucesso.");
		}
	}
}
