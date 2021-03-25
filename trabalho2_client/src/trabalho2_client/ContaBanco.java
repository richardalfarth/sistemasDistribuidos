/*
 * Autores: Rennã Tiedt
 * 	 	  Richard Curbani Alfarth
 * 
 * 
 * */

package trabalho2_client;


import java.rmi.Remote;
import java.rmi.RemoteException;



public interface ContaBanco extends Remote {
	
		
	public double getSaldo() throws RemoteException;
	public void setSaldo(double saldo) throws RemoteException;
	public String getNumero() throws RemoteException;
	public void setNumero(String numero) throws RemoteException; 
	public void depositar(double valor) throws RemoteException;
	public void sacar(double valor) throws RemoteException;
	public ContaBanco getTitular() throws RemoteException;
	public void setTitular(ContaBanco titular) throws RemoteException;

}
