using System;
using System.Collections.Generic;
using System.Text;

namespace Gals4Net.Core.IO
{
    /// <summary>
    /// Componete que controla os dados da linguagem em arquivos e execua a leitura e gravação dos dados em arquivos.
    /// </summary>
    public class GalsFile
    {
        private readonly IFileProcessor fileProcessor;

        /// <summary>
        /// Dados da linguagem.
        /// </summary>
        public GalsData Data { get; private set; }

        /// <summary>
        /// Arquivo.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Cria novo controlador de arquivos GALS com o processador para ler e gravar e os dados da linguagem.
        /// </summary>
        /// <param name="fileProcessor">Processador para ler e gravar.</param>
        /// <param name="data">Dados da linguagem.</param>
        public GalsFile(IFileProcessor fileProcessor, GalsData data)
        {
            this.fileProcessor = fileProcessor ?? throw new ArgumentNullException(nameof(fileProcessor));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// Cria novo controlador de arquivos GALS com o processador para ler e gravar e o arquivo para leitura
        /// dos dados da linguagem.
        /// </summary>
        /// <param name="fileProcessor">Processador para ler e gravar.</param>
        /// <param name="file">Arquivo que será gravado.</param>
        public GalsFile(IFileProcessor fileProcessor, string file)
        {
            this.fileProcessor = fileProcessor ?? throw new ArgumentNullException(nameof(fileProcessor));
            File = file ?? throw new ArgumentNullException(nameof(file));

            Data = fileProcessor.Load(file);
        }

        public void Save()
        {
            if (File == null)
                throw new InvalidOperationException("File must be informed");

            fileProcessor.Save(File, Data);
        }
    }
}
