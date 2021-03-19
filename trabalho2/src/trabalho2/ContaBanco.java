package trabalho2;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface ContaBanco extends Remote {
	
		
	public double getSaldo() throws RemoteException;
	public void setSaldo(double saldo) throws RemoteException;
	public String getNumero() throws RemoteException;
	public void setNumero(String numero) throws RemoteException; 
	public void depositar(double valor) throws RemoteException;
	public void sacar(double valor) throws RemoteException;

}
