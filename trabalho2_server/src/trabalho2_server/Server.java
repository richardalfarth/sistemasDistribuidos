package trabalho2_server;

import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Server {
	public static void main(String[] args) throws RemoteException {
		Registry registry = LocateRegistry.createRegistry(1777);
		System.out.println("Servidor no ar...");
		registry.rebind("banco", new ContaBancaria());
	}
}
