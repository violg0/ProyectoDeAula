namespace ProyectoDeAula.Models.Entidades
    //el anterior era clientess
{
    public class Cliente
    { 
            public int cedula { get; set;  }
            //[Required(ErrorMessage = "el campo {0} es obligatorio")]
            public int estrato { get; set; }
            public int meta_ahorro { get; set; }
            public int consumo_energia { get; set; }
            public int consumo_agua { get; set; }


            public Cliente(int cedula, int estrato, int meta_ahorro, int consumo_energia, int consumo_agua)
            {
                    this.cedula = cedula;
                    this.estrato = estrato;
                    this.meta_ahorro = meta_ahorro;
                    this.consumo_energia = consumo_energia;
                    this.consumo_agua = consumo_agua;
            }
        public Cliente()
        {
        }

        public void ActualizarCliente(int nuevaCedula, int nuevoEstrato, int nuevaMetaAhorro, int nuevoConsumoEnergia, int nuevoConsumoDeAgua)
        {
                this.cedula = nuevaCedula;
                this.estrato = nuevoEstrato;
                this.meta_ahorro = nuevaMetaAhorro;
                this.consumo_energia = nuevoConsumoEnergia;
                this.consumo_agua = nuevoConsumoDeAgua;
        }
    }
}



