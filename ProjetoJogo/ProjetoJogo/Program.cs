using System;

namespace ProjetoJogo
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new JogoProjeto())
                game.Run();
        }
    }
}
