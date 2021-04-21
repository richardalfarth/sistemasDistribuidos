package Prova;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

public class Client {
	public static void main(String[] args) throws UnknownHostException, IOException {
		double dado = 0;
		  do {	
			Socket socket = new Socket("localhost",9876);
			ObjectOutputStream output = new ObjectOutputStream(socket.getOutputStream());
			ObjectInputStream input = new ObjectInputStream(socket.getInputStream());
			Scanner s = new Scanner(System.in);
			do {
				System.out.println("Informe a altura");
				dado = s.nextInt();
				output.writeDouble(dado);
				output.flush();
				System.out.println("Informe o peso");
				dado = s.nextInt();
				output.writeDouble(dado);
				output.flush();
				System.out.println("Resposta: " + input.readUTF());
			}while(dado > -1);	
			input.close();
			output.close();		
			socket.close();
		  }while(true);	
	}
}
