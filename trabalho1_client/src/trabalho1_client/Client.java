/*
 * Autores
 * Rennã Tiedt
 * Richard Curbani Alfarth * 
 * 
 * */

package trabalho1_client;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.InetSocketAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Scanner;

public class Client {
	public static void main(String[] args) throws IOException {
	int dado = 0;
	  do {	
		Socket socket = new Socket("localhost",1600);
		ObjectOutputStream output = new ObjectOutputStream(socket.getOutputStream());
		ObjectInputStream input = new ObjectInputStream(socket.getInputStream());
		Scanner s = new Scanner(System.in);
		do {
			System.out.println("Você deseja saber a [1]-Data ou a [2]-Hora? Para desconectar tecle [3]");
			dado = s.nextInt();
			if(dado != 3) { 
				output.write(dado);
				output.flush();
				System.out.println("Resposta: " + input.readUTF());
			}
			
			 if(dado == 3) {
				socket.close();
			  }
			
		}while(dado > -1);
		input.close();
		output.close();		
	  }while(true);	
	
	}
}