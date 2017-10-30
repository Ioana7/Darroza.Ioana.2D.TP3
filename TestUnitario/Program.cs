using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;  
using Archivos;
using Excepciones;
using EntidadesAbstractas;
using ClasesInstanciables;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace Test_Unitario
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        public void NacionalidadInvalida()
        {
            Universidad gim = new Universidad();
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", ENacionalidad.Extranjero, EClases.Laboratorio, EEstadoCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void AlumnoRepetido()
        {
            Universidad gim = new Universidad();
            try
            {
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456", ENacionalidad.Argentino, EClases.Programacion, EEstadoCuenta.Becado);
                gim += a3;
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void NumeroInvalido()
        {
            Double num = 16;
            if (num != 16)
            {
                Console.WriteLine("No es un numero válido.");
            }
        }

        [TestMethod]
        public void AlumnoInvalido()
        {
            Alumno a = new Alumno(15, "Darroza", "Ioana", "40644122", ENacionalidad.Argentino, EClases.SPD);
            a.Nombre = "123";

            if (a.Nombre != "Ioana")
            {
                Console.WriteLine("No es un nombre válido.");
            }
        }

        
        }
    }

