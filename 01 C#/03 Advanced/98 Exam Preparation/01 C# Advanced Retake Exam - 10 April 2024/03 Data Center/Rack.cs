using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server>();
        }

        public int Slots { get; set; }

        public List<Server> Servers { get; set; }

        public int GetCount => Servers.Count;

        public void AddServer(Server server)
        {
            if (GetCount >= Slots || Servers.FirstOrDefault(x => x.SerialNumber == server.SerialNumber) != null)
            {
                return;
            }

            Servers.Add(server);
        }

        public bool RemoveServer(string serialNumber)
        {
            Server server = Servers.FirstOrDefault(x => x.SerialNumber == serialNumber);

            return Servers.Remove(server);
        }

        public string GetHighestPowerUsage()
        {
            //Option 1
            Server bestServer = Servers.OrderByDescending(x => x.PowerUsage).FirstOrDefault();

            //Option 2
            // Server bestServer = null;
            //int maxPower = 0;

            //foreach (var server in Servers)
            //{
            //    if (server.PowerUsage > maxPower)
            //    {
            //        bestServer = server;
            //        maxPower = server.PowerUsage;
            //    }
            //}

            return bestServer.ToString();
        }

        public int GetTotalCapacity()
        {
            //Option 1
            int totalCapacity = Servers.Sum(x => x.Capacity);

            //Option 2
            //int totalCapacity = 0;

            //foreach (var server in Servers)
            //{
            //    totalCapacity += server.Capacity;
            //}

            return totalCapacity;
        }

        public string DeviceManager()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GetCount} servers operating:");

            foreach (var server in Servers)
            {
                sb.AppendLine(server.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}