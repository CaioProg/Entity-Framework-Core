﻿using Alura.Loja.Testes.ConsoleApp.Classes;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var contexto = new LojaContext())
			{
				var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
				var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

				loggerFactory.AddProvider(SqlLoggerProvider.Create());

				var produtos = contexto.Produtos.ToList();


				foreach (var p in produtos)
				{
					Console.WriteLine(p);
				}
				Console.WriteLine("----------------");
				foreach (var e in contexto.ChangeTracker.Entries())
				{
					Console.WriteLine(e.State);
				}


				var p1 = produtos.Last();
				p1.Nome = "Happy Potter";

				Console.WriteLine("----------------");
				foreach (var e in contexto.ChangeTracker.Entries())
				{
					Console.WriteLine(e.State);
				}

				contexto.SaveChanges();

				//produtos = contexto.Produtos.ToList();
				//foreach (var p in produtos)
				//{
				//	Console.WriteLine(p);
				//}
			}
			Console.ReadKey();	
		}
	}
}

