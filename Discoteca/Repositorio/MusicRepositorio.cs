using Discoteca.Data;
using Discoteca.Models;

namespace Discoteca.Repositorio
{
    public class MusicRepositorio : IMusicRepositorio
    {
        private readonly BancoContext _bancoContext;

        public MusicRepositorio(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public MusicModel ListarPorId(int id)
        {
            return _bancoContext.Musics.FirstOrDefault(x => x.Id == id);
        }

        public List<MusicModel> BuscarTodos()
        {
            return _bancoContext.Musics.ToList();
        }

        public MusicModel Adicionar(MusicModel music)
        {
            // gravar no banco de dados
            _bancoContext.Musics.Add(music);
            _bancoContext.SaveChanges();

            return music;
        }

        public MusicModel Atualizar(MusicModel music)
        {
            MusicModel musicDB = ListarPorId(music.Id);

            if (musicDB == null) throw new Exception("Houve um erro na atualização da música!");

            musicDB.Nome = music.Nome;
            musicDB.Banda = music.Banda;
            musicDB.Album = music.Album;

            _bancoContext.Musics.Update(musicDB);
            _bancoContext.SaveChanges();

            return musicDB;
        }

        public bool Apagar(int id)
        {
            MusicModel musicDB = ListarPorId(id);

            if (musicDB == null) throw new Exception("Houve um erro na deleção da música!");

            _bancoContext.Musics.Remove(musicDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
