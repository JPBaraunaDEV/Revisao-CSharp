using System;

namespace rev
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indice_aluno = 0;

            string escolha = recebe_escolha();

            while (escolha.ToUpper() != "X") 
            {
                switch (escolha)
                {
                    case "1":
                        // ADD ALUNO
                        
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }else
                        {
                            throw new ArgumentException("Valor da nota deve ser DECIMAL");
                        }

                        alunos[indice_aluno] = aluno;
                        indice_aluno++;

                        break;
                    
                    case "2":
                        // LISTA ALUNO
                        foreach (var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} --- NOTA: {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                        // MÉDIA GERAL DOS ALUNOS
                        decimal nota_total = 0;
                        var nAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                           if(!string.IsNullOrEmpty(alunos[i].Nome))
                           {
                               nota_total = nota_total + alunos[i].Nota;
                               nAlunos++;
                           } 
                        }

                        var media_geral = nota_total/nAlunos;
                        
                         Conceito conceito_geral;

                        if(media_geral < 2)
                        {
                            conceito_geral = Conceito.E;
                        }else if(media_geral < 4)
                        {
                            conceito_geral = Conceito.D;
                        }else if(media_geral < 6)
                        {
                            conceito_geral = Conceito.C;
                        }else if(media_geral > 8)
                        {
                            conceito_geral = Conceito.B;
                        }else
                        {
                            conceito_geral = Conceito.A;
                        }

                        Console.WriteLine($"MEDIA GERAL DOS ALUNOS >> {media_geral} --- CONCEITO >> {conceito_geral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                escolha = recebe_escolha();
            }
        }

        private static string recebe_escolha()
        {
            Console.WriteLine("Insira a opção desejada:");
            Console.WriteLine("1 >> INSERIR NOVO ALUNO");
            Console.WriteLine("2 >> LISTAR ALUNO");
            Console.WriteLine("3 >> CALCULAR MÉDIA GERAL DOS ALUNOS");
            Console.WriteLine("X >> SAIR");

            Console.WriteLine();

            string escolha = Console.ReadLine();

            Console.WriteLine();

            return escolha;
        }
    }
}
