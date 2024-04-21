using System.Text;

namespace ProyectoDeAula.Models.Entidades
{
    public class GestionClientes
    {
        public static void AgregarClientes(List<Cliente> clientes, Cliente cliente)
        {
            clientes.Add(cliente);
        }


        public static string MostrarClientes(List<Cliente> clientes)
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("Lista de clientes:");

            foreach (Cliente cliente in clientes)
            {
                texto.AppendLine($"Cédula: {cliente.cedula}, Estrato: {cliente.estrato}, Meta de ahorro: {cliente.meta_ahorro}, Consumo de energía: {cliente.consumo_energia}, Consumo de agua: {cliente.consumo_agua}");
            }

            return texto.ToString();
        }

        static void EliminarCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Ingrese la cédula del cliente a eliminar:");
            int cedulaCliente = Convert.ToInt32(Console.ReadLine());
            Cliente? clienteEliminar = clientes.Find(c => c.cedula == cedulaCliente);
            if (clienteEliminar != null)
            {
                clientes.Remove(clienteEliminar);
                Console.WriteLine("Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
        

        static void ActualizarCliente(List<Cliente> clientes)

        {
            Console.WriteLine("Ingrese la cédula del cliente a actualizar:");
            int cedulaCliente = Convert.ToInt32(Console.ReadLine());
            Cliente? clienteActualizar = clientes.Find(c => c.cedula == cedulaCliente);
            if (clienteActualizar != null)
            {
                Console.WriteLine("Ingrese la nueva cédula del cliente:");
                int nuevaCedula = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo estrato del cliente:");
                int nuevoEstrato = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la nueva meta de ahorro de energía:");
                int nuevaMetaAhorro = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo consumo actual de energía:");
                int nuevoConsumoEnergia = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo consumo actual de agua:");
                int nuevoConsumoAgua = Convert.ToInt32(Console.ReadLine());
                clienteActualizar.ActualizarCliente(nuevaCedula, nuevoEstrato, nuevaMetaAhorro, nuevoConsumoEnergia, nuevoConsumoAgua);
                Console.WriteLine("Cliente actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}
