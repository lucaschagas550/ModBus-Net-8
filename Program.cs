using EasyModbus;

namespace ModBus
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {

                //"10.20.30.50"
                //"127.0.0.1"
                ModbusClient modbusClient = new ModbusClient("127.0.0.1", 502);
                modbusClient.Connect();
                //bool[] arrayCoilsTrue = new bool[3] { true, true, true};

                //modbusClient.WriteMultipleCoils(0, new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true });
                //modbusClient.WriteMultipleCoils(0, arrayCoilsTrue);
                modbusClient.WriteSingleCoil(10, true);
                //modbusClient.WriteSingleRegister(2, 99);
                //modbusClient.WriteSingleRegister(1, 140);

                modbusClient.WriteSingleRegister(0, 2);
                var teste1 = modbusClient.ReadHoldingRegisters(0, 10);
                foreach (var item in teste1)
                {
                    Console.WriteLine($"Holding: {item}");
                }
                Console.WriteLine("\nvalores\n");
                await Task.Delay(10000);

                modbusClient.WriteSingleRegister(0, 16);

                //var coils = modbusClient.ReadCoils(0, 15);

                //foreach (var item in coils)
                //{
                //    Console.WriteLine($"coils: {item}");
                //}

                modbusClient.WriteSingleRegister(0, 11);
                var teste = modbusClient.ReadHoldingRegisters(0, 10);
                foreach (var item in teste)
                {
                    Console.WriteLine($"Holding: {item}");
                }

                Console.WriteLine("\nvalores\n");
                await Task.Delay(10000);
                await PausaComTaskDelay(1);
                modbusClient.WriteSingleRegister(0, 1024);
                var teste2 = modbusClient.ReadHoldingRegisters(0,10);
                foreach (var item in teste2)
                {
                    Console.WriteLine($"Holding: {item}");
                }

                Console.Read();
                Console.WriteLine("teste");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task PausaComTaskDelay(int delay)
        {
            await Task.Delay(delay);
        }
    }
}
