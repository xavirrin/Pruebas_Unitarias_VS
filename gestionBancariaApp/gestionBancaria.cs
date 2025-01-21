using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class gestionBancaria
{
    public double saldo;  // Saldo inicial de la cuenta, 1000€
    public const int ERR_OPERACION_NO_SELECCIONADA = 2;
    public const int ERR_CANTIDAD_INDICADA_NEGATIVA = 1;
    public const int ERR_SALDO_INSUFICIENTE = 3;

    public gestionBancaria(double saldoInicial)
    {
        saldo = saldoInicial;
    }

    public double obtenerSaldo()
    {
        return saldo;
    }

    public void realizarReintegro(double cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentOutOfRangeException("La cantidad indicada es negativa o cero.");
        }
        else
        {
            if (cantidad > saldo)
            {
                throw new ArgumentOutOfRangeException("Saldo insuficiente.");
            }
            saldo -= cantidad;
        }
    }

    public void realizarIngreso(double cantidad)
    {
        if (cantidad < 0)
        {
            throw new ArgumentOutOfRangeException("La cantidad indicada es negativa.");
        }
        saldo += cantidad;
    }
}


[TestClass]
public class gestionBancariaTest
{
    [TestMethod]
    public void TestRealizarIngreso_Valido()
    {
        gestionBancaria cuenta = new gestionBancaria(1000);
        cuenta.realizarIngreso(900); 
        Assert.AreEqual(1900, cuenta.obtenerSaldo());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestRealizarIngreso_Negativo()
    {
        gestionBancaria cuenta = new gestionBancaria(1000);
        cuenta.realizarIngreso(-100); 
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestRealizarReintegro_SaldoInsuficiente()
    {
        gestionBancaria cuenta = new gestionBancaria(1000);
        cuenta.realizarReintegro(1500); 
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestRealizarReintegro_CantidadNegativa()
    {
        gestionBancaria cuenta = new gestionBancaria(1000);
        cuenta.realizarReintegro(-100);
    }
}
