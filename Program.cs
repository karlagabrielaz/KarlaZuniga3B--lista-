using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA50NUMEROS
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> listaenteros = new List<int>();
            for (int i = 1; i <= 50; i++)
            {
                listaenteros.Add(random.Next(1, 100));
            }

          //  Console.WriteLine("NÚMEROS ALEATORIOS");
          //  listaenteros.ForEach(e => Console.WriteLine(e));

            var variable = from a in listaenteros select a;
            
            /////////////////////////////////////////////////////////////////////////
            Console.WriteLine("NUMEROS PRIMOS");
            (from a in listaenteros where Primo(a) select a).ToList().ForEach(a => Console.WriteLine(a));

            /////////////////////////////////////////////////////////////////////////
            Console.WriteLine("SUMA DE TODOS LOS ELEMENTOS");
            int suma = 0;
            listaenteros.ForEach(a =>
            {
                suma = suma + a;
            });
            Console.WriteLine(suma);

            //////////////////////////////////////////////////////////////////////
            Console.WriteLine("LISTA DE CUADRADO DE LOS NUMEROS");
            List<int> listacuadrado = new List<int>();
            listacuadrado.AddRange(from a in variable = variable.Select(x => x * x) select a);
            Console.WriteLine(string.Join(" ", listacuadrado));

            /////////////////////////////////////////////////////////////////////

            Console.WriteLine("LISTA CON LOS NUMEROS PRIMOS");
            List<int> listaprimos = new List<int>();
            listaprimos.AddRange(from a in listaenteros where Primo(a) select a);
            foreach (var item in listaprimos)
            {
                Console.WriteLine(item);
            }
            //////////////////////////////////////////////////////////////////////
            Console.WriteLine("PROMEDIO DE TODOS LOS NUMEROS MAYORES A 50");
            var resultado3 = (from i in listaenteros where i > 50 select i);
            int mayor = 0, contador3 = 0;
            double promedio = 0;
            foreach (var item in resultado3)
            {
                contador3++;
                mayor = mayor + item;
            }
            promedio = (mayor / contador3);
            Console.WriteLine("Promedio:{0}", promedio);

            

            //////////////////////////////////////////////////////////////////////

            Console.WriteLine("CANTIDAD DE NUMEROS PARES E IMPARES");
            var resultado = from i in listaenteros select i;
            int contadorpar = 0, contadorimpar=0;
            listaenteros.ForEach(a =>
            {
                if (Espar(a))
                {
                    contadorpar++;
                }
                else
                {
                    contadorimpar++;
                }

            });
            Console.WriteLine("Cantidad números Par: {0}\nCantidad números Impar: {1}", contadorpar, contadorimpar);

           /* var resultado = from i in variable where Espar(i) select i;
            int contador = 0;
            foreach (var item in resultado)
            {
                contador++;
            }
            Console.WriteLine("Cantidad números pares: {0}", contador);

            var resultado2 = from i in variable where !Espar(i) select i;
            int contador2 = 0;
            foreach (var item in resultado2)
            {
                contador2++;
            }
            Console.WriteLine("Cantidad números impares: {0}", contador2);*/

            //////////////////////////////////////////////////////////////////////

           Console.WriteLine("NUMERO Y CANTIDAD DE VECES QUE SE ENCUENTRA EN LA LISTA");
           var resultado1 = from i in listaenteros select i;
            foreach (var item in resultado1.Select((v) => new {Valor = v }) // Obtener valor
               .GroupBy(a => a.Valor) // Agrupar por el valor
               .Select(a => new {
                   Valor = a.Key, // key de la agrupación (valor)
                    Cantidad = a.Count(), // Cantidad de duplicidad
                }))
            {
                Console.WriteLine(string.Format("Número: '{0}'\tCantidad de veces repetidas: {1}", item.Valor, item.Cantidad));
            }
            //////////////////////////////////////////////////////////////////////
            Console.WriteLine("ELEMENTOS EN FORMA DESCENDENTE");
            (from a in listaenteros orderby a descending select a).ToList().ForEach(e => Console.WriteLine(e));

            //////////////////////////////////////////////////////////////////////
            Console.WriteLine("NUMEROS UNICOS");
            int sumaUnica = 0;
            var resultado6 = from i in listaenteros select i;
            int contadorunico = 0;
            foreach (var item in resultado6)
            {
                foreach (var itemx in resultado6)
                {
                    if (item ==itemx)
                    {
                        contadorunico++;
                    }
                }
                if (contadorunico==1)
                {
                    sumaUnica = sumaUnica + item;
                    Console.WriteLine("Número único: {0}", item);
                }
                contadorunico = 0;
            }
           
           
            //////////////////////////////////////////////////////////////////////
            Console.WriteLine("SUMA DE TODOS LOS NUMEROS UNICOS");
            Console.WriteLine(sumaUnica);
            
            Console.ReadKey();

        }
        
            public static int Suma(int num)
        {
            int suma = 0;
            suma = suma + num;
            return suma;
        }
        
      
        static bool Primo(int n)
        {
            return n % 2 != 0;
        }
     
        
        static bool Espar(int n)
        {
            return n % 2 == 0;
        }
        
    }
}

