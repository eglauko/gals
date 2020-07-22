namespace Gals4Net.Core.IO
{
    /// <summary>
    /// Componente utilizado para processar um arquivo da linguagem.
    /// </summary>
    public interface IFileProcessor
    {
        /// <summary>
        /// Carrega um arquivo.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        GalsData Load(string file);

        void Save(string file, GalsData data);
    }
}
