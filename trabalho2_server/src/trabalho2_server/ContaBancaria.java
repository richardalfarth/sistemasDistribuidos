/*
 * Autores: Rennã Tiedt
 * 	 	  Richard Curbani Alfarth
 * 
 * 
 * */

package trabalho2_server;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;



public class ContaBancaria extends UnicastRemoteObject implements ContaBanco{
	private String numero;
	private double saldo;
	private ContaBanco titular;
	
	public ContaBancaria() throws RemoteException{
		super();
	}
	public double getSaldo() {
		return saldo;
	}
	public void setSaldo(double saldo) {
		this.saldo = saldo;
	}
	public String getNumero() {
		return numero;
	}
	public void setNumero(String numero) {
		this.numero = numero;
	}
	public void depositar(double valor) {
		this.saldo =+ valor;
	}
	public void sacar(double valor) {
		this.saldo =- valor;
	}
	public ContaBanco getTitular() {
		return titular;
	}
	public void setTitular(ContaBanco titular) {
		this.titular = titular;
	}
	
}
