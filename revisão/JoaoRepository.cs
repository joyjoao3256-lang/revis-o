using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace revisão

    {
        public class JoaoRepository
    {
            private const string MeuBanco = "Data Source= Escola.db";
            public static void Inicializar()
            {
                using var conexao = new SqliteConnection(MeuBanco);
                conexao.Open();
                using var comando = conexao.CreateCommand();
                comando.CommandText = @"
                CREATE TABLE IF NOT EXISTS Joao(
                    Id INTEGER PRIMARY KEY, 
                    Nome INTEGER NOT NULL,
                    Idade  TEXT NOT NULL, 
                    Habilidades TEXT NOT NULL
                   
                );
             ";
                comando.ExecuteNonQuery();
            }
        public static void Adicionar(Joao_Miranda Habilidades1)
        {
            using var conexao = new SqliteConnection(MeuBanco);
            conexao.Open();
            using var comando = conexao.CreateCommand();
            comando.CommandText = @"
                INSERT INTO Provas(Disciplina, Nota, Questoes, Gabarito)
                VALUES ($disciplina, $nota, $questoes, $gabarito)
             ";
            comando.Parameters.AddWithValue("$Nome", Habilidades1.Nome);
            comando.Parameters.AddWithValue("$Idade", Habilidades1.Idade);
            comando.Parameters.AddWithValue("$Habilidade", JsonSerializer.Serialize(Habilidades1.Habilidades));

            comando.ExecuteNonQuery();
        }
        public static List<Joao_Miranda> Listar()
        {
            using var conexao = new SqliteConnection(MeuBanco);
            conexao.Open();
            using var comando = conexao.CreateCommand();
            comando.CommandText = @"
            SELECT Id, Disciplina, Nota, Questoes, Gabarito FROM Provas ORDER BY Id;
         ";
            using var leitor = comando.ExecuteReader();
            List<Joao_Miranda> Habilidade = new List<Joao_Miranda>();
            while (leitor.Read())
            {
                Joao_Miranda p = new Joao_Miranda();
                p.Nome = leitor.GetString(0);
                p.Habilidades = JsonSerializer.Deserialize<List<string>>(leitor.GetString(3)) ?? new List<string>();
                p.Idade = leitor.GetInt32(2);


                Habilidade.Add(p);
            }
            return Habilidade;
        }
    }
    }

