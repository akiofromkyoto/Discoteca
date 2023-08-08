using Discoteca.Models;

namespace Discoteca.Repositorio
{
    public interface IMusicRepositorio
    {
        MusicModel ListarPorId(int id);
        List<MusicModel> BuscarTodos();
        MusicModel Adicionar(MusicModel music);
        MusicModel Atualizar(MusicModel music);
        bool Apagar(int id);
    }
}
