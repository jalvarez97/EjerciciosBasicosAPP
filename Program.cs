using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SUPT
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (IniciarMenu()) { }
        }

        private static bool IniciarMenu()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine("   Bienvenido al menú ->>");
            Console.WriteLine("     1.División de enteros");
            Console.WriteLine("     2.Calcular media aritmética");
            Console.WriteLine("     3.Convertidor Pascal Case");
            Console.WriteLine("     4.Organizador de fechas");
            Console.WriteLine("     5.Comprobador de palindromos");
            Console.WriteLine("     6.Comprobador de palindromos numericos");
            Console.WriteLine("     7.Calcular potencia");
            Console.WriteLine("     8.Adivinar numero");
            Console.WriteLine("     9.Comparación de cadenas");
            Console.WriteLine("    10.Salir");
            Console.WriteLine("   Elija la opción que desea ejecutar");

            int nInput;
            while (!int.TryParse(Console.ReadLine(), out nInput))
                Console.WriteLine(" Se requiere un valor numérico entre 1 y 9");

            return SeleccionaOpciones(nInput);
        }

        private static bool SeleccionaOpciones(int nOpcion)
        {
            switch (nOpcion)
            {
                case 1:
                    DividirEnteros();
                    break;
                case 2:
                    Media();
                    break;
                case 3:
                    ToPascalCase();
                    break;
                case 4:
                    OrganizadorFechas();
                    break;
                case 5:
                    ComprobarPalindromo();
                    break;
                case 6:
                    PalindromoNumerico();
                    break;
                case 7:
                    CalculaPotencias();
                    break;
                case 8:
                    AdivinarNumero();
                    break;
                case 9:
                    CompararCadenas();
                    break;
                case 10:
                    return false;
                default:
                    Console.Write(" Opción inexistente, pulse cualquier tecla para continuar . . .");
                    Console.ReadKey();
                    break;
            }
            return true;
        }

        private static void DividirEnteros()
        {
            int nCociente = 0;
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado división de enteros ->>");
            //Obtenemos numerador y comprobamos valor numerico
            Console.WriteLine(" Introduzca el numerador:");
            int nNumerador;
            while (!int.TryParse(Console.ReadLine(), out nNumerador))
                Console.WriteLine(" SE DEBE INTRODUCIR NUMERO!");

            Console.WriteLine(" Introduzca el denominador:");
            int nDenominador;
            while (!int.TryParse(Console.ReadLine(), out nDenominador))
                Console.WriteLine(" SE DEBE INTRODUCIR UN NUMERO!");

            if (nDenominador != 0)
            {
                while (nNumerador >= nDenominador)
                {
                    nCociente += 1;
                    nNumerador -= nDenominador;
                }

                Console.Write(" El resultado de la división es: ");
                Console.WriteLine(nCociente);

            }
            else
            {
                Console.WriteLine(" Valor indeterminado.");
            }

            Console.WriteLine(" Pulse cualquier tecla para volver al menu . . .");
            Console.ReadKey();
        }

        private static void Media()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado media aritmética ->>");

            List<int> listaNumeros = new List<int>();
            int nNumero = 1;
            do
            {
                Console.WriteLine(" Introduzca un número:");
                Console.WriteLine(" Para finalizar la media introduzca '0'");

                while (!int.TryParse(Console.ReadLine(), out nNumero))
                    Console.WriteLine(" SE DEBE INTRODUCIR NUMERO!");

                listaNumeros.Add(nNumero);
            }
            while (nNumero != 0);

            if (nNumero == 0)
            {
                double suma = 0.0;

                foreach (int i in listaNumeros)
                {
                    suma = suma + i;
                }

                double resultado = suma / (listaNumeros.Count - 1);
                Console.WriteLine(" La media aritmética de los datos introducidos " + resultado);
                Console.WriteLine(" Pulse cualquier tecla para volver al menu . . .");
                Console.ReadKey();

            }
        }

        private static void ToPascalCase()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado Convertidor a Pascal Case ->>");
            Console.WriteLine(" Introduzca la frase a transformar:");

            string sInput = Console.ReadLine();
            string sOutput = null;

            for (int i = 0; i < sInput.Length; i++)
            {
                if (i == 0)
                    sOutput = sInput.Substring(i, 1).ToUpper();
                else
                    if (sInput.Substring(i - 1, 1).Equals(" "))
                    sOutput += sInput.Substring(i, 1).ToUpper();
                else
                    sOutput += sInput.Substring(i, 1);

            }

            Console.WriteLine(sOutput.Replace(" ", ""));
            Console.WriteLine(" Pulse cualquier tecla para volver al menu . . .");
            Console.ReadKey();
        }

        private static void OrganizadorFechas()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado Organizador de fechas ->>");
            Console.WriteLine(" Las fechas introducidas deben ser coherentes con su formato.");

            //Introducimos fecha1
            Console.WriteLine(" Introduzca la primera fecha:");
            DateTime dFecha;
            while (!DateTime.TryParse(Console.ReadLine(), out dFecha))
                Console.WriteLine(" Formato de fecha no valido, ejemplo del formato esperado '01/01/1900'");

            //Hacemos lo mismo para fecha2
            Console.WriteLine(" Introduzca la segunda fecha:");
            DateTime dFecha2;
            while (!DateTime.TryParse(Console.ReadLine(), out dFecha2))
                Console.WriteLine(" Formato de fecha no valido, ejemplo del formato esperado '01/01/1900'");
           
            switch (CompruebaFechas(dFecha, dFecha2))
            {
                case true:
                    Console.WriteLine(" La fecha " + dFecha.ToString("dd/MM/yyyy") + " viene después de " + dFecha2.ToString("dd/MM/yyyy"));
                    break;
                case null:
                    Console.WriteLine(" La fecha " + dFecha.ToString("dd/MM/yyyy") + " es igual a " + dFecha2.ToString("dd/MM/yyyy"));
                    break;
                case false:
                    Console.WriteLine(" La fecha " + dFecha.ToString("dd/MM/yyyy") + " viene antes que " + dFecha2.ToString("dd/MM/yyyy"));
                    break;
            }
            
            Console.WriteLine(" Pulse cualquier tecla para volver al menu . . .");
            Console.ReadKey();
        }

        private static Boolean? CompruebaFechas (DateTime dFecha, DateTime dFecha2)
        {
            Boolean? bAntesDespues;

            if (dFecha.Year > dFecha2.Year)
            {
                bAntesDespues = true;
            }
            else if (dFecha.Year == dFecha2.Year)
            {
                if (dFecha.Month > dFecha2.Month)
                {
                    bAntesDespues = true;
                }                    
                else if (dFecha.Month == dFecha2.Month)
                {
                    if (dFecha.Day > dFecha2.Day)
                    {
                        bAntesDespues = true;
                    }                       
                    else if (dFecha.Day == dFecha2.Day)
                    {
                        bAntesDespues = null;
                    }
                    else
                    {
                        bAntesDespues = false;
                    }                        
                }
                else 
                { 
                    bAntesDespues = false;
                }
            }
            else
            {
                bAntesDespues = false;
            }                

            return bAntesDespues;
        }

        private static void ComprobarPalindromo()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado Comprobador de Palindromos ->>");
            Console.WriteLine(" Introduzca la Palabra:");

            string sInput = Console.ReadLine();
            bool palindromo = EsPalindromo(sInput);

            if (palindromo)
                Console.WriteLine(" La cadena '" + sInput + "' ES un palindromo.");
            else
                Console.WriteLine(" La cadena '" + sInput + "' NO es un palindromo.");

            Console.WriteLine(" Pulse cualquier tecla para volver al menu . . .");
            Console.ReadKey();
        }

        private static bool EsPalindromo(string sInput)
        {
            string sPalabra = sInput;
            sPalabra = sPalabra.ToLower();
            int length = sInput.Length;
            char[] sPalabraArray = sInput.ToCharArray();
            string sPalabra2 = "";

            for (int i = length - 1; i >= 0; i--)
            {
                sPalabra2 += sPalabraArray[i];
            }

            return sPalabra2.Equals(sPalabra);
        }

        private static void PalindromoNumerico()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado Comprobador de Palindromos Numericos->>");
            Console.WriteLine(" Introduzca el numero:");

            int nInput;
            while (!int.TryParse(Console.ReadLine(), out nInput))
                Console.WriteLine(" INTRODUCE UN NÚMERO");

            if (EsPalindromoNumerico(nInput))
                Console.WriteLine(" El numero '" + nInput + "' ES un palindromo.");
            else
                Console.WriteLine(" El numero '" + nInput + "' NO es un palindromo.");

            Console.WriteLine(" Pulse cualquier tecla para volver al menu . . .");
            Console.ReadKey();
        }

        private static bool EsPalindromoNumerico(int nNum)
        {
            // nNumInvertido almacena al reves el numero introducido
            int nNumIntroducido = nNum;
            int nNumInvertido = 0;

            while (nNumIntroducido > 0)
            {
                // esto almacenará el último dígito de `nNumIntroducido` en la variable `nInvertirDigito`
                int nInvertirDigito = nNumIntroducido % 10;

                // añade `nInvertirDigito` a `nNumInvertido` en el lugar de uno
                // por ejemplo, si `nNumInvertido = `54` y `nInvertirDigito = 7`, entonces el nuevo `nNumInvertido` sería 547
                nNumInvertido = nNumInvertido * 10 + nInvertirDigito;

                // elimina el último dígito de `nNumIntroducido`
                // por ejemplo, si `n` es 2662, entonces la nueva `n` sería 266
                nNumIntroducido = nNumIntroducido / 10;
            }

            return nNum == nNumInvertido;
        }

        private static void CalculaPotencias()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado Calcular Potencia->>");

            Console.WriteLine(" Introduzca el numero:");
            long nNumero;
            while (!long.TryParse(Console.ReadLine(), out nNumero))
                Console.WriteLine(" INTRODUCE UN NÚMERO");

            Console.WriteLine("  Introduzca la potencia a la que desea elevarlo:");
            long nPotencia;
            while (!long.TryParse(Console.ReadLine(), out nPotencia))
                Console.WriteLine(" INTRODUCE UN NÚMERO");

            long nResultado = CalcularPotencia(nNumero, nPotencia);
            Console.WriteLine(nNumero + " elevado a " + nPotencia + " es " + nResultado);

            Console.WriteLine(" Pulse cualquier tecla para volver al menu . . .");
            Console.ReadKey();
        }

        private static long CalcularPotencia(long numero, long potencia)
        {
            long resultado = numero;
            while (potencia > 1)
            {
                resultado = resultado * numero;
                potencia--;
            }
            return resultado;
        }

        private static void AdivinarNumero()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado Adivinar Número->>");
            Console.WriteLine(" ¡Entre 1 y 20, adivina el número que estoy pensando!: ");
            Console.WriteLine(" Introduce un número: ");

            int nInput;
            while (!int.TryParse(Console.ReadLine(), out nInput))
                Console.WriteLine(" INTRODUCE UN NÚMERO");

            Random rGenerator = new Random();
            int nGenerado = rGenerator.Next(1, 20);

            while (nGenerado != nInput)
            {
                if (nGenerado > nInput)
                {
                    Console.WriteLine(" ¡Casi casi, te has quedado corto!");
                    Console.WriteLine(" Introduce un número: ");
                    while (!int.TryParse(Console.ReadLine(), out nInput))
                        Console.WriteLine(" INTRODUCE UN NÚMERO");
                }
                else
                {
                    Console.WriteLine(" ¡Uyyyyy, te has pasado!");
                    Console.WriteLine(" Introduce un número: ");
                    while (!int.TryParse(Console.ReadLine(), out nInput))
                        Console.WriteLine(" INTRODUCE UN NÚMERO");
                }
            }

            Console.WriteLine(" !Lo has adivinado!");
            Console.WriteLine(nGenerado + " es la respuesta correcta!");
        }

        private static void CompararCadenas()
        {
            Console.Clear();
            Console.WriteLine(" SUPT APP");
            Console.WriteLine(" A seleccionado Comparacion de Cadenas ->>");
            
            Console.WriteLine(" Introduzca la primera palabra:");
            string sInput = Console.ReadLine();

            Console.WriteLine(" Introduzca la segunda palabra:");
            string sInput2 = Console.ReadLine();
           
            switch (CompruebaOrdenCadenas(sInput, sInput2))
            {
                case true:
                    Console.WriteLine(sInput + " va antes que " + sInput2);
                    break;
                case null:
                    Console.WriteLine(sInput + " es igual que " + sInput2);
                    break;
                case false:
                    Console.WriteLine(sInput + " va después que " + sInput2);
                    break;
            }
            
            Console.WriteLine(" Pulse cualquier tecla para volver al menu . . .");
            Console.ReadKey();

        }

        private static Boolean? CompruebaOrdenCadenas(string sInput, string sInput2)
        {
            Boolean? bAntesDespues = null;

            string sPalabra = sInput.ToLower();
            int nLength = sPalabra.Length;

            string sPalabra2 = sInput2.ToLower();
            int nLength2 = sPalabra2.Length;

            char[] aPalabraArray = sPalabra.ToCharArray();
            char[] aPalabraArray2 = sPalabra2.ToCharArray();

            int nMinLength = nLength > nLength2 ? nLength2 : nLength;

            for (int i = 0; i < nMinLength; i++)
            {
                if (aPalabraArray[i] == aPalabraArray2[i])
                {
                    if (i == nMinLength - 1)
                    {
                        if (nLength == nLength2)
                        {
                            bAntesDespues = null;
                        }
                        else if (nLength < nLength2)
                        {
                            bAntesDespues = true;
                        }
                        else
                        {
                            bAntesDespues = false;
                        }
                    }
                }
                else if (aPalabraArray[i] < aPalabraArray2[i])
                {
                    bAntesDespues = true;
                    i = nMinLength;
                }
                else
                {
                    bAntesDespues = false;
                    i = nMinLength;
                }
            }

            return bAntesDespues;
        }       

    }
}
