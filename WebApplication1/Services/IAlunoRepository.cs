using WebApplication1.Models;

namespace WebApplication1.Services
{
	public interface IAlunoRepository
	{
		public List<DadosAluno> obterTodosAlunos();
		public DadosAluno obterAlunosPorCpf(string cpf);

		public void Inserir(DadosAluno novoAluno);
	}
}
