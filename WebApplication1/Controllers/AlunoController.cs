using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("api/aluno")]
	public class AlunoController : ControllerBase
	{
		private static List<DadosAluno> dadosAlunosList = new List<DadosAluno>();


		[HttpGet]
		public IActionResult OlaAluno()
		{
			return Ok("Ola Mundo");
		}

		[HttpGet]
		[Route("ObterPorCpf")]
		public IActionResult ObterPorCpf(string cpf)
		{
			var alunoPesquisado = dadosAlunosList.Where(a => a.cpf == cpf).FirstOrDefault();

			if (alunoPesquisado is null)
				return NotFound($"Aluno com cpf {cpf} não encontrado.");

			return Ok(alunoPesquisado);
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
		public IActionResult Inserir(NovoAluno dados)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			dadosAlunosList.Add(new DadosAluno()
			{
				cpf = dados.cpf,
				email = dados.email,
				nome = dados.nome,
				telefone = dados.telefone
			});

			return Ok($"Aluno(a) {dados.nome} inserido com sucesso.");
		}

		[HttpDelete]
		[Route("Remover")]
		public IActionResult Remover(string cpf)
		{
			var alunoPesquisado = dadosAlunosList.Where(a => a.cpf == cpf).FirstOrDefault();


			if (alunoPesquisado is null)
				return NotFound($"Aluno com cpf {cpf} não encontrado.");

			dadosAlunosList.Remove(alunoPesquisado);

			return NoContent();
		}

		[HttpPut]
		[Route("Atualizar/{cpf}")]
		public IActionResult Atualizar(string cpf, DadosAluno alunoAtualizado)
		{
			var alunoPesquisado = dadosAlunosList.Where(a => a.cpf == cpf).FirstOrDefault();


			if (alunoPesquisado is null)
				return NotFound($"Aluno com cpf {cpf} não encontrado.");

			alunoPesquisado.nome = alunoAtualizado.nome;
			alunoPesquisado.cpf = alunoAtualizado.cpf;
			alunoPesquisado.telefone = alunoAtualizado.telefone;

			return NoContent();
		}
	}
}
