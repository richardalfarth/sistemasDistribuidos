package trabalho2;

import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;

public class Client {
	public static void main(String[] args) throws MalformedURLException, RemoteException, NotBoundException {
		ContaBanco banco = (ContaBanco) Naming.lookup("rmi://localhost:9000/banco");
		banco.getSaldo();
	}
}
