using System;
using System.Windows.Forms;

/// <summary>
/// Summary description for Class1
/// </summary>
///


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
            mostrarError(ERR_CANTIDAD_INDICADA_NEGATIVA);
        }
        else
        {
            if (cantidad > 0 && saldo > cantidad)
            {
                saldo -= cantidad;
                
            }
            else
                mostrarError(ERR_SALDO_INSUFICIENTE);

        }
 
    }

    public void realizarIngreso(double cantidad)
    {

        if (cantidad < 0)
        {
            mostrarError(ERR_CANTIDAD_INDICADA_NEGATIVA);
        }
        else
        {
            if (cantidad > 0)
                saldo -= cantidad;
        }
      
    }


    public void mostrarError(int error)
    {

        switch (error)
        {
            case ERR_CANTIDAD_INDICADA_NEGATIVA:
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
                break;
            case ERR_OPERACION_NO_SELECCIONADA:
                MessageBox.Show("Seleccione la operación a realizar");
                break;
            case ERR_SALDO_INSUFICIENTE:
                MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                break;

        }

    }
}