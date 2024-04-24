namespace ProyectoDeAula.Models.Entidades
{
    public class CalculoPagoCliente
    {

        public static int CalcularValorAPagar(Cliente cliente, List<Cliente> clientes)
        {
            int valor_parcial = cliente.Consumo_energia * 850;
            int valor_incentivo = (cliente.Meta_ahorro - cliente.Consumo_energia) * 850;
            int valor_total_energia = valor_parcial - valor_incentivo;

            int valor_agua = 0;
            int valor_exceso = 0;
            int valor_total_agua = 0;
            int valor_pagar = 0;
            int promedio_consumo_agua = CalcularPromedioConsumoAgua(clientes);

            if (cliente.Consumo_agua > promedio_consumo_agua)
            {
                valor_agua = 25 * 4600;
                valor_exceso = (cliente.Consumo_agua - promedio_consumo_agua) * (2 * 4600);
                valor_total_agua = valor_agua + valor_exceso;
            }
            else
            {
                valor_total_agua = cliente.Consumo_agua * 4600;
            }
            valor_pagar = valor_total_energia + valor_total_agua;
            return valor_pagar;
        }

        public static int CalcularConsumoExcesivoAgua(List<Cliente> clientes)
        {
            int promedio_consumo_agua = CalcularPromedioConsumoAgua(clientes);
            int consumo_excesivo_agua = 0;
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Consumo_agua > promedio_consumo_agua)
                {
                    consumo_excesivo_agua += cliente.Consumo_agua - promedio_consumo_agua;
                }
            }
            return consumo_excesivo_agua;
        }

        public static int CalcularPromedioConsumoAgua(List<Cliente> clientes)
        {
            int suma_consumo_agua = 0;
            foreach (Cliente cliente in clientes)
            {
                suma_consumo_agua += cliente.Consumo_agua;
            }
            double promedio_consumo_agua_double = suma_consumo_agua / (double)clientes.Count;
            return (int)promedio_consumo_agua_double;
        }
    }

}
