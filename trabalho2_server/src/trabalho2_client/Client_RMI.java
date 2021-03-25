/*
 * Autores: Rennã Tiedt
 * 	 	   Richard Curbani Alfarth
 * 
 * 
 * */
package trabalho2_client;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.Scanner;
public class Client_RMI {
	public static void main(String[] args) throws RemoteException, NotBoundException, MalformedURLException {
		Remote banco = Naming.lookup("rmi://localhost:1777/banco");
		Scanner s = new Scanner(System.in);
		String dadoConta = "";
		int dado = 0;
		double valor = 0;
		do {
			System.out.println("Qual sua conta bancaria");
			dado = s.nextInt();
			((ContaBanco) banco).setNumero(dadoConta);
			System.out.println("Você deseja  [1] - depositar, [2] - Sacar,  [3] - Sair?");
			dado = s.nextInt();
			if(dado == 1) {
				System.out.println("Informe o valor para depositar!");
				valor = s.nextInt();
				((ContaBanco) banco).depositar(valor);
				System.out.println("Seu saldo atual é: " + ((ContaBanco) banco).getSaldo());
			}
			if(dado == 2) {
				System.out.println("Informe o valor para sacar!");
				valor = s.nextInt();
				((ContaBanco) banco).sacar(valor);
				System.out.println("Seu saldo atual é: "+ ((ContaBanco) banco).getSaldo());
			}
			if(dado == 3) {
				System.out.println("Conta finalizada!!!");
				break;
			}
			
		}while(dado > -1);
	}
}
